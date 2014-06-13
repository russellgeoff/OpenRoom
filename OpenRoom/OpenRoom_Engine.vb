Public Class OpenRoom_Engine

    Dim myOlApp As New Outlook.Application
    Dim myNameSpace As Outlook.NameSpace
    Dim myRecipient As Outlook.Recipient

    Public Sub New()
        Windows.Forms.MessageBox.Show("You've loaded the OpenRoom Engine")
    End Sub

    'Fucntion determines if a given room is free or busy at a specific date and for a specific length
    'Meeting increment specifies the resolution that is checked 
    'Returns True if the room is busy
    'Returns False if the room is free
    Public Function isRoomBusy(ByVal conferenceRoom As String, _
                               ByVal meetingDayAndTime As Date, _
                               ByVal meetingLength As Integer, _
                               ByVal meetingIncrement As Integer)

        Dim minutesFromStart As Integer
        Dim incrementsFromStart As Integer

        Dim myFBInfo As String

        minutesFromStart = DateDiff("n", DateValue(meetingDayAndTime), meetingDayAndTime) 'Minutes from the start of the day until the meeting
        incrementsFromStart = minutesFromStart / meetingIncrement 'Number of meeting increments from the start of the day (used as the start indext for the FreeBusy request

        myNameSpace = myOlApp.GetNamespace("MAPI")
        myRecipient = myNameSpace.CreateRecipient(conferenceRoom)

        myFBInfo = myRecipient.FreeBusy(meetingDayAndTime, meetingIncrement, False)

        For i = 1 To Len(Mid(myFBInfo, incrementsFromStart + 1, meetingLength / meetingIncrement))
            Dim test As String
            test = Mid(myFBInfo, incrementsFromStart + i, 5)
            If (Mid(myFBInfo, incrementsFromStart + i, 1) = "1") Then
                Return True
                Exit Function
            End If
        Next

        Return False
    End Function

    Public Function BookConferenceRoom(ByVal conferenceRoom As String, _
                                       ByVal meetingDateAndTime As Date, _
                                       ByVal meetingLength As Integer)

        Dim oAppt As Outlook._AppointmentItem = myOlApp.CreateItem(Outlook.OlItemType.olAppointmentItem)

        ' Change AppointmentItem to a Meeting. 
        oAppt.MeetingStatus = Outlook.OlMeetingStatus.olMeeting

        With oAppt
            .Start = meetingDateAndTime
            .Duration = meetingLength
            .MeetingStatus = Outlook.OlMeetingStatus.olMeeting
            .Recipients.Add(conferenceRoom)
            .Recipients.ResolveAll()
            .Save()
            .Subject = oAppt.Organizer + " Meeting"
            .Body = "This is an automatically generated meeting request by OpenRoom"
            .Send()
        End With

        Return True
    End Function

End Class
