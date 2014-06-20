Imports System.Windows.Forms
Imports System.Drawing

'TODO:  Follow these steps to enable the Ribbon (XML) item:

'1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

'Protected Overrides Function CreateRibbonExtensibilityObject() As Microsoft.Office.Core.IRibbonExtensibility
'    Return New OpenRoomRibbon()
'End Function

'2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
'   actions, such as clicking a button. Note: if you have exported this Ribbon from the
'   Ribbon designer, move your code from the event handlers to the callback methods and
'   modify the code to work with the Ribbon extensibility (RibbonX) programming model.

'3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.

'For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.

<Runtime.InteropServices.ComVisible(True)> _
Public Class OpenRoomRibbon
    Implements Office.IRibbonExtensibility

    Private ribbon As Office.IRibbonUI

    Public Sub New()
    End Sub

    Public Function GetCustomUI(ByVal ribbonID As String) As String Implements Office.IRibbonExtensibility.GetCustomUI
        Return GetResourceText("OpenRoom.OpenRoomRibbon.xml")
    End Function

#Region "Ribbon Callbacks"
    'Create callback methods here. For more information about adding callback methods, select the Ribbon XML item in Solution Explorer and then press F1.
    Public Sub Ribbon_Load(ByVal ribbonUI As Office.IRibbonUI)
        Me.ribbon = ribbonUI
    End Sub

    Public Sub OnActionCallback(ByVal control As Office.IRibbonControl)
        Select Case control.Id.Substring(0, 14)
            Case "btnRunOpenRoom"
                'Creates new OpenRoom Form
                Dim oForm As OpenRoomForm
                oForm = New OpenRoomForm(False)
            Case "btnRunQuickRoom".Substring(0, 14)
                'Creates new OpenRoom Form
                Dim oForm As OpenRoomForm
                oForm = New OpenRoomForm(True)
            Case Else
                Windows.Forms.MessageBox.Show("You clicked a different control.")
        End Select

    End Sub

    Public Function GetItemIcon(ByVal imageName As String) As System.Drawing.Bitmap

        Select imageName
            Case "OpenRoomIcon.png"
                Return My.Resources.OpenRoomIcon.ToBitmap
            Case "QuickRoomIcon.png"
                Return My.Resources.QuickRoomIcon.ToBitmap
            Case Else
                Return My.Resources.OpenRoomBtnIcon
        End Select

    End Function


#End Region

#Region "Helpers"

    Private Shared Function GetResourceText(ByVal resourceName As String) As String
        Dim asm As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
        Dim resourceNames() As String = asm.GetManifestResourceNames()
        For i As Integer = 0 To resourceNames.Length - 1
            If String.Compare(resourceName, resourceNames(i), StringComparison.OrdinalIgnoreCase) = 0 Then
                Using resourceReader As IO.StreamReader = New IO.StreamReader(asm.GetManifestResourceStream(resourceNames(i)))
                    If resourceReader IsNot Nothing Then
                        Return resourceReader.ReadToEnd()
                    End If
                End Using
            End If
        Next
        Return Nothing
    End Function

#End Region

End Class