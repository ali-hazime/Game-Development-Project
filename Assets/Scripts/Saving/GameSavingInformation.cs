using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSavingInformation
{
    //New Game
    public static bool isNewGame;

    //player location
    public static float playerX;
    public static float playerY;
    public static string whereAmI;
    public static string whereWasI;

    //difficulty modifier
    public static int healthMulti;
    public static int bonusHealth;

    //Currency
    public static int crystalsCount;
    public static int minCurrency;
    public static int maxCurrency;

    public static int differenceNumber;

    public static float tempPlayerX;
    public static float tempPlayerY;

    //Rubys
    public static bool ruby1Collected;
    public static bool ruby2Collected;
    public static bool ruby3Collected;
    public static bool ruby4Collected;
    public static bool ruby5Collected;
    public static bool ruby6Collected;
    public static bool ruby7Collected;
    public static bool ruby8Collected;
    public static bool ruby9Collected;
    public static bool ruby10Collected;

    //Sapphires
    public static bool sapphire1Collected;
    public static bool sapphire2Collected;
    public static bool sapphire3Collected;
    public static bool sapphire4Collected;
    public static bool sapphire5Collected;

    //Bonus Effects/Modifiers
    public static float dropChanceModifier;

    //Bosses
    public static bool grassBossDefeated;
    public static bool forestBossDefeated;
    public static bool desertBossDefeated;
    public static bool snowBossDefeated;
    public static bool fireBossDefeated;
    public static bool finalBossDefeated;

    //Grasslands Quests
    public static int cropsInspected;
    public static bool grassQuest1Complete; 
    public static bool grassQuest2Complete; 
    public static bool grassQuest3Complete; 
    public static bool grassQuest4Complete; 
    public static bool grassQuest5Complete;
    public static bool grassQuest6Complete;
    public static bool grassQuest7Complete;

    //Desert Quests
    public static bool desertMazeComplete;
    public static bool desertQuest1Complete;
    public static bool desertQuest2Complete;
    public static bool desertQuest3Complete;
    public static bool desertQuest4Complete;
    public static bool desertQuest5Complete;
    public static bool desertQuest6Complete;

    //Forest Quests
    public static bool forestQuest1Complete; 
    public static bool forestQuest2Complete;
    public static bool forestQuest3Complete;
    public static bool forestQuest4Complete;
    public static bool forestQuest5Complete; 
   
    //Snow Mountain Quests
    public static bool snowQuest1Complete; 
    public static bool snowQuest2Complete;
    public static bool snowQuest3Complete; 


    //Volcano + Final Quests
    public static bool volcanoQuest1Complete; 
    public static bool volcanoQuest2Complete; 
    public static bool volcanoQuest3Complete; 
    public static bool volcanoQuest4Complete; 
    public static bool volcanoQuest5Complete; 
}
