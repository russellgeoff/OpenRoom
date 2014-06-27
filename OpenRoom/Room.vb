Public Class Room
    Implements ICloneable
    Public Property FormatedName As String
    Public Property OutlookName As String
    Public Property Button As Windows.Forms.Button
    Public Property Enabled As Boolean 'Determines if a search can be done on the room
    Public Property ButtonEnabled As Boolean 'Determines if the room button should be able to be used in booking a room
    Public Property Location As String
    Public Property Available As Integer = -1
    '0 - Not available
    '1 - Available
    '-1 - Not checked
    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class
