using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSavingInformation
{
    //Currency
    public static int crystalsCount;
    public static int minCurrency;
    public static int maxCurrency;

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
    public static bool grassQuest1Complete; //Inspect 5 dead crops
    public static int townsFolkTalkedTo; 
    public static bool grassQuest2Complete; //Go to the town and speak to 4 people in the town
    public static bool grassQuest3Complete; //Defend the town
    public static bool grassQuest4Complete; //Boss Quest
    public static bool grassQuest5AComplete; //Once player reaches forest
    public static bool grassQuest5BComplete; //Once player reaches desert

    //Forest Quests
    public static bool forestQuest1Complete; //Get the NPC to the town
    public static bool forestQuest2AComplete; //Totem collected from east
    public static bool forestQuest2BComplete; //Totem collected from southwest
    public static bool forestQuest2CComplete; //Totem collected from northwest
    public static bool forestQuest2Complete; //Collected all totems and talked to shaman
    public static bool forestQuest3Complete; //After escorting shaman to poison
    public static bool forestQuest4Complete; //Boss Quest
    public static bool forestQuest5Complete; //Speak to shaman after boss

    //Desert Quests
    public static bool desertQuest1Complete; //Get to the town
    public static bool desertQuest2Complete; //Missing townsfolk found
    public static bool desertQuest3Complete; //Escort the missing townsfolk back to town
    public static bool desertQuest4AComplete; //Puzzle complete in ancient tombs
    public static bool desertQuest4BComplete; //Defeat the boss //Boss Quest
    public static bool desertQuest5Complete; //Return to the town

    //Snow Mountain Quests
    public static bool snowQuest1Complete; //Return to forest Elder
    public static bool snowQuest2Complete; //Ascend the snow mountain and make it to the town
    public static bool snowQuest3Complete; //Make it to the Great Town
    public static bool snowQuest4Complete; //Defeat the Frozen King //Boss Quest
    public static bool snowQuest5Complete; //Return & speak to the forest Elder

    //Volcano Quests
    public static bool volcanoQuest1Complete; //Make it to the mining outpost and speak to miners
    public static int minersSpokenTo;
    public static bool volcanoQuest2Complete; //Speak the 3 miners to gather information
    public static bool volcanoQuest3Complete; //Ascend the volcano and reach the source of corruption (very top)
    public static bool volcanoQuest4Complete; //Defeat the boss //Boss Quest
    public static bool volcanoQuest5Complete; //Inform the head miner the volcano is clear

    //Final Quest
    public static bool finalQuest1Complete; //Defeat the final boss //Boss Quest
    public static bool finalQuest2Complete; //Speak to the Elder and complete main quest
}
