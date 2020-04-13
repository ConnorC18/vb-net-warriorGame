Public MustInherit Class Item

    Protected name As String
    Protected quantity As Integer

    Public Sub New(ByVal inName As String, ByVal inQuantity As Integer)
        name = inName
        quantity = inQuantity
    End Sub

    Public Function getName()
        Return name
    End Function

    Public Function getQuantity()
        Return quantity
    End Function




End Class
