VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} OpenRoomForm 
   Caption         =   "OpenRoom by Geoff Russell"
   ClientHeight    =   4920
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   8895
   OleObjectBlob   =   "OpenRoomForm.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "OpenRoomForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'OpenRoom Code
'Version 1.0
'
'Created by Geoff Russell
'Geoff.Russell@stryker.com
'
'Adivce provided by Nick Switzer


Private Sub BigSurCommandButton_Click()
    BookConferenceRoom ("CR-BigSur")
End Sub

Private Sub CarmelCommandButton_Click()
    BookConferenceRoom ("CR-Carmel")
End Sub

Private Sub DRRoomCommandButton_Click()
    BookConferenceRoom ("CR-Design Review Room")
End Sub


Private Sub JoshuaTreeCommandButton_Click()
    BookConferenceRoom ("CR-JoshuaTree")
End Sub

Private Sub MendocinoCommandButton_Click()
    BookConferenceRoom ("CR-Mendocino")
End Sub

Private Sub MontereyCommandButton_Click()
    BookConferenceRoom ("CR-Monterey")
End Sub

Private Sub NapaCommandButton_Click()
    BookConferenceRoom ("CR-Napa")
End Sub

Private Sub PinnaclesCommandButton_Click()
    BookConferenceRoom ("CR-Pinnacles")
End Sub

Private Sub PismoBeachCommandButton_Click()
    BookConferenceRoom ("CR-Pismo Beach")
End Sub

Private Sub SantaCruzCommandButton_Click()
    BookConferenceRoom ("CR-Santa Cruz")
End Sub

Private Sub ShastaCommandButton_Click()
    BookConferenceRoom ("CR-Shasta")
End Sub

Private Sub SquawValleyCommandButton_Click()
    BookConferenceRoom ("CR-Squaw Valley")
End Sub

Private Sub TahoeCommandButton_Click()
    BookConferenceRoom ("CR-Tahoe")
End Sub

Private Sub UserForm_Initialize()

    'Setup Meeting Length Box
    With MeetingLengthComboBox
       .AddItem "30 minutes"
       .AddItem "1 hour"
       .AddItem "1.5 hours"
       .AddItem "2 hours"
       .Value = "30 minutes"
    End With
    
    'Setup Start Date and Time with Current Day and Time
    StartDatePicker.Value = Date
    StartTimePicker.Value = Format(Now, "h:N")
        
End Sub
Private Sub FindRoomButton_Click()
    Dim meetingDateAndTime As Date
    Dim meetingLength As Integer
    Dim doEventsResponse As Integer
        
    'Reset all the button colors
    CarmelCommandButton.BackColor = &H8000000F
    MendocinoCommandButton.BackColor = &H8000000F
    NapaCommandButton.BackColor = &H8000000F
    PinnaclesCommandButton.BackColor = &H8000000F
    DRRoomCommandButton.BackColor = &H8000000F
    TahoeCommandButton.BackColor = &H8000000F
    BigSurCommandButton.BackColor = &H8000000F
    SantaCruzCommandButton.BackColor = &H8000000F
    ShastaCommandButton.BackColor = &H8000000F
    SquawValleyCommandButton.BackColor = &H8000000F
    JoshuaTreeCommandButton.BackColor = &H8000000F
    MontereyCommandButton.BackColor = &H8000000F
    PismoBeachCommandButton.BackColor = &H8000000F
    
    'Get user input from form
    meetingDateAndTime = StartDatePicker.Value + StartTimePicker.Value 'Get date and time of meeting
    'Get meeting length
    Select Case MeetingLengthComboBox.Value
        Case "30 minutes"
            meetingLength = 30
        Case "1 hour"
            meetingLength = 60
        Case "1.5 hours"
            meetingLength = 90
        Case "2 hours"
            meetingLength = 120
    End Select
                
    If (RDCheckBox.Value = True) Then
    
        'Check Carmel
        If (GetFreeBusyInfo("CR-Carmel", meetingDateAndTime, meetingLength, 30) = "Busy") Then
            CarmelCommandButton.BackColor = &HFF&
            CarmelCommandButton.Enabled = False
        Else
            CarmelCommandButton.BackColor = &HFF00&
            CarmelCommandButton.Enabled = True
        End If
        
        doEventsResponse = DoEvents()
        
        'Check Mendocino
        If (GetFreeBusyInfo("CR-Mendocino", meetingDateAndTime, meetingLength, 30) = "Busy") Then
            MendocinoCommandButton.BackColor = &HFF&
            MendocinoCommandButton.Enabled = False
        Else
            MendocinoCommandButton.BackColor = &HFF00&
            MendocinoCommandButton.Enabled = True
        End If
        
        doEventsResponse = DoEvents()
        
        'Check Napa
        If (GetFreeBusyInfo("CR-Napa", meetingDateAndTime, meetingLength, 30) = "Busy") Then
            NapaCommandButton.BackColor = &HFF&
            NapaCommandButton.Enabled = False
        Else
            NapaCommandButton.BackColor = &HFF00&
            NapaCommandButton.Enabled = True
        End If
        
        doEventsResponse = DoEvents()
        
        'Check Pinnacles
        If (GetFreeBusyInfo("CR-Pinnacles", meetingDateAndTime, meetingLength, 30) = "Busy") Then
            PinnaclesCommandButton.BackColor = &HFF&
            PinnaclesCommandButton.Enabled = False
        Else
            PinnaclesCommandButton.BackColor = &HFF00&
            PinnaclesCommandButton.Enabled = True
        End If
        
        doEventsResponse = DoEvents()
        
        'Check Design Review Room
        If (GetFreeBusyInfo("CR-Design Review Room", meetingDateAndTime, meetingLength, 30) = "Busy") Then
            DRRoomCommandButton.BackColor = &HFF&
            DRRoomCommandButton.Enabled = False
        Else
            DRRoomCommandButton.BackColor = &HFF00&
            DRRoomCommandButton.Enabled = True
        End If
        
        doEventsResponse = DoEvents()
        
        'Check Tahoe
        If (GetFreeBusyInfo("CR-Tahoe", meetingDateAndTime, meetingLength, 30) = "Busy") Then
            TahoeCommandButton.BackColor = &HFF&
            TahoeCommandButton.Enabled = False
        Else
            TahoeCommandButton.BackColor = &HFF00&
            TahoeCommandButton.Enabled = True
        End If
        
        doEventsResponse = DoEvents()
    End If
    
    If (OpsCheckBox.Value = True) Then
    
        'Check Big Sur
        If (GetFreeBusyInfo("CR-Big Sur", meetingDateAndTime, meetingLength, 30) = "Busy") Then
            BigSurCommandButton.BackColor = &HFF&
            BigSurCommandButton.Enabled = False
        Else
            BigSurCommandButton.BackColor = &HFF00&
            BigSurCommandButton.Enabled = True
        End If
        
        doEventsResponse = DoEvents()
        
        'Check Santa Cruz
        If (GetFreeBusyInfo("CR-Santa Cruz", meetingDateAndTime, meetingLength, 30) = "Busy") Then
            SantaCruzCommandButton.BackColor = &HFF&
            SantaCruzCommandButton.Enabled = False
        Else
            SantaCruzCommandButton.BackColor = &HFF00&
            SantaCruzCommandButton.Enabled = True
        End If
        
        doEventsResponse = DoEvents()
    End If
    
    If (Floor2CheckBox.Value = True) Then
    
        'Check Shasta
        If (GetFreeBusyInfo("CR-Shasta", meetingDateAndTime, meetingLength, 30) = "Busy") Then
            ShastaCommandButton.BackColor = &HFF&
            ShastaCommandButton.Enabled = False
        Else
            ShastaCommandButton.BackColor = &HFF00&
            ShastaCommandButton.Enabled = True
        End If
        
        doEventsResponse = DoEvents()
        
        'Check Squaw Valley
        If (GetFreeBusyInfo("CR-Squaw Valley", meetingDateAndTime, meetingLength, 30) = "Busy") Then
            SquawValleyCommandButton.BackColor = &HFF&
            SquawValleyCommandButton.Enabled = False
        Else
            SquawValleyCommandButton.BackColor = &HFF00&
            SquawValleyCommandButton.Enabled = True
        End If
        
        doEventsResponse = DoEvents()
        
        'Check Joshua Tree
        If (GetFreeBusyInfo("CR-Joshua Tree", meetingDateAndTime, meetingLength, 30) = "Busy") Then
            JoshuaTreeCommandButton.BackColor = &HFF&
            JoshuaTreeCommandButton.Enabled = False
        Else
            JoshuaTreeCommandButton.BackColor = &HFF00&
            JoshuaTreeCommandButton.Enabled = True
        End If
        
        doEventsResponse = DoEvents()
        
        'Check Monterey
        If (GetFreeBusyInfo("CR-Monterey", meetingDateAndTime, meetingLength, 30) = "Busy") Then
            MontereyCommandButton.BackColor = &HFF&
            MontereyCommandButton.Enabled = False
        Else
            MontereyCommandButton.BackColor = &HFF00&
            MontereyCommandButton.Enabled = True
        End If
        
        doEventsResponse = DoEvents()
        
        'Check Pismo Beach
        If (GetFreeBusyInfo("CR-Pismo Beach", meetingDateAndTime, meetingLength, 30) = "Busy") Then
            PismoBeachCommandButton.BackColor = &HFF&
            PismoBeachCommandButton.Enabled = False
        Else
            PismoBeachCommandButton.BackColor = &HFF00&
            PismoBeachCommandButton.Enabled = True
        End If
    
        doEventsResponse = DoEvents()
    End If
        
End Sub

Public Function GetFreeBusyInfo(recipientName As String, meetingDayAndTime As Date, meetingLength As Integer, meetingIncrement As Integer)
    Dim myOlApp As New Outlook.Application
    Dim myNameSpace As Outlook.NameSpace
    Dim myRecipient As Outlook.Recipient
    
    Dim minutesFromStart As Integer
    Dim incrementsFromStart As Integer
            
    Dim myFBInfo As String
    
    minutesFromStart = DateDiff("n", DateValue(meetingDayAndTime), meetingDayAndTime) 'Minutes from the start of the day until the meeting
    incrementsFromStart = minutesFromStart / meetingIncrement 'Number of meeting increments from the start of the day (used as the start indext for the FreeBusy request
         
    Set myNameSpace = myOlApp.GetNamespace("MAPI")
    Set myRecipient = myNameSpace.CreateRecipient(recipientName)
    On Error GoTo ErrorHandler
    
    myFBInfo = myRecipient.FreeBusy(meetingDayAndTime, meetingIncrement, False)
    
    For i = 1 To Len(Mid(myFBInfo, incrementsFromStart + 1, meetingLength / meetingIncrement))
        Dim test As String
        test = Mid(myFBInfo, incrementsFromStart + i, 5)
        If (Mid(myFBInfo, incrementsFromStart + i, 1) = "1") Then
            GetFreeBusyInfo = "Busy"
            Exit Function
        End If
    Next
    
    Exit Function
ErrorHandler:
        MsgBox "Cannot access the information. "
End Function

Private Function BookConferenceRoom(conferenceRoom As String)
    Set objApp = CreateObject("Outlook.Application")
    Set objAppointment = objApp.CreateItem(olMeeting)
    
    Dim meetingDateAndTime As Date
    Dim meetingLength As Integer
    
    'Get user input from form
    meetingDateAndTime = StartDatePicker.Value + StartTimePicker.Value 'Get date and time of meeting
    'Get meeting length
    Select Case MeetingLengthComboBox.Value
        Case "30 minutes"
            meetingLength = 30
        Case "1 hour"
            meetingLength = 60
        Case "1.5 hours"
            meetingLength = 90
        Case "2 hours"
            meetingLength = 120
    End Select
    
    With objAppointment
        .Start = meetingDateAndTime
        .Duration = meetingLength
        .MeetingStatus = olMeeting
        .Recipients.Add (conferenceRoom)
        .Recipients.ResolveAll
        .Save
        .Subject = objAppointment.Organizer + " Meeting"
        .Save
        .Send
    End With
   
End Function

Public Sub CreateMeeting()
    
    Set objOutlookMeet = Application.CreateItem(olAppointmentItem)
    With objOutlookMeet
       .Subject = "Test"
       .Body = ""
        .Recipients.Add ("CR-Carmel")
        .Recipients.Add ("CR-Mendocino")
        .Recipients.Add ("CR-Napa")
        .Recipients.Add ("CR-Pinnacles")
        .Recipients.Add ("CR-Design Review Room")
        .Recipients.Add ("CR-Tahoe")
        .Recipients.Add ("CR-Big Sur")
        .Recipients.Add ("CR-Santa Cruz")
        .Recipients.Add ("CR-Shasta")
        .Recipients.Add ("CR-Squaw Valley")
        .Recipients.Add ("CR-Pismo Beach")
       .Display
    End With
    
End Sub
