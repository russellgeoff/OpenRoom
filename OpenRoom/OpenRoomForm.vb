Imports System.Windows.Forms

Public Class OpenRoomForm
    Dim OR_Engine As OpenRoom_Engine 'Engine for determining if a room is open and to book a room
    Public RoomList As New List(Of Room)(13)
    Dim meetingDateAndTime As Date
    Dim meetingLength As Integer

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

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
        StartDatePicker.Value = Date.Now()
        StartTimePicker.Value = Date.Now()

        ' Adds all the rooms to the Rooms List
        AddNewRoom("Carmel", "CR-Carmel", CarmelCommandButton)
        AddNewRoom("Mendocino", "CR-Mendocino", MendocinoCommandButton)
        AddNewRoom("Napa", "CR-Napa", NapaCommandButton)
        AddNewRoom("Pinnacles", "CR-Pinnacles", PinnaclesCommandButton)
        AddNewRoom("Tahoe", "CR-Tahoe", TahoeCommandButton)
        AddNewRoom("Design Review Room", "CR-Design Review Room", DRRoomCommandButton)
        AddNewRoom("Big Sur", "CR-Big Sur", BigSurCommandButton)
        AddNewRoom("Santa Cruz", "CR-Santa Cruz", SantaCruzCommandButton)
        AddNewRoom("Shasta", "CR-Shasta", ShastaCommandButton)
        AddNewRoom("Squaw Valley", "CR-Squaw Valley", SquawValleyCommandButton)
        AddNewRoom("Joshua Tree", "CR-Joshua Tree", JoshuaTreeCommandButton)
        AddNewRoom("Monterey", "CR-Monterey", MontereyCommandButton)
        AddNewRoom("Pismo Beach", "CR-Pismo Beach", PismoBeachCommandButton)
    End Sub

    Private Sub FindRoomBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindRoomBtn.Click

        ResetRoomButtons()

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

        ' For loop that goes through RoomList and checks if each one is available at the time requested
        ' First it will grab the conference room name from the list, then after getting a status back
        ' it will update the color of the button so that it reflects the room's schedule
        For Each room As Room In RoomList

            If (OR_Engine.isRoomBusy(room.OutlookName, meetingDateAndTime, meetingLength, 30) = False) Then
                room.Button.BackColor = Drawing.Color.Green
                room.Button.Enabled = True
            Else
                room.Button.BackColor = Drawing.Color.Red
                room.Button.Enabled = False
            End If
            Windows.Forms.Application.DoEvents() 'Eventually want to replace this with BackgroundWorker class and do multithreading
        Next room


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
            If (room.Button.Name = btn.Name) Then
                roomClicked = room.OutlookName
                OR_Engine.BookConferenceRoom(roomClicked, meetingDateAndTime, meetingLength)
            End If
        Next room

    End Sub

    Private Sub AddNewRoom(ByVal FormatedName As String, ByVal OutlookName As String, ByVal Button As Windows.Forms.Button)
        Dim room As New Room
        room.FormatedName = FormatedName
        room.OutlookName = OutlookName
        room.Button = Button
        RoomList.Add(room)
    End Sub

    Private Sub ResetRoomButtons()
        'Reset all the room button's color & enabled status
        For Each room As Room In RoomList
            room.Button.BackColor = Drawing.SystemColors.Control
            room.Button.Enabled = False
        Next (room)

        Refresh()
    End Sub

End Class