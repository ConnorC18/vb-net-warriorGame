Public Class Entity

    Protected name As String
    Protected currentHealth As Integer
    Protected maxHealth As Integer
    Protected attackDamage As Integer

    Public Sub New(ByVal myName As String, ByVal inMaxHealth As Integer, ByVal inAttackDamage As Integer)
        name = myName
        maxHealth = inMaxHealth
        currentHealth = maxHealth
        attackDamage = inAttackDamage
    End Sub


End Class
