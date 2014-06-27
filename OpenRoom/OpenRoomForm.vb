Imports System.Windows.Forms
Imports System.ComponentModel

Public Class OpenRoomForm
    Dim OR_Engine As OpenRoom_Engine 'Engine for determining if a room is open and to book a room
    Public RoomList As New List(Of Room) '(13)
    Dim meetingDateAndTime As Date
    Dim meetingLength As Integer
    Dim bw As BackgroundWorker = New BackgroundWorker

    Public Sub New(ByVal quickRoom As Boolean)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        bw.WorkerSupportsCancellation = True
        bw.WorkerReportsProgress = True

        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted

        'Create a new instance of the OpenRoom Engine
        OR_Engine = New OpenRoom_Engine

        'Setup Meeting Length Box
        With MeetingLengthComboBox.Items
            .Add("30 minutes")
            .Add("1 hour")
            .Add("1.5 hours")
            .Add("2 hours")
        End With

        MeetingLengthComboBox.SelectedItem = "30 minutes"

        'Setup Start Date and Time with Current Day and Time
        StartDatePicker.Value = Date.Now
        StartTimePicker.Value = OR_Engine.RoundTimeMin(Date.Now, 30)

        ' Adds all the rooms to the Rooms List
        AddNewRoom("Carmel", "CR-Carmel", CarmelCommandButton, "R&D", True)
        AddNewRoom("Mendocino", "CR-Mendocino", MendocinoCommandButton, "R&D", True)
        AddNewRoom("Napa", "CR-Napa", NapaCommandButton, "R&D", True)
        AddNewRoom("Pinnacles", "CR-Pinnacles", PinnaclesCommandButton, "R&D", True)
        AddNewRoom("Tahoe", "CR-Tahoe", TahoeCommandButton, "R&D", True)
        AddNewRoom("Design Review Room", "CR-Design Review Room", DRRoomCommandButton, "R&D", True)
        AddNewRoom("Big Sur", "CR-Big Sur", BigSurCommandButton, "Ops", True)
        AddNewRoom("Santa Cruz", "CR-Santa Cruz", SantaCruzCommandButton, "Ops", True)
        AddNewRoom("Shasta", "CR-Shasta", ShastaCommandButton, "Floor2", True)
        AddNewRoom("Squaw Valley", "CR-Squaw Valley", SquawValleyCommandButton, "Floor2", True)
        AddNewRoom("Joshua Tree", "CR-Joshua Tree", JoshuaTreeCommandButton, "Floor2", True)
        AddNewRoom("Monterey", "CR-Monterey", MontereyCommandButton, "Floor2", True)
        AddNewRoom("Pismo Beach", "CR-Pismo Beach", PismoBeachCommandButton, "Floor2", True)

        ResetRoomButtons()
        Me.Show()

        If quickRoom Then
            'Pulls starting info from appointment
            GetAppointmentInfo()
            OpenRoomSearch()
        End If
    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim arguments As ThreadArguments = e.Argument

        ' For loop that goes through RoomList and checks if each one is available at the time requested
        ' First it will grab the conference room name from the list, then after getting a status back
        ' it will update the color of the button so that it reflects the room's schedule

        For Each room As Room In arguments.roomList

            If bw.CancellationPending = True Then
                e.Cancel = True
                Exit For
            End If

            room.Available = -1
            If room.Enabled = True Then
                If (OR_Engine.isRoomBusy(room.OutlookName, meetingDateAndTime, meetingLength) = False) Then
                    room.Available = 1
                Else
                    room.Available = 0
                End If
            End If

            bw.ReportProgress(10, room)

        Next room
    End Sub

    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        Dim room As Room = e.UserState
        'Dim room As Room
        ''Dim compareRoom As New Room
        ''compareRoom.Available = room.Available
        ''compareRoom.Button = room.Button
        ''compareRoom.Enabled = room.Enabled
        ''compareRoom.FormatedName = room.FormatedName
        ''compareRoom.Location = room.Location
        ''compareRoom.OutlookName = room.OutlookName

        'Dim index As Integer = RoomList.FindIndex(Function(x) x.FormatedName = inputRoom.FormatedName)

        'room = RoomList(index)

        'For Each room In RoomList
        If room.Available = -1 Then
            'Do nothing since the room hasnot been checked
        ElseIf room.Available = 1 Then
            If room.Button.InvokeRequired = True Then
                'MsgBox("True")
                room.Button.BackColor = Drawing.Color.Green
                room.ButtonEnabled = True
                'room.Button.Enabled = True ' think this needs to have an invoke 
            End If
        ElseIf room.Available = 0 Then
            If room.Button.InvokeRequired = True Then
                'MsgBox("False")
                room.Button.BackColor = Drawing.Color.Red
                room.ButtonEnabled = False
                'room.Button.Enabled = False
            End If
        End If
            'Next
    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)

        If e.Cancelled = True Then
            MsgBox("Search Canceled!")
        ElseIf e.Error IsNot Nothing Then
            MsgBox("Error!! " & e.Error.Message)
        Else

        End If


    End Sub

    Private Sub OpenRoomSearch()

        ResetRoomButtons()

        'Sends usage email
        If UsageInfo.Checked Then 'Only sends usage info if user opts in
            OR_Engine.SendUsageEmail(0) 'Sends search usage info
        End If

        'Get user input from form

        meetingDateAndTime = CDate(Format(StartDatePicker.Value, "d") _
                            & " " & Format(StartTimePicker.Value, "t")) 'Get date and time of meeting

        'Get meeting length
        Select Case MeetingLengthComboBox.SelectedItem
            Case "30 minutes"
                meetingLength = 30
            Case "1 hour"
                meetingLength = 60
            Case "1.5 hours"
                meetingLength = 90
            Case "2 hours"
                meetingLength = 120
        End Select

        'Dim RoomListCopy As List(Of Room) = New List(Of Room)

        'For Each room In RoomList
        '    RoomListCopy.Add(room.Clone())
        'Next

        Dim arguments As ThreadArguments = New ThreadArguments
        arguments.roomList = RoomList
        arguments.meetingDateAndTime = meetingDateAndTime
        arguments.meetingLength = meetingLength

        If Not bw.IsBusy = True Then
            bw.RunWorkerAsync(arguments)
        Else
            MsgBox("Cannot perform search while another is already running!")
        End If
    End Sub

    Private Sub FindRoomBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindRoomBtn.Click
        OpenRoomSearch()
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
                    System.Windows.Forms.MessageBox.Show("You successfully booked " & roomClicked)
                    If UsageInfo.Checked Then 'Only sends usage info if user opts in
                        OR_Engine.SendUsageEmail(1)
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

    Private Sub ResetRoomButtons()
        'Reset all the room button's color & enabled status
        For Each room As Room In RoomList
            room.Button.BackColor = Drawing.SystemColors.Control
            'room.Button.Enabled = False
            room.ButtonEnabled = False
        Next (room)

        'Refresh()
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

        Dim item As Outlook.AppointmentItem = Globals.ThisAddIn.Application.ActiveInspector().CurrentItem
        subject = item.Subject
        startTime = item.Start
        endTime = item.End

        meetingLength = DateDiff(DateInterval.Minute, startTime, endTime)

        Select Case meetingLength
            Case 30
                MeetingLengthComboBox.SelectedItem = "30 minutes"
            Case 60
                MeetingLengthComboBox.SelectedItem = "1 hour"
            Case 90
                MeetingLengthComboBox.SelectedItem = "1.5 hours"
            Case 120
                MeetingLengthComboBox.SelectedItem = "2 hours"
            Case Else
                System.Windows.Forms.MessageBox.Show("Selected meeting lenght is non standard or too long to be supported by OpenRoom")
        End Select

        'System.Windows.Forms.MessageBox.Show("Current time: " & startTime & " End time: " & endTime & "Difference: " & meetingLength)

        StartDatePicker.Value = startTime
        StartTimePicker.Value = startTime
    End Sub

    Private Sub OnKeyDownHandler(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case Keys.Return
                FindRoomBtn_Click(sender, e)
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Public Overloads Sub Close()
        'Cancels the backgroundworker when the application closes
        bw.CancelAsync()
    End Sub
End Class