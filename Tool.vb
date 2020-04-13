Public Class Tool
    Inherits Item
    Implements IBreakable

    Private maxDuribility As Integer
    Private currentDuribility As Integer

    Public Sub New(ByVal name As String, ByVal inDuribility As Integer)
        MyBase.New(name, 1)
        maxDuribility = inDuribility
        currentDuribility = maxDuribility
    End Sub

    Public Function useItem() As Integer Implements IBreakable.useItem
        If (currentDuribility > 0) Then
            currentDuribility -= 1
        End If
        Return currentDuribility
    End Function

    Public Function isUsed() As Boolean Implements IBreakable.isUsed
        Return (currentDuribility <= 0)
    End Function
End Class
