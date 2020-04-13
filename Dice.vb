Public Class Dice

    Private sidesCount As Integer

    Public Sub New()
        sidesCount = 6
    End Sub

    Public Sub New(ByVal sides As Integer)
        sidesCount = sides
    End Sub

    Public Function GetSidesCount() As Integer
        Return sidesCount
    End Function

    Public Function Roll() As Integer
        Return CInt(Int((sidesCount * Rnd()) + 1))
    End Function

End Class
