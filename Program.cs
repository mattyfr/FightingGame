using System.Runtime.Serialization;
using System.IO;
using FightingGame;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Security.AccessControl;
using System.Linq.Expressions;

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
float zexp = 0;
float sexp = 0;
float wexp = 0;
float vexp = 0;
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
Enemy e0 = new()
{

};
Enemy e1 = new()
{
    enemyName = "Tank zombie",
    enemyDMG = 1,
    enemyHC = 99,
    enemyHP = 100,
    enenmyType = "zombie"
};
Enemy e2 = new()
{
    enemyName = "Zombie",
    enemyDMG = 5,
    enemyHC = 50,
    enemyHP = 50,
    enenmyType = "zombie"
};
Enemy e3 = new()
{
    enemyName = "Strong Zombie",
    enemyDMG = 15,
    enemyHC = 33,
    enemyHP = 35,
    enenmyType = "zombie"
};
Enemy e4 = new()
{
    enemyName = "Spider",
    enemyDMG = 10,
    enemyHC = 50,
    enemyHP = 50,
    enenmyType = "spider"
};
Enemy e5 = new()
{
    enemyName = "Tank Spider",
    enemyDMG = 4,
    enemyHC = 99,
    enemyHP = 100,
    enenmyType = "spider"
};
Enemy e6 = new() {
    enemyName = "wolf",
    enemyDMG = 15,
    enemyHC = 45,
    enemyHP = 75,
    enenmyType = "wolf"
};
Enemy e7 = new()
{
    enemyName = "strong wolf",
    enemyDMG = 30,
    enemyHC = 33,
    enemyHP = 45,
    enenmyType = "wolf"
};
Enemy e8 = new()
{
    enemyName = "Vampire",
    enemyDMG = 50,
    enemyHC = 75,
    enemyHP = 120,
    enenmyType = "vamp"
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

List<Enemy> list = [e1, e2, e3, e5, e6, e7, e8];
List<Enemy> zlist = [e1, e2, e3];
List<Enemy> slist = [e4, e5];
List<Enemy> wlist = [e6, e7];
List<Enemy> vlist = [e8];
Enemy e = list[0];
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
    Console.Clear();
    string a = "0";
    Print($"Menu \n Type the number based on the action you want to do. \n 1. View stats \n 2. Spend skill points \n 3. Fight an enemy \n 4. Start a boss quest \n 5. Open shop \n 6. Save \n 7. Load a save", 100);
    a = Console.ReadLine();
    // view stats 
    if (a == "1")
    {
        Print($"HP:{playerHP}\nDamage:{a1.playerDMG}\nHit Chance:{a1.playerHC}\nCrit Damage:{a1.playerCD}\nCrit Chance{a1.playerCC}\nCoins:{playerCoins}\nRegen:{playerRegen}", 200);
        Console.ReadLine();
    }
    // Opens the spend skill points menu
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
    // Fights a random enenmy
    else if (a == "3")
    {

        wantToFightEnemy = true;
        while (wantToFightEnemy)
        {
            Print($"What typer of enemy do you want to fight \n 1. Zombie \n 2. Sprider \n 3. Wolf \n 4. Vampire", 350);
            string c = Console.ReadLine();
            if (c == "1")
            {
                e = zlist[Random.Shared.Next(zlist.Count)];
            }
            else if (c == "2")
            {
                e = slist[Random.Shared.Next(slist.Count)];
            }
            else if (c == "3")
            {
                e = wlist[Random.Shared.Next(wlist.Count)];
            }
            else if (c == "4")
            {
                e = vlist[Random.Shared.Next(vlist.Count)];
            }
            while (playerHP > 0 && e.enemyHP > 0 && wantToFightEnemy)
            {
                Console.WriteLine(a1.playerDMG);
                float playerTDMG = 0;
                float enemyTDMG = 0;
                // playerTDMG = playerHit(playerDMG, playerHC, playerCC, playerCD);
                playerTDMG = chooseAttack(a1.playerDMG, a1.playerHC, a1.playerCC, a1.playerCD, a1, w);
                enemyTDMG = enemyHit(enemyHC, enemyDMG, e);
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
                if (e.enenmyType == "zombie")
                {
                    zexp += 25;
                }
                else if (e.enenmyType == "spider")
                {
                    sexp += 25;
                }
                else if (e.enenmyType == "wolf")
                {
                    wexp += 25;
                }
                else if (e.enenmyType == "vamp")
                {
                    vexp += 25;
                }
                playerCoins += Random.Shared.Next(1, 4);

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
    // Starts a boss quest  dosent work yet
    else if (a == "4")
    {

    }
    // Opens the shop menu
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
        else if (b == "4")
        {
            if (playerCoins > 100)
            {
                w = wepondsList[1];
            }
        }
        else if (b == "5")
        {
            if (playerCoins > 100)
            {
                w = wepondsList[2];
            }
        }
        else if (b == "6")
        {
            if (playerCoins > 100)
            {
                w = wepondsList[3];
            }
        }
        else if (b == "7")
        {
            if (playerCoins > 100)
            {
                w = wepondsList[4];
            }

        }

    }
    // Saves most stats 
    else if (a == "6")
    {
        // Calls Save
        Save(playerHP, playerDMG, playerCD, playerCC, playerCoins, playerRegen, playerLVL, exp, enemyKilled, playerHC, maxPlayerHP);
    }
    // Loads stats from the save.txt
    else if (a == "7")
    {
        // Calls load and saves the returning string array into the string array Stats
        string[] Stats = load();
        // Takes the string array Stats and coverts it into floats using float.parse and saves it into float array floatArray
        float[] floatArray = Array.ConvertAll(Stats, float.Parse);
        // takes the value of floatArray and puts it back into the players stats.
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
        // Updates all the player stats. dont know if still needed as i changed how the stats where saved.
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
    // gives random value from 1 - 100 
    int a = 0;
    a = Random.Shared.Next(1, 101);
    return a;

}
static float normalHit(float playerDMG, float playerHC, float playerCC, float playerCD, float wepondDmg, float wepondCD)
{
    // runns the normal Hit to calc the players damage.
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
static float enemyHit(float enemyHC,float  enemyDMG, Enemy e)
{
    // calculates the damage of the enemy
    int a = 0;
    float b = 0;
    a = random();
    if (a <= e.enemyHC)
    {
        b = e.enemyDMG;
        return b;
    }
    else
    {
        return 0;
    }
}
static float chooseAttack(float playerDMG, float playerHC, float playerCC, float playerCD, Attacks a1, Weponds w)
{
    // chooses an attack currently there is only one.
    float playerTDMG = 0;
    playerTDMG = normalHit(a1.playerDMG, a1.playerHC, a1.playerCC, a1.playerCD, w.wepondDmg, w.wepondCD);
    return playerTDMG;

}
static string[] load()
{
    // Reads all the text in save file located in bin. It saves it into the string array saveStats that is later returned.
    string[] saveStats = File.ReadAllLines(@"save.txt");
    return saveStats;
}
static void Save(float playerHP, float playerDMG, float playerCD, float playerCC, float playerCoins, float playerRegen, float playerLVL, float exp, float enemyKilled, float playerHC, float maxPlayerHP)
{
    // Converts all stats i want to save to strings and puts them in a string array
    string[] saveStats = { playerHP.ToString(), playerDMG.ToString(), playerCD.ToString(), playerCC.ToString(), playerCoins.ToString(), playerRegen.ToString(), playerLVL.ToString(), exp.ToString(), enemyKilled.ToString(), playerHC.ToString(), maxPlayerHP.ToString() };
    // Writes the string array into the text file called save. located somewhere in bin i think.
    File.WriteAllLines(@"save.txt", saveStats);
}
static void UpdateStats(Attacks a1, float playerHC, float playerCC, float playerCD, float playerDMG, Weponds w, float[] floatArray)
{
    a1.playerHC = floatArray[2];
    a1.playerCC = floatArray[4];
    a1.playerCD = floatArray[3] * w.wepondCD;
    a1.playerDMG = floatArray[1] * w.wepondDmg;

}