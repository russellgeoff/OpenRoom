Public Class OpenRoom_Engine

    Dim myOlApp As New Outlook.Application
    Dim myNameSpace As Outlook.NameSpace
    Dim myRecipient As Outlook.Recipient

    'General Declarations
    Const ORVersion = "2.0" 'OpenRoom Version

    Public Sub New()
        'Windows.Forms.MessageBox.Show("You've loaded the OpenRoom Engine")

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

    Public Function SendUsageEmail(type As Integer)
        Dim email As Object
        Dim subject As String
        Dim body As String

        Select Case type
            Case 0 'Sends usage information about the search
                subject = "[Open Room] A search was just performed with OpenRoom v" & ORVersion
                body = "A search was performed with OpenRoom v" & ORVersion & "!" &
                    vbNewLine & vbNewLine & "This is a message to understand the usage of OpenRoom and will be anonymized before sharing."
            Case 1 'Sends usage information about the booked room
                subject = "[Open Room] A room was just booked with OpenRoom v" & ORVersion
                body = "A room was just booked with OpenRoom v" & ORVersion & "!" &
                    vbNewLine & vbNewLine & "This is a message to understand the usage of OpenRoom and will be anonymized before sharing."
            Case Else 'Sends usage generalized usage information 
                subject = "[Open Room] An action was performed with OpenRoom v" & ORVersion
                body = "An unidentified action was performed with OpenRoom v" & ORVersion & "!" &
                    vbNewLine & vbNewLine & "This is a message to understand the usage of OpenRoom and will be anonymized before sharing."
        End Select

        email = myOlApp.CreateItem(Outlook.OlItemType.olMailItem)

        With email
            .Recipients.Add("Russell, Geoff")
            .Recipients.ResolveAll()
            .Subject = subject
            .Body = body
            .Importance = Outlook.OlImportance.olImportanceLow
            .Save()
            .Send()
        End With

    End Function

End Class
