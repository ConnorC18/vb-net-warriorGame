Public Class HealingWarrior
    Inherits Warrior

    Private haveHealed As Boolean

    Public Sub New(ByVal myName As String)
        MyBase.New(myName)
    End Sub

    Public Function GetHaveHealed() As Boolean
        Return haveHealed
    End Function

    Public Sub Heal()
        If (haveHealed = False) Then
            currentHealth = maxHealth
            haveHealed = True
        End If
    End Sub

    Public Overrides Sub Attack(ByVal enemy As Warrior, ByVal diceRoll As Integer)
        enemy.Attacked(diceRoll, attackDamage)
    End Sub

    Public Overrides Sub Attacked(ByVal diceRoll As Integer, ByVal attackedDamage As Integer)
        currentHealth -= diceRoll * attackedDamage
    End Sub

End Class
