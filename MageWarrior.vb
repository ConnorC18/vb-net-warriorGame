Public Class MageWarrior
    Inherits Warrior
    Private mana As Integer
    Private maxMana As Integer
    Private magicDamage As Integer

    Public Sub New(ByVal myName As String, ByVal myMaxMana As Integer, ByVal myMagicDamage As Integer)
        MyBase.New(myName)
        maxHealth = 100
        attackDamage = 5
        currentHealth = maxHealth
        maxMana = myMaxMana
        mana = myMaxMana
        magicDamage = myMagicDamage
    End Sub

    Public Function GetMana() As Integer
        Return mana
    End Function

    Public Overrides Sub Attack(enemy As Warrior, diceRoll As Integer)
        If (mana < maxMana) Then
            mana += 10
            If (mana > maxMana) Then
                mana = maxMana
            End If
            Console.WriteLine(name & " Mana Set To " & mana)
            enemy.Attacked(diceRoll, attackDamage)
        Else
            mana = 0
            enemy.Attacked(diceRoll, magicDamage)
        End If
    End Sub

    Public Overrides Sub Attacked(diceRoll As Integer, attackedDamage As Integer)
        currentHealth -= diceRoll * attackedDamage
    End Sub
End Class
