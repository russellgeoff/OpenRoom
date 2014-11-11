Public Class OpenRoom_Engine

    'Public outlookApp As Microsoft.Office.Interop.Outlook.Application
    Public outlookApp As Outlook.Application
    'Public outlookApp As Object
    'Public outlookNamespace As Microsoft.Office.Interop.Outlook.NameSpace
    Public outlookNamespace As Outlook.NameSpace

    Public Const SEARCH_EMAIL As Integer = 0
    Public Const BOOKING_EMAIL As Integer = 1
    Public Const QUICKROOM_SEARCH_EMAIL As Integer = 2
    Public Const QUICKROOM_BOOKING_EMAIL As Integer = 3

    'General Declarations
    Const ORVersion = "2.3" 'OpenRoom Version

    Public Sub New()
        'Windows.Forms.MessageBox.Show("You've loaded the OpenRoom Engine")
        'outlookApp = New Outlook.Application() 'Early bindings
        outlookApp = Globals.ThisAddIn.Application
        'outlookApp = CreateObject("Outlook.Application") 'Late bindings
        outlookNamespace = outlookApp.GetNamespace("MAPI")
    End Sub

    'Fucntion determines if a given room is free or busy at a specific date and for a specific length
    'Meeting increment specifies the resolution that is checked 
    'Returns True if the room is busy
    'Returns False if the room is free
    Public Function isRoomBusy(ByVal conferenceRoom As String, _
                               ByVal meetingDayAndTime As Date, _
                               ByVal meetingLength As Integer)

        Dim mintuesPerChar As Integer = 1 '1 minute/character 
        Dim minutesFromStart As Integer
        Dim incrementsFromStart As Integer
        Dim myFBInfo As String
        Dim meetingFBInfo As String
        Dim myRecipient As Outlook.Recipient

        minutesFromStart = DateDiff("n", meetingDayAndTime.Date, meetingDayAndTime) 'Minutes from the start of the day until the meeting
        incrementsFromStart = minutesFromStart / mintuesPerChar 'Number of meeting increments from the start of the day (used as the start indext for the FreeBusy request
        myRecipient = outlookNamespace.CreateRecipient(conferenceRoom)
        myFBInfo = myRecipient.FreeBusy(meetingDayAndTime.Date, mintuesPerChar, False) 'Free busy information from the start of the day
        meetingFBInfo = myFBInfo.Substring(incrementsFromStart, meetingLength / mintuesPerChar)

        For i = 0 To meetingFBInfo.Length - 1
            If (meetingFBInfo(i) = "1") Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function

    Public Function BookConferenceRoom(ByVal conferenceRoom As String, _
                                       ByVal meetingDateAndTime As Date, _
                                       ByVal meetingLength As Integer)

        Dim oAppt As Outlook._AppointmentItem = outlookApp.CreateItem(Outlook.OlItemType.olAppointmentItem)

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
            Case SEARCH_EMAIL 'Sends usage information about the search
                subject = "[OpenRoom] A search was just performed with OpenRoom v" & ORVersion
                body = "A search was performed with OpenRoom v" & ORVersion & "!" &
                    vbNewLine & vbNewLine & "This is a message to understand the usage of OpenRoom and will be anonymized before sharing."
            Case BOOKING_EMAIL 'Sends usage information about the booked room
                subject = "[OpenRoom] A room was just booked with OpenRoom v" & ORVersion
                body = "A room was just booked with OpenRoom v" & ORVersion & "!" &
                    vbNewLine & vbNewLine & "This is a message to understand the usage of OpenRoom and will be anonymized before sharing."
            Case QUICKROOM_SEARCH_EMAIL
                subject = "[OpenRoom][QuickRoom] A search was just performed using QuickRoom in OpenRoom v" & ORVersion
                body = "A search was performed using QuickRoom in OpenRoom v" & ORVersion & "!" &
                    vbNewLine & vbNewLine & "This is a message to understand the usage of OpenRoom and will be anonymized before sharing."
            Case QUICKROOM_BOOKING_EMAIL
                subject = "[OpenRoom][QuickRoom] A room was just booked using QuickRoom in OpenRoom v" & ORVersion
                body = "A room was just booked using QuickRoom in OpenRoom v" & ORVersion & "!" &
                    vbNewLine & vbNewLine & "This is a message to understand the usage of OpenRoom and will be anonymized before sharing."
            Case Else 'Sends usage generalized usage information 
                subject = "[OpenRoom] An action was performed with OpenRoom v" & ORVersion
                body = "An unidentified action was performed with OpenRoom v" & ORVersion & "!" &
                    vbNewLine & vbNewLine & "This is a message to understand the usage of OpenRoom and will be anonymized before sharing."
        End Select

        email = outlookApp.CreateItem(Outlook.OlItemType.olMailItem)

        With email
            .Recipients.Add("Russell, Geoff")
            .Recipients.ResolveAll()
            .Subject = subject
            .Body = body
            .Importance = Outlook.OlImportance.olImportanceLow
            .Save()
            .Send()
        End With

        Return True
    End Function

    Public Function RoundTimeMin(ByVal dateTime As Date, ByVal minInterval As Integer)
        Dim datePart = dateTime.Date
        Dim timePart = dateTime.TimeOfDay

        timePart = TimeSpan.FromMinutes(Math.Floor((timePart.TotalMinutes + minInterval / 2) / minInterval) * minInterval)

        Return datePart.Add(timePart)
    End Function
End Class
