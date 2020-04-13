Public Class BruteWarrior
    Inherits Warrior

    Private haveSmashed As Boolean

    Public Sub New(ByVal myName As String, ByVal myAttackDamage As String, ByVal myHealth As String)
        MyBase.New(myName, myAttackDamage, myHealth)
    End Sub

    Public Function GetHaveSmashed() As Boolean
        Return haveSmashed
    End Function

    Public Sub Smash(ByVal enemy As Warrior, ByVal diceRoll As Integer)
        If (haveSmashed = False) Then
            enemy.Attacked(diceRoll, attackDamage * 2)
            haveSmashed = True
        End If
    End Sub

    Public Overrides Sub Attack(ByVal enemy As Warrior, ByVal diceRoll As Integer)
        enemy.Attacked(diceRoll, attackDamage)
    End Sub

    Public Overrides Sub Attacked(ByVal diceRoll As Integer, ByVal attackedDamage As Integer)
        currentHealth -= diceRoll * attackedDamage
    End Sub

End Class
