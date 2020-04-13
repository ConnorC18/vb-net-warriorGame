Public Class ItemList


    Public Function createSteak(ByVal Amt As Integer)
        Dim steak As Food
        steak = New Food("Steak", 5, 1, Amt)
        Return steak
    End Function

    Public Function createHealthPot(ByVal healthAmt As Integer)
        Dim healthPot As Potion
        healthPot = New Potion("Health Potion", healthAmt, 1, 1)
        Return healthPot
    End Function

    Public Function createStoneHammer()
        Dim sword As Weapon
        sword = New Weapon("Stone Hammer", 12, 3)
        Return sword
    End Function

    Public Function createDiamondSword()
        Dim sword As Weapon
        sword = New Weapon("Diamond Sword", 10, 10)
        Return sword
    End Function



End Class
