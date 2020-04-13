Module Module1
    Dim dice As Dice

    Sub Main()
        Randomize()

        Dim sides As Integer
        Dim warrior As BruteWarrior
        Dim enemy As MageWarrior


        Console.Write("How many sides should the dice have?: ")
        sides = Console.ReadLine
        dice = New Dice(sides)

        warrior = New BruteWarrior("Steve", 7, 200)
        enemy = New MageWarrior("Zombie", 50, 15)


        displayHealth(warrior)
        displayHealth(enemy)
        'Console.WriteLine("Warrior Health: " & warrior.getHealth)
        'Console.WriteLine("Enemy Health: " & enemy.getHealth)


        showMenu(warrior)

        Console.Clear()
        Console.WriteLine("--=Fight Started=--")



        While warrior.isAlive And enemy.isAlive

            Dim tmpInp As Char

            If (warrior.findWeapon() > -1) Then
                Console.WriteLine("Would you like to use your " & warrior.getInven()(warrior.findWeapon()).getName & "(Y/N)")
                tmpInp = getUserInp({"Y", "N"}.ToList)
                Console.WriteLine()
                If (tmpInp.ToString.ToUpper = "Y") Then

                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine("Steve Attacked " & enemy.getName & "! Using " & warrior.getInven()(warrior.findWeapon()).getName)
                    Console.ForegroundColor = ConsoleColor.White
                    Dim tmpWeapon As Weapon
                    tmpWeapon = CType(warrior.getInven()(warrior.findWeapon()), Weapon)
                    tmpWeapon.useItem()
                    enemy.Attacked(dice.Roll, tmpWeapon.doDamage)

                    If (tmpWeapon.isUsed) Then
                        Console.ForegroundColor = ConsoleColor.Cyan
                        Console.WriteLine(warrior.getInven()(warrior.findWeapon()).getName & " Broken!")
                        Console.ForegroundColor = ConsoleColor.White
                        warrior.removeItem(tmpWeapon)
                    End If


                Else
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine("Steve Attacked " & enemy.getName & "! Using Fists")
                    Console.ForegroundColor = ConsoleColor.White
                    warrior.Attack(enemy, dice.Roll)
                End If
            Else
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine("Steve Attacked " & enemy.getName & "! Using Fists")
                Console.ForegroundColor = ConsoleColor.White
                warrior.Attack(enemy, dice.Roll)
            End If

            Console.WriteLine("")
            displayHealth(warrior)
            displayHealth(enemy)
            Console.WriteLine("")


            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Enemy Attacked " & enemy.getName & "!")
            Console.ForegroundColor = ConsoleColor.White
            enemy.Attack(warrior, dice.Roll)

            Console.WriteLine("")
            displayHealth(warrior)
            displayHealth(enemy)
            Console.WriteLine("")


            If (warrior.isAlive And enemy.isAlive) Then

                Dim consumableItems = warrior.findConsumables()
                Dim allowedNums As New List(Of String)
                Dim usingItem As Item
                Dim usingItemConsumable As IConsumable
                Dim itemIndex As Integer

                If (consumableItems.Count > 0) Then
                    Dim tmpCounter As Integer = 0
                    Console.WriteLine("Would you like to use your consumables? ")
                    Console.WriteLine("0 : Dont Use Any")
                    allowedNums.Add("0")
                    tmpCounter += 1
                    For Each it In warrior.findConsumables()
                        Console.WriteLine(tmpCounter & " : " & it.getQuantity & " x " & it.getName & " | + " & CType(it, IConsumable).getHealthAmt & " Health")
                        allowedNums.Add(tmpCounter.ToString)
                        tmpCounter += 1
                    Next
                    Console.WriteLine()
                    tmpInp = getUserInp(allowedNums)
                    Console.WriteLine()

                    If (tmpInp <> "0") Then
                        tmpInp = CType(CType(CType(tmpInp.ToString, Integer) - 1, String), Char)
                        itemIndex = warrior.getIndex(consumableItems(CType(tmpInp.ToString, Integer)))
                        usingItem = warrior.getItemAtIndex(itemIndex)
                        usingItemConsumable = CType(usingItem, IConsumable)
                        warrior.addHealth(usingItemConsumable.getHealthAmt)
                        usingItemConsumable.doConsume()

                        If (usingItemConsumable.IsConsumed) Then
                            Console.ForegroundColor = ConsoleColor.Cyan
                            Console.WriteLine(usingItem.getName & " Consumed!")
                            Console.ForegroundColor = ConsoleColor.White
                            warrior.removeItem(usingItem)
                        Else
                            Console.ForegroundColor = ConsoleColor.Cyan
                            Console.WriteLine(usingItem.getName & " Used But Not Finished!")
                            Console.ForegroundColor = ConsoleColor.White
                        End If

                    End If



                End If

                classifyAbility(warrior, enemy)
            End If





        End While

        If (warrior.isAlive) Then
            Console.WriteLine(warrior.getName & " Won")
        ElseIf (enemy.isAlive) Then
            Console.WriteLine(enemy.getName & " Won")
        Else
            Console.WriteLine("Is Was a Tie")
        End If

        Console.ReadKey()

    End Sub

    Sub displayHealth(ByVal w As Warrior)
        Dim health As Integer = w.getHealth
        If (health < 0) Then
            health = 0
        End If
        Dim len As Integer = 10
        Dim blockAmt As Integer
        blockAmt = Math.Floor((health / w.getMaxHealth) * 10)
        len -= blockAmt
        Console.WriteLine(w.getName & ": " & health & "/" & w.getMaxHealth)
        If (blockAmt < 0) Then
            blockAmt = 0
            len = 10
        End If
        If (len < 0) Then
            len = 0
            blockAmt = 10
        End If
        Console.Write("[")
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.Write("".PadRight(blockAmt, "█") & "".PadRight(len, " "))
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("]")

    End Sub

    Sub showMenu(ByVal player As Warrior)
        Dim inp As Char
        Dim itemCount = 0
        player.setInvenSize(5)
        Dim ItmList As New ItemList
        Console.Clear()
        Console.WriteLine("Welcome Warrior! Before we begin you have some time to gather some items. As you have only just joined us you can only pick up FIVE Items")
        Console.WriteLine(vbNewLine & vbNewLine)
        Console.WriteLine("Pick a Weapon:")
        Console.WriteLine("[0] - None (0 Slots)")
        Console.WriteLine("[1] - Stone Hammer (1 Slot)")
        Console.WriteLine("[2] - Diamond Sword (1 Slot)")
        While inp <> "0" And inp <> "1" And inp <> "2"
            Console.Write("Select An Option: ")
            inp = Console.ReadKey.KeyChar
        End While

        Select Case inp
            Case "1"
                player.addItem(ItmList.createStoneHammer)
                itemCount += 1
            Case "2"
                player.addItem(ItmList.createDiamondSword)
                itemCount += 1
        End Select

        inp = ""

        While inp <> "0" And itemCount < 5
            inp = ""
            Console.WriteLine(vbNewLine & vbNewLine)
            Console.WriteLine("Pick a Consumable:")
            Console.WriteLine("[0] - Stop Adding Items (0 Slots)")
            Console.WriteLine("[1] - 5 Steak (1 Slot)")
            Console.WriteLine("[2] - 1 Instant Health Potion (1 Slot)")
            While inp <> "0" And inp <> "1" And inp <> "2"
                Console.Write("Select An Option: ")
                inp = Console.ReadKey.KeyChar
            End While

            Select Case inp
                Case "1"
                    player.addItem(ItmList.createSteak(5))
                    itemCount += 1
                Case "2"
                    player.addItem(ItmList.createHealthPot(20))
                    itemCount += 1
            End Select


        End While

        Console.WriteLine(vbNewLine & vbNewLine)
        Console.WriteLine("Items Picked... Here is your inventory")
        For Each singleItm In player.getInven
            Console.WriteLine(singleItm.getName())
        Next
        Console.WriteLine(vbNewLine & "Press Any Key To Continue")
        Console.ReadKey()

    End Sub

    Sub classifyAbility(ByVal Warrior As Warrior, ByVal Enemy As Warrior)


        If (Warrior.isAlive And TypeOf Warrior Is HealingWarrior) Then
            doHealAbility(Warrior, Enemy)
        End If

        If (Warrior.isAlive And TypeOf Warrior Is BruteWarrior) Then
            doSmashAbility(Warrior, Enemy)
        End If



    End Sub

    Sub doSmashAbility(ByVal Warrior As BruteWarrior, ByVal Enemy As Warrior)
        If Warrior.GetHaveSmashed = False Then
            Console.WriteLine("Use Smash?: ")
            If (Console.ReadKey.Key = ConsoleKey.Y) Then
                Console.WriteLine("")
                Warrior.Smash(Enemy, Dice.Roll)
                Console.WriteLine("Smashed!")
                displayHealth(Warrior)
                displayHealth(Enemy)
                Console.WriteLine("")
            End If
            Console.WriteLine("")
        End If
    End Sub

    Sub doHealAbility(ByVal Warrior As HealingWarrior, ByVal Enemy As Warrior)
        Warrior = CType(Warrior, HealingWarrior)
        If Warrior.GetHaveHealed = False Then
            Console.WriteLine("Use Heal?: ")
            If (Console.ReadKey.Key = ConsoleKey.Y) Then
                Console.WriteLine("")
                Warrior.Heal()
                Console.WriteLine("Healed!")
                Console.WriteLine("Warrior Health: " & Warrior.getHealth)
                Console.WriteLine("Enemy Health: " & Enemy.getHealth)
                Console.WriteLine("")
            End If
            Console.WriteLine("")
        End If
    End Sub

    Function getUserInp(ByVal validOptions As List(Of String)) As Char
        Dim inp As Char
        inp = Console.ReadKey.KeyChar
        While (Not validOptions.Contains(inp.ToString.ToUpper))
            Console.WriteLine()
            Console.Write("Invalid Input... Try Again: ")
            inp = Console.ReadKey.KeyChar
        End While

        Return inp
    End Function

End Module
