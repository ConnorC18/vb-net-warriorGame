Public MustInherit Class Warrior
    Inherits Entity

    Private inventory As New List(Of Item)
    Private inventorySize As New Integer

    Public Sub New(ByVal myName As String)
        MyBase.New(myName, 100, 10)
        inventorySize = 10
    End Sub

    Public Sub New(ByVal myName As String, ByVal myAttackDamage As String, ByVal myHealth As String)
        MyBase.New(myName, myHealth, myAttackDamage)
    End Sub

    Public Sub setInvenSize(ByVal myInvenSize As Integer)
        inventorySize = myInvenSize
    End Sub

    Public Function getInvenSize()
        Return inventorySize
    End Function

    Public Sub addItem(ByVal itm As Item)
        inventory.Add(itm)
    End Sub

    Public Sub removeItem(ByVal itm As Item)
        inventory.Remove(itm)
    End Sub

    Public Function has(ByVal itm As Item) As Boolean
        Return inventory.Contains(itm)
    End Function

    Public Function getInven() As List(Of Item)
        Return inventory
    End Function

    Public Function getIndex(ByVal itm As Item) As Integer
        Return inventory.IndexOf(itm)
    End Function

    Public Function getItemAtIndex(ByVal indx As Integer) As Item
        Return inventory(indx)
    End Function

    Public Function findWeapon() As Integer
        For Each itm In inventory
            If (TypeOf itm Is Weapon) Then
                Return inventory.IndexOf(itm)
            End If
        Next
        Return -1

    End Function

    Public Function findConsumables() As List(Of Item)
        Dim tmpList As New List(Of Item)
        For Each itm In inventory
            If (TypeOf itm Is IConsumable) Then
                tmpList.Add(itm)
            End If
        Next
        Return tmpList
    End Function

    Public Function getHealth() As Integer
        Return currentHealth
    End Function

    Public Sub addHealth(ByVal amt As Integer)
        currentHealth += amt
        If (currentHealth > maxHealth) Then
            currentHealth = maxHealth
        End If
    End Sub

    Public Function getMaxHealth() As Integer
        Return maxHealth
    End Function

    Public Function getName() As String
        Return name
    End Function

    Public Function isAlive() As Boolean
        Return currentHealth > 0
    End Function

    Public MustOverride Sub Attack(ByVal enemy As Warrior, ByVal diceRoll As Integer)

    Public MustOverride Sub Attacked(ByVal diceRoll As Integer, ByVal attackedDamage As Integer)

End Class
