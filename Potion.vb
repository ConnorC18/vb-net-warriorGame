Public Class Potion
    Inherits Item
    Implements IConsumable


    Private healthAmt As Integer
    Protected maxPortions As Integer
    Protected currentPortions As Integer

    Public Sub New(ByVal name As String, ByVal inHealth As Integer, ByVal inPortions As Integer, ByVal inAmt As Integer)
        MyBase.New(name, inAmt)
        maxPortions = inPortions
        currentPortions = maxPortions
        healthAmt = inHealth
    End Sub

    Public Function doConsume() As Integer Implements IConsumable.doConsume
        If (currentPortions > 0) Then
            currentPortions -= 1
            If (currentPortions <= 0) Then
                If (quantity > 1) Then
                    quantity -= 1
                    currentPortions = maxPortions
                Else
                    quantity -= 1
                    currentPortions -= 1
                End If
            End If
        End If
        Return healthAmt
    End Function

    Public Function IsConsumed() As Boolean Implements IConsumable.IsConsumed
        Return (currentPortions <= 0 And quantity <= 0)
    End Function

    Public Function getHealthAmt() As Integer Implements IConsumable.getHealthAmt
        Return healthAmt
    End Function
End Class
