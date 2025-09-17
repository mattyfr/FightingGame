using System.Runtime.Serialization;
using System.IO;
using FightingGame;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Security.AccessControl;

string[] stats = {};
float enemyKilled = 0;
float playerHP = 30;
float maxPlayerHP = 30;
float statPoints = 10;
float playerRegen = 20;
float playerCoins = 0;
bool wantToFightEnemy = true;
float playerLVL = 1;
double dexp = 0;
float exp = (float) dexp;
double dexpNeedForLVL = Math.Pow(1.115f, playerLVL) * 100;
float expNeedForLVL = (float) dexpNeedForLVL;
Attacks a1 = new()
{
    playerDMG = 5,
    playerHC = 75,
    playerCC = 15,
    playerCD = 2
};
Enemy e1 = new()
{
    enemyName = "Tank zombie",
    enemyDMG = 1,
    enemyHC = 99,
    enemyHP = 100 ,
};
Enemy e2 = new()
{
    enemyName = "Zombie",
    enemyDMG = 5 ,
    enemyHC = 50 ,
    enemyHP = 50 ,
};
Enemy e3 = new()
{
    enemyName = "Strong Zombie",
    enemyDMG = 15,
    enemyHC = 33,
    enemyHP = 35,
};
Weponds w0 = new()
{
    wepondName = "",
    wepondCD = 1f,
    wepondDmg = 1f,
    wepondStrength = "",
};
Weponds w1 = new()
{
    wepondName = "Halberd Of The Shredded",
    wepondCD = 1.5f,
    wepondDmg = 1.5f,
    wepondStrength = "zombie"
};
Weponds w2 = new()
{
    wepondName = "Sting",
    wepondCD = 1.5f,
    wepondDmg = 1.5f,
    wepondStrength = "spider"
};
Weponds w3 = new()
{
    wepondName = "Pooch Sword",
    wepondCD = 1.5f,
    wepondDmg = 1.5f,
    wepondStrength = "wolf"
};
Weponds w4 = new()
{
    wepondName = "Atomsplit Katana",
    wepondCD = 1.5f,
    wepondDmg = 1.5f,
    wepondStrength = "vamp"
};

List<Enemy> list = [e1, e2, e3];
Enemy e = list[Random.Shared.Next(list.Count)];
List<Weponds> wepondsList = [w0, w1, w2, w3, w4];
Weponds w = wepondsList[0];

// ===============================================
float playerHC = a1.playerHC;
float playerCC = a1.playerCC ;
float playerCD = a1.playerCD * w.wepondCD;
float playerDMG = a1.playerDMG * w.wepondDmg;
// =========================================
float enemyStartHP = e.enemyHP;
float enemyDMG = e.enemyDMG;
float enemyHC = e.enemyHC;
float enemyHP = e.enemyHP;
string enemyName = e.enemyName;
// =========================================


bool openMenu = true;


while (openMenu)
{
    string a = "0";
    Print($"Menu \n Type the number based on the action you want to do. \n 1. View stats \n 2. Spend skill points \n 3. Fight an enemy \n 4. Start a boss quest \n 5. Open shop \n 6. Save \n 7. Load a save", 100);
    a = Console.ReadLine();
    // view stats 
    if (a == "1")
    {
        Print($"HP:{playerHP}\nDamage:{a1.playerDMG}\nHit Chance:{a1.playerHC}\nCrit Damage:{a1.playerCD}\nCrit Chance{a1.playerCC}\nCoins:{playerCoins}\nRegen:{playerRegen}", 200);
    }
    else if (a == "2")
    {
        while (statPoints > 0)
        {
            Print($"you have {statPoints} avalable \n your current base stats are \n Hp:{playerHP}                       press 1 to increase by 3\n Damage:{a1.playerDMG}                    press 2 to increase by 1 \n Hit chance:{a1.playerHC}               press 3 to increase by 3\n Crit chance:{a1.playerCC}              press 4 to increase by 3\n Crit Damage:{a1.playerCD}               press 5 to increase by 1\n Player health regen:{playerRegen}      press 6 to increase by 1", 750);
            string b = Console.ReadLine();
            if (b == "1")
            {
                playerHP += 3;
                maxPlayerHP += 3;
                statPoints -= 1;

            }
            else if (b == "2")
            {
                a1.playerDMG += 1;
                statPoints -= 1;
            }
            else if (b == "3")
            {
                a1.playerHC += 3;
                statPoints -= 1;
            }
            else if (b == "4")
            {
                a1.playerCC += 3;
                statPoints -= 1;
            }
            else if (b == "5")
            {
                a1.playerCD += 1;
                statPoints -= 1;
            }
            else if (b == "6")
            {
                playerRegen += 1;
                statPoints -= 1;
            }

        }
    }
    else if (a == "3")
    {

        wantToFightEnemy = true;
        while (wantToFightEnemy)
        {

            while (playerHP > 0 && e.enemyHP > 0 && wantToFightEnemy)
            {
                Console.WriteLine(a1.playerDMG);
                float playerTDMG = 0;
                float enemyTDMG = 0;
                // playerTDMG = playerHit(playerDMG, playerHC, playerCC, playerCD);
                playerTDMG = chooseAttack(a1.playerDMG, a1.playerHC, a1.playerCC, a1.playerCD, a1, w);
                enemyTDMG = enemyHit(enemyHC, enemyDMG);
                playerHP -= enemyTDMG;
                e.enemyHP -= playerTDMG;
                Print($"player hp:{playerHP} \n{e.enemyName} hp:{e.enemyHP}", 300);

                //    int playerDMG, int playerHC, int playerCC, int play

            }
            if (playerHP <= 0)
            {
                Print("You Died", 500);
                Console.ReadLine();
            }
            else if (e.enemyHP <= 0)
            {
                // Print($"{statPoints}",1000); #test
                playerHP += playerRegen;
                if (playerHP > maxPlayerHP)
                {
                    playerHP = maxPlayerHP;
                }
                enemyKilled += 1;
                exp += 25;
                playerCoins += Random.Shared.Next(1, 4);
                e = list[Random.Shared.Next(list.Count)];
                enemyHC = e.enemyHC;
                enemyDMG = e.enemyDMG;
                enemyHP = e.enemyHP;
                Print($"You won!!", 500);
                Print($"You regenerated {playerRegen} hp", 450);
                if (exp > expNeedForLVL)
                {
                    exp -= expNeedForLVL;
                    playerLVL += 1;
                    statPoints += 3;
                    playerCoins += 100;
                    Print($"You leveled up to level {playerLVL} and recived 100 coins and 3 skill points. \nGet {expNeedForLVL} more exp to level up again", 350);
                }
                Print($"Do you want to kill another", 350);
                Print("\n 1 To kill another \n 2 To exit to menu", 450);
                string b = "0";
                b = Console.ReadLine();
                if (b == "1")
                {

                }
                else if (b == "2")
                {
                    wantToFightEnemy = false;
                    Console.WriteLine(wantToFightEnemy);
                }
                // Print($"{e.enemyName}",20); #test making sure it changed enemy
            }

        }

    }
    else if (a == "4")
    {

    }
    else if (a == "5")
    {
        Print($"Shop\n You have {playerCoins} \n1. +2 HP cost 10 coin\n 2. +5 DMG cost 10 coin\n 3. +5 Hit Chance cost 10 coin\n 4. Halberd Of The Shreadded cost 100 coin\n 5. Sting cost 100 coin \n 6. Pooch Swrod cost 100 coin \n 7. Atomsplit Kataana cost 100 coin", 650);
        string b = Console.ReadLine();
        if (b == "1")
        {
            if (playerCoins > 10)
            {
                maxPlayerHP += 2;
                playerHP += 2;
                playerCoins -= 10;
            }
        }
        else if (b == "2")
        {
            if (playerCoins > 10)
            {
                playerDMG += 5;
                playerCoins -= 5;
            }
        }
        else if (b == "3")
        {
            if (playerCoins > 10)
            {
                playerHC += 5;
                playerCoins -= 10;
            }
        }
        else if (b == "3")
        {
            if (playerCoins > 100)
            {
                w = wepondsList[1];
            }
        }
        else if (b == "4")
        {
            if (playerCoins > 100)
            {
                w = wepondsList[2];
            }
        }
        else if (b == "4")
        {
            if (playerCoins > 100)
            {
                w = wepondsList[3];
            }
        }
        else if (b == "5")
        {
            if (playerCoins > 100)
            {
                w = wepondsList[4];
            }

        }
    }
    else if (a == "6")
    {
        Save(playerHP, playerDMG, playerCD, playerCC, playerCoins, playerRegen, playerLVL, exp, enemyKilled, playerHC, maxPlayerHP);
    }
    else if (a == "7")
    {
        string[] Stats = load();
        float[] floatArray = Array.ConvertAll(Stats, float.Parse);
        playerHP = (floatArray[0]);
        a1.playerDMG = (floatArray[1]);
        a1.playerHC = (floatArray[2]);
        a1.playerCD = (floatArray[3]);
        a1.playerCC = (floatArray[4]);
        playerCoins = (floatArray[5]);
        playerRegen = (floatArray[6]);
        playerLVL = (floatArray[7]);
        exp = (floatArray[8]);
        enemyKilled = (floatArray[9]);
        maxPlayerHP = (floatArray[10]);
        UpdateStats(a1, playerHC, playerCC, playerCD, playerDMG, w, floatArray);
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
static float normalHit(float playerDMG, float playerHC, float playerCC, float playerCD, float wepondDmg, float wepondCD)
{
    int a = 0;
    int b = 0;
    float c = 0;
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
            return c;
        }
    }
    else
    {
        return 0;
    }

}
static float enemyHit(float enemyHC,float  enemyDMG)
{
    int a = 0;
    float b = 0;
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
static float chooseAttack(float playerDMG, float playerHC, float playerCC, float playerCD, Attacks a1, Weponds w)
{
    float playerTDMG = 0;
    playerTDMG = normalHit(a1.playerDMG, a1.playerHC, a1.playerCC, a1.playerCD, w.wepondDmg, w.wepondCD);
    return playerTDMG;

}
static string[] load()
{
    string[] saveStats = File.ReadAllLines(@"save.txt");
    return saveStats;
}
static void Save(float playerHP, float playerDMG, float playerCD, float playerCC, float playerCoins, float playerRegen, float playerLVL, float exp, float enemyKilled, float playerHC, float maxPlayerHP)
{
    string splayerHP = playerHP.ToString();
    string splayerDMG = playerDMG.ToString();
    string splayerHC = playerHC.ToString();
    string splayerCD = playerCD.ToString();
    string splayerCC = playerCC.ToString();
    string splayerCoins = playerCoins.ToString();
    string splayerRegen = playerRegen.ToString();
    string splayerLVL = playerLVL.ToString();
    string sexp = exp.ToString();
    string senemyKilled = enemyKilled.ToString();
    string smaxPlayerHP = maxPlayerHP.ToString();
    string[] saveStats = { splayerHP, splayerDMG, splayerCD, splayerCC, splayerCoins, splayerRegen, splayerLVL, sexp, senemyKilled, splayerHC, smaxPlayerHP };


    File.WriteAllLines(@"save.txt", saveStats);
}
static void UpdateStats(Attacks a1, float playerHC, float playerCC, float playerCD, float playerDMG, Weponds w, float[] floatArray)
{
    a1.playerHC = floatArray[2];
    a1.playerCC = floatArray[4];
    a1.playerCD = floatArray[3] * w.wepondCD;
    a1.playerDMG = floatArray[1] * w.wepondDmg;

}