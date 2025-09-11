using FightingGame;

Attacks a1 = new()
{
    playerDMG = 5,
    playerHC = 75,
    playerCC = 15,
    playerCD = 2
};
Attacks a2 = new()
{
    playerDMG = 15,
    playerHC = 40,
    playerCC = 10,
    playerCD = 3
};
Enemy e1 = new()
{
    enemyName = "enemy",
    enemyDMG = 1,
    enemyHC = 99,
    enemyHP = 100
};
Enemy e2 = new()
{
    enemyName = "normal enemy",
    enemyDMG = 5,
    enemyHC = 50,
    enemyHP = 50
};
Enemy e3 = new()
{
    enemyName = "strong enemy",
    enemyDMG = 15,
    enemyHC = 33,
    enemyHP = 35
};
List<Enemy> list = [e1, e2, e3];
Enemy e = list[Random.Shared.Next(list.Count)];
// ===============================================
int playerHP = 30;
int statPoints = 10;
int playerRegen = 20;

int playerHC = a1.playerHC;
int playerCC = a1.playerCC ;
int playerCD = a1.playerCD ;
int playerDMG = a1.playerDMG ;
// =========================================
int enemyKilled = 0;
// =========================================
int enemyStartHP = e.enemyHP;
int enemyDMG = e.enemyDMG;
int enemyHC = e.enemyHC;
int enemyHP = e.enemyHP;
string enemyName = e.enemyName;

bool gameRunning = true;
while (gameRunning)
{
    if (statPoints > 0)
    {
        Print($"Do you whant to use skill points to increase your stats \n 1 Yea \n 2 No", 400);
        string a = Console.ReadLine();
        bool wantToSpendSkillPoints = true;

        if (a == ("1"))
        {
            wantToSpendSkillPoints = true;
            while (wantToSpendSkillPoints && statPoints > 0)
            {
                Print($"you have {statPoints} avalable \n your current base stats are \n Hp:{playerHP}                       press 1 to increase by 3\n Damage:{playerDMG}                    press 2 to increase by 1 \n Hit chance:{playerHC}               press 3 to increase by 3\n Crit chance:{playerCC}              press 4 to increase by 3\n Crit Damage:{playerCD}               press 5 to increase by 1\n Player health regen:{playerRegen}      press 6 to increase by 1", 750);
                string b = Console.ReadLine();
                if (b == "1")
                {
                    playerHP += 3;
                    statPoints -= 1;
                }
                else if (b == "2")
                {
                    a1.playerDMG += 1;
                    a2.playerDMG += 1;
                    playerDMG += 1;
                    statPoints -= 1;
                }
                else if (b == "3")
                {
                    a1.playerHC += 3;
                    a2.playerHC += 3;
                    playerHC += 3;
                    statPoints -= 1;
                }
                else if (b == "4")
                {
                    a1.playerCC += 3;
                    a2.playerCC += 3;
                    playerCC += 3;
                    statPoints -= 1;
                }
                else if (b == "5")
                {
                    a1.playerCD += 1;
                    a2.playerCD += 1;
                    playerCD += 1;
                    statPoints -= 1;
                }
                else if (b == "6")
                {
                    playerRegen += 1;
                    statPoints -= 1;
                }
                else
                {

                }
            }
        }
        else
        {
            wantToSpendSkillPoints = false;
        }
    }
    while (playerHP > 0 && enemyHP > 0)
    {
        
        int playerTDMG = 0;
        int enemyTDMG = 0;
        // playerTDMG = playerHit(playerDMG, playerHC, playerCC, playerCD);
        playerTDMG = chooseAttack(playerDMG, playerHC, playerCC, playerCD, a1, a2);
        enemyTDMG = enemyHit(enemyDMG, enemyHC);
        playerHP -= enemyTDMG;
        enemyHP -= playerTDMG;
        Print($"player hp:{playerHP} \n{enemyName} hp:{enemyHP}", 300);

        //    int playerDMG, int playerHC, int playerCC, int play
    }
    if (playerHP <= 0)
    {
        Print("You lost", 500);
        gameRunning = false;
        Console.ReadLine();
    }
    else if (enemyHP <= 0)
    {
        Print("You won!!", 500);
        Print($"You regenerated {playerRegen} hp", 450);
        playerHP += playerRegen;
        statPoints += 3;
        enemyKilled += 1;

        enemyHP = enemyStartHP;
    }
    else
    {
    }
}

static void Print(string a, int time)
{
    for (int i = 0; i < a.Length; i++)
    {
        Console.Write(a[i]);
        Thread.Sleep(time / a.Length);
        if (Console.KeyAvailable == true)
        {
            if (Console.ReadKey().KeyChar == ' ')
            {
                time = 0;
            }
        }

    }
    Console.Write("\n");
}
static int random()
{
    int a = 0;
    a = Random.Shared.Next(1, 101);
    return a;

}
static int normalHit(int playerDMG, int playerHC, int playerCC, int playerCD)
{
    int a = 0;
    int b = 0;
    int c = 0;
    a = random();
    if (a <= playerHC)
    {
        b = random();
        if (b <= playerCC)
        {
            c = playerDMG * playerCD;
            Print("Crit!", 120);
            return c;
        }
        else
        {
            c = playerDMG;
            Print($"{playerDMG}", 100);
            return c;
        }
    }
    else
    {
        return 0;
    }

}
static int heavyHit(int playerDMG, int playerHC, int playerCC, int playerCD)
{
    int a = 0;
    int b = 0;
    int c = 0;
    a = random();
    if (a <= playerHC)
    {
        b = random();
        if (b <= playerCC)
        {
            c = playerDMG * playerCD;
            Print("CRIT!!!", 120);
            return c;
        }
        else
        {
            c = playerDMG;
            return c;
        }
    }
    else
    {
        return 0;
    }
}
static int enemyHit(int enemyDMG, int enemyHC)
{
    int a = 0;
    int b = 0;
    a = random();
    if (a <= enemyHC)
    {
        b = enemyDMG;
        return b;
    }
    else
    {
        return 0;
    }
}
static int chooseAttack(int playerDMG, int playerHC, int playerCC, int playerCD, Attacks a1, Attacks a2)
{
    int playerTDMG = 0;
    Print($"Do you want to use a normal attack or heavy attak? \n 1 For normal attack \n 2 For heavy attack ", 450);
    string a = Console.ReadLine();
    if (a == "1")
    {
        
        playerTDMG = normalHit(a1.playerDMG, a1.playerHC, a1.playerCC, a1.playerCD);
        return playerTDMG;
    }
    else
    {
        playerTDMG = heavyHit(a2.playerDMG, a2.playerHC, a2.playerCC, a2.playerCD);
        return playerTDMG;
    }
}
