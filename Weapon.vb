Public Class Weapon
    Inherits Item
    Implements IBreakable
    Implements IDoDamage


    Private damageAmt As Integer
    Protected maxDuribility As Integer
    Protected currentDuribility As Integer

    Public Sub New(ByVal name As String, ByVal inDamage As Integer, ByVal inDuribility As Integer)
        MyBase.New(name, 1)
        maxDuribility = inDuribility
        currentDuribility = maxDuribility
        damageAmt = inDamage
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

    Public Function doDamage() As Integer Implements IDoDamage.doDamage
        Return damageAmt
    End Function
End Class
