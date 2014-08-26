Imports System.Windows.Forms
Imports System.ComponentModel

Public Class OpenRoomForm
    Dim OR_Engine As New OpenRoom_Engine 'Engine for determining if a room is open and to book a room
    Public RoomList As New List(Of Room) '(13)
    Dim meetingDateAndTime As Date
    Dim meetingLength As Integer
    Dim bw As BackgroundWorker = New BackgroundWorker
    Dim bFormClosing As Boolean = False
    Dim quickRoom As Boolean
    Dim appointmentItem As Outlook.AppointmentItem

    Public Sub New(ByVal quickRoomMode As Boolean)
        ' This call is required by the Windows Form Designer.
        Me.InitializeComponent()

        bw.WorkerSupportsCancellation = True
        bw.WorkerReportsProgress = True

        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted

        'Create a new instance of the OpenRoom Engine
        Me.OR_Engine = New OpenRoom_Engine()

        'Setup Meeting Length Box
        With MeetingLengthComboBox.Items
            .Add("30 minutes")
            .Add("1 hour")
            .Add("1.5 hours")
            .Add("2 hours")
        End With

        Me.MeetingLengthComboBox.SelectedItem = "30 minutes"

        'Setup Start Date and Time with Current Day and Time
        Me.StartDatePicker.Value = Date.Now
        Me.StartTimePicker.Value = OR_Engine.RoundTimeMin(Date.Now, 30)

        ' Adds all the rooms to the Rooms List
        Me.AddNewRoom("Carmel", "CR-Carmel", CarmelCommandButton, "R&D", True)
        Me.AddNewRoom("Mendocino", "CR-Mendocino", MendocinoCommandButton, "R&D", True)
        Me.AddNewRoom("Napa", "CR-Napa", NapaCommandButton, "R&D", True)
        Me.AddNewRoom("Pinnacles", "CR-Pinnacles", PinnaclesCommandButton, "R&D", True)
        Me.AddNewRoom("Tahoe", "CR-Tahoe", TahoeCommandButton, "R&D", True)
        Me.AddNewRoom("Design Review Room", "CR-Design Review Room", DRRoomCommandButton, "R&D", True)
        Me.AddNewRoom("Big Sur", "CR-Big Sur", BigSurCommandButton, "Ops", True)
        Me.AddNewRoom("Santa Cruz", "CR-Santa Cruz", SantaCruzCommandButton, "Ops", True)
        Me.AddNewRoom("Shasta", "CR-Shasta", ShastaCommandButton, "Floor2", True)
        Me.AddNewRoom("Squaw Valley", "CR-Squaw Valley", SquawValleyCommandButton, "Floor2", True)
        Me.AddNewRoom("Joshua Tree", "CR-Joshua Tree", JoshuaTreeCommandButton, "Floor2", True)
        Me.AddNewRoom("Monterey", "CR-Monterey", MontereyCommandButton, "Floor2", True)
        Me.AddNewRoom("Pismo Beach", "CR-Pismo Beach", PismoBeachCommandButton, "Floor2", True)

        Me.ResetRooms()
        Me.Show()

        Me.quickRoom = quickRoomMode

        If Me.quickRoom Then
            Me.QuickRoomLbl.Visible = True
            Me.appointmentItem = Globals.ThisAddIn.Application.ActiveInspector().CurrentItem
            'Pulls starting info from appointment
            Me.GetAppointmentInfo()
            Me.OpenRoomSearch()
        End If


        Dim keyName As String = "HKEY_CURRENT_USER\Software\Microsoft\Office\Outlook\Addins\OpenRoom"
        Dim valueName As String = "FirstRun"
        Dim readValue = My.Computer.Registry.GetValue(keyName, valueName, Nothing)

        'Determine if this is the first time running and then shows a dialog
        If Not readValue = "Yes" Then
            Dim fRunForm As FirstRunTutorial = New FirstRunTutorial()
            fRunForm.Show()
            My.Computer.Registry.SetValue(keyName, valueName, "Yes")
        End If
    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim arguments As ThreadArguments = e.Argument

        If bw.CancellationPending = True Then
            e.Cancel = True
        Else
            ' For loop that goes through RoomList and checks if each one is available at the time requested
            ' First it will grab the conference room name from the list, then after getting a status back
            ' it will update the color of the button so that it reflects the room's schedule

            For Each room As Room In arguments.roomList
                If bw.CancellationPending = True Then
                    e.Cancel = True
                    Exit For
                End If

                room.Available = -1 'Room has not been checked yet
                If room.Enabled = True Then
                    If (OR_Engine.isRoomBusy(room.OutlookName, arguments.meetingDateAndTime, arguments.meetingLength) = False) Then
                        room.Available = 1
                    Else
                        room.Available = 0
                    End If
                End If
                bw.ReportProgress(0, room)
            Next room
        End If
    End Sub

    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        Dim room As Room = e.UserState

        If room.Available = -1 Then
            'Do nothing since the room has not been checked
        ElseIf room.Available = 1 Then
            room.Button.BackColor = Drawing.Color.Green
            room.ButtonEnabled = True
            'room.Button.Enabled = True 'Causes problems with threading
        ElseIf room.Available = 0 Then
            room.Button.BackColor = Drawing.Color.Red
            room.ButtonEnabled = False
            'room.Button.Enabled = False 'Causes problems with threading
        End If
    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If Not bFormClosing Then
            If Not e.Cancelled Then
                'Completion work
            End If
        End If

        If e.Cancelled = True Then
            'MsgBox("Search Canceled!")
        ElseIf e.Error IsNot Nothing Then
            MsgBox("Error!! " & e.Error.Message)
        Else

        End If
    End Sub

    Private Sub OpenRoomSearch()
        'Sends usage email
        If Me.UsageInfo.Checked Then 'Only sends usage info if user opts in
            If Me.quickRoom Then
                Me.OR_Engine.SendUsageEmail(OpenRoom_Engine.QUICKROOM_SEARCH_EMAIL)
            Else
                Me.OR_Engine.SendUsageEmail(OpenRoom_Engine.SEARCH_EMAIL)
            End If
        End If

        'Get user input from form

        Me.meetingDateAndTime = CDate(Format(StartDatePicker.Value, "d") _
                            & " " & Format(StartTimePicker.Value, "t")) 'Get date and time of meeting

        'Get meeting length
        Select Case Me.MeetingLengthComboBox.SelectedItem
            Case "30 minutes"
                Me.meetingLength = 30
            Case "1 hour"
                Me.meetingLength = 60
            Case "1.5 hours"
                Me.meetingLength = 90
            Case "2 hours"
                Me.meetingLength = 120
        End Select

        Dim arguments As ThreadArguments = New ThreadArguments
        arguments.roomList = Me.RoomList
        arguments.meetingDateAndTime = Me.meetingDateAndTime
        arguments.meetingLength = Me.meetingLength

        If Not bw.IsBusy Then
            Me.ResetRooms()
            bw.RunWorkerAsync(arguments)
        Else
            MsgBox("Cannot perform search while another is already running!")
        End If
    End Sub

    Private Sub FindRoomBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindRoomBtn.Click
        Me.OpenRoomSearch()
    End Sub


    ' Handles all the room booking button clicks
    Private Sub RoomButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CarmelCommandButton.Click, _
        MendocinoCommandButton.Click, _
        NapaCommandButton.Click, _
        PinnaclesCommandButton.Click, _
        TahoeCommandButton.Click, _
        DRRoomCommandButton.Click, _
        BigSurCommandButton.Click, _
        SantaCruzCommandButton.Click, _
        ShastaCommandButton.Click, _
        SquawValleyCommandButton.Click, _
        JoshuaTreeCommandButton.Click, _
        MontereyCommandButton.Click, _
        PismoBeachCommandButton.Click

        Dim btn As Button = CType(sender, Button)
        Dim roomClicked As String

        If (meetingDateAndTime = Nothing) Then
            Return
        End If

        'Find the room that is associated with the button pressed and book the room for the time that was active during the search
        For Each room As Room In RoomList
            If (room.Button.Name = btn.Name And room.ButtonEnabled = True) Then
                roomClicked = room.OutlookName
                If (OR_Engine.BookConferenceRoom(roomClicked, meetingDateAndTime, meetingLength)) Then
                    If Me.quickRoom Then
                        'Syncronizes the appointment with the current search
                        Me.appointmentItem.Location = roomClicked
                        Me.appointmentItem.Start = meetingDateAndTime
                        Me.appointmentItem.End = meetingDateAndTime.AddMinutes(meetingLength)
                        System.Windows.Forms.MessageBox.Show("You successfully booked " & roomClicked & "!" & _
                                                             vbNewLine & vbNewLine & _
                                                             "The appointment has been updated to:" & _
                                                             vbNewLine & _
                                                             "Date & Time: " & meetingDateAndTime & _
                                                             vbNewLine & _
                                                             "Meeting Length: " & meetingLength & " minutes" & _
                                                             vbNewLine & _
                                                             "Room: " & roomClicked
                                                             )
                    Else
                        System.Windows.Forms.MessageBox.Show("You successfully booked " & roomClicked & "!")
                    End If

                    If Me.UsageInfo.Checked Then 'Only sends usage info if user opts in
                        If Me.quickRoom Then
                            Me.OR_Engine.SendUsageEmail(OpenRoom_Engine.QUICKROOM_BOOKING_EMAIL)
                        Else
                            Me.OR_Engine.SendUsageEmail(OpenRoom_Engine.BOOKING_EMAIL)
                        End If

                    End If
                End If
            End If
        Next room

    End Sub

    Private Sub AddNewRoom(ByVal FormatedName As String,
                           ByVal OutlookName As String,
                           ByVal Button As Windows.Forms.Button,
                           ByVal Location As String,
                           ByVal Enabled As Boolean)
        Dim room As New Room
        room.FormatedName = FormatedName
        room.OutlookName = OutlookName
        room.Button = Button
        room.Location = Location
        room.Enabled = Enabled
        RoomList.Add(room)
    End Sub

    Private Sub ResetRooms()
        'Reset all the room button's color & enabled status
        For Each room As Room In RoomList
            room.Button.BackColor = Drawing.SystemColors.Control
            'room.Button.Enabled = False
            room.ButtonEnabled = False
        Next (room)

        Me.Refresh()
    End Sub

    Private Sub LocationCheckedChanged(sender As Object, e As EventArgs) Handles _
        RDCheckBox.CheckedChanged, _
        OpsCheckBox.CheckedChanged, _
        Floor2CheckBox.CheckedChanged

        For Each room As Room In RoomList
            Select Case room.Location
                Case "R&D"
                    room.Enabled = RDCheckBox.Checked
                Case "Ops"
                    room.Enabled = OpsCheckBox.Checked
                Case "Floor2"
                    room.Enabled = Floor2CheckBox.Checked
            End Select
        Next (room)
    End Sub

    Private Sub GetAppointmentInfo()
        Dim subject As String = ""
        Dim startTime As Date
        Dim endTime As Date
        Dim meetingLength As Long

        subject = Me.appointmentItem.Subject
        startTime = Me.appointmentItem.Start
        endTime = Me.appointmentItem.End

        meetingLength = DateDiff(DateInterval.Minute, startTime, endTime)

        Select Case meetingLength
            Case 30
                Me.MeetingLengthComboBox.SelectedItem = "30 minutes"
            Case 60
                Me.MeetingLengthComboBox.SelectedItem = "1 hour"
            Case 90
                Me.MeetingLengthComboBox.SelectedItem = "1.5 hours"
            Case 120
                Me.MeetingLengthComboBox.SelectedItem = "2 hours"
            Case Else
                System.Windows.Forms.MessageBox.Show("Selected meeting length is non standard or too long to be supported by OpenRoom")
        End Select

        Me.StartDatePicker.Value = startTime
        Me.StartTimePicker.Value = startTime
    End Sub

    Private Sub OnKeyDownHandler(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case Keys.Return
                Me.FindRoomBtn_Click(sender, e)
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        bFormClosing = True
        bw.CancelAsync()

        MyBase.OnFormClosing(e)
    End Sub

    Private Sub RunOpenRoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunOpenRoomToolStripMenuItem.Click
        Me.OpenRoomSearch()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class