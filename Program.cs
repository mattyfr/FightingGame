using System.Runtime.Serialization;
using System.IO;
using FightingGame;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Security.AccessControl;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
// using devine.intelect;
// start stats
string playerName = "";
string playerPassword = "";
float enemyKilled = 0;
float playerHP = 30;
float maxPlayerHP = 30;
float statPoints = 10;
float playerRegen = 20;
float playerCoins = 0;
float playerLVL = 1;
// booleans needed to be set to a sertain value on start
bool wantToFightEnemy = true;
bool zslayerQuestStarted = false;
bool sslayerQuestStarted = false;
bool wslayerQuestStarted = false;
bool vslayerQuestStarted = false;
bool canFightSlayer = false;
bool alive = true;
// base value for the exp of eatch type
float zexp = 0;
float sexp = 0;
float wexp = 0;
float vexp = 0;
// leveling things 
double dexp = 0;
float exp = (float)dexp;
double dexpNeedForLVL = (playerLVL) * 100;
float expNeedForLVL = (float)dexpNeedForLVL;
// all classes needed
Attacks a1 = new()
{
    playerDMG = 5,
    playerHC = 75,
    playerCC = 15,
    playerCD = 2
};
Enemy e0 = new()
{
    enemyName = "",
    enemyDMG = 0,
    enemyHP = 0,
    enenmyType = "",
    enemyHC = 0
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
Enemy e6 = new()
{
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
Enemy e9 = new()
{
    enemyName = "Revenat Horror",
    enemyDMG = 15,
    enemyHP = 125,
    enemyHC = 99,
    enenmyType = "zombie"
};
Enemy e10 = new()
{
    enemyName = "Tarantula Broodfather",
    enemyDMG = 17,
    enemyHP = 175,
    enemyHC = 99,
    enenmyType = "spider"
};
Enemy e11 = new()
{
    enemyName = "Sven Packmaster",
    enemyDMG = 31,
    enemyHC = 85,
    enemyHP = 200,
    enenmyType = "wolf"
};
Enemy e12 = new()
{
    enemyName = "Voidgloom Seraph",
    enemyDMG = 100,
    enemyHC = 99,
    enemyHP = 325,
    enenmyType = "vamp"
};
Weponds w0 = new()
{
    wepondName = "None",
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
// some lists one for eatch mob type
List<Enemy> zlist = [e1, e2, e3];
List<Enemy> slist = [e4, e5];
List<Enemy> wlist = [e6, e7];
List<Enemy> vlist = [e8];
// selects an empty enemy in the start (gets changed before first fight)
Enemy e = e0;
// selects empty wepond in the start
Weponds w = w0;
// defines some variables later used to for combat
float playerHC = a1.playerHC;
float playerCC = a1.playerCC;
float playerCD = a1.playerCD * w.wepondCD;
float playerDMG = a1.playerDMG * w.wepondDmg;
// same as for player
float enemyStartHP = e.enemyHP;
float enemyDMG = e.enemyDMG;
float enemyHC = e.enemyHC;
float enemyHP = e.enemyHP;
string enemyName = e.enemyName;
// 
int[] maxBuy = { 0, 0, 0, };
// On start
Print("Do you want to make a new profile or load a old one\n 1: Make new \n 2: Load old", 120);
string d = Console.ReadLine();
if (d == "1")
{
    Print("Enter username", 100);
    playerName = Console.ReadLine();
    Print("Enter password or press enter if you dont want a password", 120);
    playerPassword = sha256hashing(Console.ReadLine());
}
else if (d == "2")
{
    LoadsStats(playerHP, a1, playerCoins, playerRegen, playerLVL, exp, enemyKilled, maxPlayerHP, playerName);
}
// defines the boolean value that starts the game
bool openMenu = true;
// The game
while (openMenu)
{
    // clears console to remove pervius messeges
    Console.Clear();
    // ascii art + the menu showing the plater what they can do 
    Console.WriteLine(@" _   .-')       ('-.        .-') _               
( '.( OO )_   _(  OO)      ( OO ) )              
 ,--.   ,--.)(,------. ,--./ ,--,'   ,--. ,--.   
 |   `.'   |  |  .---' |   \ |  |\   |  | |  |   
 |         |  |  |     |    \|  | )  |  | | .-') 
 |  |'.'|  | (|  '--.  |  .     |/   |  |_|( OO )
 |  |   |  |  |  .--'  |  |\    |    |  | | `-' /
 |  |   |  |  |  `---. |  | \   |   ('  '-'(_.-' 
 `--'   `--'  `------' `--'  `--'     `-----'    ");
    Print($"\n Type the number based on the action you want to do. \n 1. View stats \n 2. Spend skill points \n 3. Fight an enemy \n 4. Start a boss quest \n 5. Open shop \n 6. Save \n 7. Load a save \n 8. Reset the save file", 100);
    string a = Console.ReadLine();
    // view stats 
    if (a == "1")
    {
        // prints out most of the players stats
        Print($"HP:{playerHP}\nDamage:{a1.playerDMG}\nHit Chance:{a1.playerHC}\nCrit Damage:{a1.playerCD}\nCrit Chance{a1.playerCC}\nCoins:{playerCoins}\nRegen:{playerRegen}\nYour current sword is {w.wepondName}", 200);
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
        Console.ReadLine();
    }
    // Fights a random enenmy
    else if (a == "3")
    {
        // sets variable to true so the player can go back to fighting enemys after exiting 
        wantToFightEnemy = true;
        // the while loop that enemy are picked in and fights happen
        while (wantToFightEnemy)
        {
            // gives alternatives for enemys to fight
            Print($"What typer of enemy do you want to fight \n 1. Zombie \n 2. Sprider \n 3. Wolf \n 4. Vampire\n", 350);
            // Incase player has a slayer quest active than might run one of these
            if (zslayerQuestStarted)
            {
                if (zexp > 250)
                {
                    Print($"5. Fight boss", 100);
                    canFightSlayer = true;
                }
            }
            else if (sslayerQuestStarted)
            {
                if (sexp > 250)
                {
                    Print($"5. Fight boss", 100);
                    canFightSlayer = true;
                }
            }
            else if (wslayerQuestStarted)
            {
                if (wexp > 250)
                {
                    Print($"5. Fight boss", 100);
                    canFightSlayer = true;
                }
            }
            else if (vslayerQuestStarted)
            {
                if (vexp > 250)
                {
                    Print($"5. Fight boss", 100);
                    canFightSlayer = true;
                }
            }
            // defines the string that player input gets put in than checks if its falue is equal to any alternative. if it is than it selects a random enemy from that type.
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
            else if (c == "5")
            {
                if (canFightSlayer)
                {
                    if (zslayerQuestStarted)
                    {
                        e = e9;
                        zslayerQuestStarted = false;

                    }
                    else if (sslayerQuestStarted)
                    {
                        e = e10;
                        sslayerQuestStarted = false;
                    }
                    else if (wslayerQuestStarted)
                    {
                        e = e11;
                        wslayerQuestStarted = false;

                    }
                    else if (vslayerQuestStarted)
                    {
                        e = e12;
                        vslayerQuestStarted = false;
                    }

                }
            }
            // sets the chosen enemys stats into the enemy stats 
            enemyHC = e.enemyHC;
            enemyDMG = e.enemyDMG;
            enemyHP = e.enemyHP;
            // if both enemy and player have hp this runs. it just calculates dmg from both player and enemy than subtrackts this from the others hp.
            while (playerHP > 0 && enemyHP > 0 && wantToFightEnemy)
            {
                float playerTDMG = 0;
                float enemyTDMG = 0;
                // playerTDMG = playerHit(playerDMG, playerHC, playerCC, playerCD);
                playerTDMG = chooseAttack(a1.playerDMG, a1.playerHC, a1.playerCC, a1.playerCD, a1, w, e);
                enemyTDMG = enemyHit(enemyHC, enemyDMG, e);
                playerHP -= enemyTDMG;
                enemyHP -= playerTDMG;
                Print($"{playerName} hp:{playerHP} \n{e.enemyName} hp:{enemyHP}", 300);
                //    int playerDMG, int playerHC, int playerCC, int play
            }
            // runs if player dies
            if (playerHP <= 0)
            {
                Print("You Died", 500);
                alive = false;
                openMenu = false;
                Console.ReadLine();
                break;
            }
            // runs if enemy dies
            else if (enemyHP <= 0)
            {
                // gives player the reward for killing the enemy
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
                Print($"{playerName} won!!", 500);
                Print($"{playerName} regenerated {playerRegen} hp", 450);
                // gives player a levelup incase level is high enught
                if (exp > expNeedForLVL)
                {
                    exp -= expNeedForLVL;
                    playerLVL += 1;
                    statPoints += 3;
                    playerCoins += 100;
                    Print($"You leveled up to level {playerLVL} and recived 100 coins and 3 skill points. \nGet {expNeedForLVL} more exp to level up again", 350);
                }
                // asks player if they want to kill another mob if yes than goes back to chose enemy
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
    // Starts a boss quest  
    else if (a == "4")
    {
        // lets player pick slayer quest
        Print($"What slayer quest do you want to start\n1. Zombie \n2. Spider\n3. Wolf\n4. Vampire", 200);
        string b = Console.ReadLine();
        if (b == "1")
        {
            zslayerQuestStarted = true;
            zexp = 0;
        }
        else if (b == "2")
        {
            sslayerQuestStarted = true;
            sexp = 0;
        }
        else if (b == "3")
        {
            wslayerQuestStarted = true;
            wexp = 0;
        }
        else if (b == "4")
        {
            vslayerQuestStarted = true;
            vexp = 0;
        }
    }
    // Opens the shop menu
    else if (a == "5")
    {
        // lets player buy stats and swords
        Print($"Shop\nYou can only buy the upgrades 5 times\n You have {playerCoins} \n1. +2 HP cost 10 coin\n 2. +5 DMG cost 10 coin\n 3. +5 Hit Chance cost 10 coin\n 4. Halberd Of The Shreadded cost 100 coin\n 5. Sting cost 100 coin \n 6. Pooch Swrod cost 100 coin \n 7. Atomsplit Kataana cost 100 coin \n 8. Gamble", 650);
        string ShopDesition = Console.ReadLine();
        if (ShopDesition == "1")
        {
            if (playerCoins > 10 && maxBuy[0] < 5)
            {
                maxPlayerHP += 2;
                playerHP += 2;
                maxBuy[0] += 1;
                playerCoins -= 10;
                Print($"You bought Player HP upgrade {maxBuy[0]}/5", 100);
                Thread.Sleep(333);
            }
            if (maxBuy[0] >= 5)
            {
                Print("You reached max buy already", 120);
                Console.ReadKey();
            }

        }
        else if (ShopDesition == "2")
        {
            if (playerCoins > 10 && maxBuy[1] < 5)
            {
                a1.playerDMG += 5;
                maxBuy[1] += 1;
                playerCoins -= 10;
                Print($"You bought Player Dmg upgrade {maxBuy[1]}/5", 100);
                Thread.Sleep(333);
            }
            if (maxBuy[1] >= 5)
            {
                Print("You reached max buy already", 120);
                Console.ReadKey();
            }
        }
        else if (ShopDesition == "3")
        {
            if (playerCoins > 10 && maxBuy[2] < 5)
            {
                a1.playerHC += 5;
                playerCoins -= 10;
                maxBuy[2] += 1;
                Print($"You bought Player Hit chance upgrade {maxBuy[2]}/5", 100);
                Thread.Sleep(333);
            }
            if (maxBuy[2] >= 5)
            {
                Print("You reached max buy already", 120);
                Console.ReadKey();
            }
        }
        else if (ShopDesition == "4")
        {
            if (playerCoins > 100)
            {
                w = w1;
                playerCoins -= 100;
                Print($"You now have {w.wepondName} equiped", 125);
                Thread.Sleep(333);
            }
        }
        else if (ShopDesition == "5")
        {
            if (playerCoins > 100)
            {
                w = w2;
                playerCoins -= 100;
                Print($"You now have {w.wepondName} equiped", 125);
                Thread.Sleep(333);
            }
        }
        else if (ShopDesition == "6")
        {
            if (playerCoins > 100)
            {
                w = w3;
                playerCoins -= 100;
                Print($"You now have {w.wepondName} equiped", 125);
                Thread.Sleep(333);
            }
        }
        else if (ShopDesition == "7")
        {
            if (playerCoins > 100)
            {
                w = w4;
                playerCoins -= 100;
                Print($"You now have {w.wepondName} equiped", 125);
                Thread.Sleep(333);
            }

        }
        else if (ShopDesition == "8")
        {
            bool wantToBuyMore = true;
            int wantAutoBuy = 0;
            while (wantToBuyMore)
            {
                if (playerCoins > 100)
                {
                    string gambleResult = Gamble();
                    playerCoins -= 100;
                    if (gambleResult == "loss")
                    {
                        Print(File.ReadAllText("gambling screens\\31.txt"), 0);
                        Thread.Sleep(1000);
                        Console.Clear();
                        Print(File.ReadAllText("gambling screens\\32.txt"), 0);
                        Thread.Sleep(1000);
                        Console.Clear();
                        Print(File.ReadAllText("gambling screens\\33.txt"), 0);
                        Print("You lost", 100);
                    }
                    else if (gambleResult == "small win")
                    {
                        Print(File.ReadAllText("gambling screens\\1.txt"), 0);
                        Thread.Sleep(1000);
                        Console.Clear();
                        Print(File.ReadAllText("gambling screens\\2.txt"), 0);
                        Thread.Sleep(1000);
                        Console.Clear();
                        Print(File.ReadAllText("gambling screens\\3.txt"), 0);
                        playerCoins += 150;
                        Print("You won 150 coins", 150);
                    }
                    else if (gambleResult == "medium win")
                    {
                        Print(File.ReadAllText("gambling screens\\11.txt"), 0);
                        Thread.Sleep(1000);
                        Console.Clear();
                        Print(File.ReadAllText("gambling screens\\12.txt"), 0);
                        Thread.Sleep(1000);
                        Console.Clear();
                        Print(File.ReadAllText("gambling screens\\13.txt"), 0);
                        playerCoins += 250;
                        Print("You won 250 coins", 150);
                    }
                    else if (gambleResult == "huge win")
                    {
                        Print(File.ReadAllText("gambling screens\\21.txt"), 0);
                        Thread.Sleep(320);
                        Console.Clear();
                        Print(File.ReadAllText("gambling screens\\22.txt"), 0);
                        Thread.Sleep(320);
                        Console.Clear();
                        Print(File.ReadAllText("gambling screens\\23.txt"), 0);
                        playerDMG += 15000;
                        Print("You won 15000 coins", 150);
                    }
                    wantAutoBuy--;
                    if (wantAutoBuy < 1)
                    {
                        Print("Do you whant to buy another gamble \n 1: Yes\n 2: No\n 3: AutoBuy", 120);
                        a = Console.ReadLine();
                        if (a == "1")
                        {

                        }
                        else if (a == "2")
                        {
                            wantToBuyMore = false;
                        }
                        else if (a == "3")
                        {
                            Print("How many whould you like to auto buy", 120);
                            string c = Console.ReadLine();
                            wantAutoBuy = Convert.ToInt32(c);
                        }
                    }
                }
                else if (playerCoins < 100)
                {
                    wantToBuyMore = false;
                }
            }
        }

    }
    // Saves most stats 
    else if (a == "6")
    {
        // Calls Save
        Save(playerHP, playerDMG, playerCD, playerCC, playerCoins, playerRegen, playerLVL, exp, enemyKilled, playerHC, maxPlayerHP);
        usernameSave(playerName, playerPassword);
    }
    // Loads stats from the save.txt
    else if (a == "7")
    {
        LoadsStats(playerHP, a1, playerCoins, playerRegen, playerLVL, exp, enemyKilled, maxPlayerHP, playerName);
    }
    //  Reset stats 
    else if (a == "8")
    {
        Print("Are you sure you want to reset your save file? \n 1. Yes \n 2. No", 200);
        string b = Console.ReadLine();
        if (b == "1")
        {
            string[] resetSave = { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
            File.WriteAllLines(@"save.txt", resetSave);
        }
        else
        {
            
        }
    }
}
if (alive == false)
{
    Print("You died you save file is now being destroyed XaXaXaXa", 450);
    string[] resetSave = { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
    File.WriteAllLines(@"save.txt", resetSave);
    Console.ReadLine();
}
static void Print(string a, int time)
{
    // i = 0 och sätts sedan till längden på det som ska printas 
    for (int i = 0; i < a.Length; i++)
    {
        // skriver en bokstav 
        Console.Write(a[i]);
        // väntar tiden delat på längden
        Thread.Sleep(time / a.Length);
        // så att den hoppar över mellanslag
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
    // gives random value from 1 - 10000 
    int a = Random.Shared.Next(1, 10001);
    return a;
}
static float normalHit(float playerDMG, float playerHC, float playerCC, float playerCD, float wepondDmg, float wepondCD, Enemy e, Weponds w)
{
    // runns the normal Hit to calc the players damage.
    float a = 1;
    if (e.enenmyType == w.wepondStrength)
    {
        a = 2;
    }
    if (random() / 100 <= playerHC)
    {
        if (random() / 100 <= playerCC)
        {
            Print("Crit!", 120);
            Print($"{playerDMG * a}", 120);
            return playerDMG * playerCD * a;
        }
        else
        {
            Print($"{playerDMG * a}", 120);
            return playerDMG * a;
        }
    }
    else
    {
        return 0;
    }
}
static float enemyHit(float enemyHC, float enemyDMG, Enemy e)
{
    // calculates the damage of the enemy
    if (random() / 100 <= e.enemyHC)
    {
        float a = e.enemyDMG;
        return a;
    }
    else
    {
        return 0;
    }
}
static float chooseAttack(float playerDMG, float playerHC, float playerCC, float playerCD, Attacks a1, Weponds w, Enemy e)
{
    // chooses an attack currently there is only one.
    float playerTDMG = normalHit(a1.playerDMG, a1.playerHC, a1.playerCC, a1.playerCD, w.wepondDmg, w.wepondCD, e, w);
    return playerTDMG;
}
static string[] loadStats()
{
    // Checks if file exists 
    if (File.Exists(@"save.txt"))
    {
        // If save file exists saves the string array and returns it.
        string[] saveStats = File.ReadAllLines(@"save.txt");
        return saveStats;
    }
    else
    {
        // If the file dosent exist it creates one and closes it than dose same as if it exists
        var statsFolder = File.Create(@"save.txt");
        statsFolder.Close();
        string[] saveStats = File.ReadAllLines(@"save.txt");
        return saveStats;
    }
}
static string[] usernameLoad()
{
    if (File.Exists(@"UsernameSave"))
    {
        string[] usernameSave = File.ReadAllLines(@"UsernameSave");
        return usernameSave;
    }
    else
    {
        var usernameSaveFile = File.Create(@"UsernameSave");
        usernameSaveFile.Close();
        string[] usernameSave = File.ReadAllLines(@"UsernameSave");
        return usernameSave;
    }
}
static void usernameSave(string playerName, string playerPassword)
{
    string[] usernameData = { playerName, playerPassword };
    if (File.Exists(@"UsernameSave"))
    {
        File.WriteAllLines(@"UsernameSave", usernameData);
    }
    else
    {
        var usernameSaveFile = File.Create(@"UsernameSave");
        usernameSaveFile.Close();
        File.WriteAllLines(@"UsernameSave", usernameData);
    }
}
static void Save(float playerHP, float playerDMG, float playerCD, float playerCC, float playerCoins, float playerRegen, float playerLVL, float exp, float enemyKilled, float playerHC, float maxPlayerHP)
{
    // Converts all stats i want to save to strings and puts them in a string array
    string[] saveStats = { playerHP.ToString(), playerDMG.ToString(), playerCD.ToString(), playerCC.ToString(), playerCoins.ToString(), playerRegen.ToString(), playerLVL.ToString(), exp.ToString(), enemyKilled.ToString(), playerHC.ToString(), maxPlayerHP.ToString() };
    // Writes the string array into the text file called save. located somewhere in bin i think.
    if (File.Exists(@"save.txt"))
    {
        File.WriteAllLines(@"save.txt", saveStats);
    }
    else
    {
        var statsFolder = File.Create(@"save.txt");
        statsFolder.Close();
        File.WriteAllLines(@"save.txt", saveStats);
    }
}
static string Gamble()
{
    int roll = random();
    if (roll < 5000)
    {
        return "loss";
    }
    else if (5001 < roll && roll < 9001)
    {
        return "small win";
    }
    else if (roll < 9990 && roll < 9999)
    {
        return "medium win";
    }
    else if (roll < 9999)
    {
        return "huge win";
    }
    else
    {
        return "error with gamble";
    }
}
static string sha256hashing(string input)
{
    using (SHA256 sha256Hash = SHA256.Create())
    {
        byte[] byteArray = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder builder = new StringBuilder();
        foreach (byte b in byteArray)
        {
            builder.Append(b.ToString("x2"));
        }
        string hash = builder.ToString();
        return hash;
    }
}
static void LoadsStats(float playerHP, Attacks a1, float playerCoins, float playerRegen, float playerLVL, float exp, float enemyKilled, float maxPlayerHP, string playerName)
{
    // Calls load and saves the returning string array into the string array Stats
    string[] Stats = loadStats();
    string[] UsernameInfo = usernameLoad();
    // Takes the string array Stats and coverts it into floats using float.parse and saves it into float array floatArray
    float[] floatArray = Array.ConvertAll(Stats, float.Parse);
    Print("Enter password. If you dont have a password just press enter", 120);
    if (UsernameInfo[1] == sha256hashing(Console.ReadLine()))
    {
        // takes the value of floatArray and puts it back into the players stats.
        playerHP = (floatArray[0]);
        a1.playerDMG = (floatArray[1]);
        a1.playerCD = (floatArray[2]);
        a1.playerCC = (floatArray[3]);
        playerCoins = (floatArray[4]);
        playerRegen = (floatArray[5]);
        playerLVL = (floatArray[6]);
        exp = (floatArray[7]);
        enemyKilled = (floatArray[8]);
        a1.playerHC = (floatArray[9]);
        maxPlayerHP = (floatArray[10]);
        playerName = UsernameInfo[0];
    }
    else
    {
        Print("Wrong password", 120);
        Console.ReadKey();
        System.Environment.Exit(1);
    }
}