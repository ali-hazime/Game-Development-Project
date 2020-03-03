using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerGameData
{
    //PlayerChar ---
    //Player stuff
    public float[] positionS;
    public int healthS;

    //Currency
    public int crystalsCountS;
    public int minCurrencyS;
    public int maxCurrencyS;

    //Bonus Effects/Modifiers
    public float dropChanceModifierS;

    public PlayerGameData(PlayerChar player)
    {
        healthS = player.playerCurrentHealth;


        positionS = new float[3];
        positionS[0] = player.transform.position.x;
        positionS[1] = player.transform.position.y;
        positionS[2] = player.transform.position.z;

        //Currency
        crystalsCountS = GameSavingInformation.crystalsCount;
        minCurrencyS = GameSavingInformation.minCurrency;
        maxCurrencyS = GameSavingInformation.maxCurrency;

        //Bonus Effects/Modifiers
        dropChanceModifierS = GameSavingInformation.dropChanceModifier;
}
}

public class InfoGameData
{
    /*
    //GameSavingInformation ---
    


    //Bosses
    public bool grassBossDefeatedS;
    public bool forestBossDefeatedS;
    public bool desertBossDefeatedS;
    public bool snowBossDefeatedS;
    public bool fireBossDefeatedS;
    public bool finalBossDefeatedS;

    //Grasslands Quests
    public int cropsInspectedS;
    public bool grassQuest1CompleteS; //Inspect 5 dead crops
    public int townsFolkTalkedToS;
    public bool grassQuest2CompleteS; //Go to the town and speak to 4 people in the town
    public bool grassQuest3CompleteS; //Defend the town
    public bool grassQuest4CompleteS; //Boss Quest
    public bool grassQuest5ACompleteS; //Once player reaches forest
    public bool grassQuest5BCompleteS; //Once player reaches desert

    //Forest Quests
    public bool forestQuest1CompleteS; //Get the NPC to the town
    public bool forestQuest2ACompleteS; //Totem collected from east
    public bool forestQuest2BCompleteS; //Totem collected from southwest
    public bool forestQuest2CCompleteS; //Totem collected from northwest
    public bool forestQuest2CompleteS; //Collected all totems and talked to shaman
    public bool forestQuest3CompleteS; //After escorting shaman to poison
    public bool forestQuest4CompleteS; //Boss Quest
    public bool forestQuest5CompleteS; //Speak to shaman after boss

    //Desert Quests
    public bool desertQuest1CompleteS; //Get to the town
    public bool desertQuest2CompleteS; //Missing townsfolk found
    public bool desertQuest3CompleteS; //Escort the missing townsfolk back to town
    public bool desertQuest4ACompleteS; //Puzzle complete in ancient tombs
    public bool desertQuest4BCompleteS; //Defeat the boss //Boss Quest
    public bool desertQuest5CompleteS; //Return to the town

    //Snow Mountain Quests
    public bool snowQuest1CompleteS; //Return to forest Elder
    public bool snowQuest2CompleteS; //Ascend the snow mountain and make it to the town
    public bool snowQuest3CompleteS; //Make it to the Great Town
    public bool snowQuest4CompleteS; //Defeat the Frozen King //Boss Quest
    public bool snowQuest5CompleteS; //Return & speak to the forest Elder

    //Volcano Quests
    public bool volcanoQuest1CompleteS; //Make it to the mining outpost and speak to miners
    public int minersSpokenToS;
    public bool volcanoQuest2CompleteS; //Speak the 3 miners to gather information
    public bool volcanoQuest3CompleteS; //Ascend the volcano and reach the source of corruption (very top)
    public bool volcanoQuest4CompleteS; //Defeat the boss //Boss Quest
    public bool volcanoQuest5CompleteS; //Inform the head miner the volcano is clear

    //Final Quest
    public bool finalQuest1CompleteS; //Defeat the final boss //Boss Quest
    public bool finalQuest2CompleteS; //Speak to the Elder and complete main quest

    */

    public InfoGameData()
    {
        /*

        //Bosses
        grassBossDefeatedS = GameSavingInformation.grassBossDefeated;
        forestBossDefeatedS = GameSavingInformation.forestBossDefeated;
        desertBossDefeatedS = GameSavingInformation.desertBossDefeated;
        snowBossDefeatedS = GameSavingInformation.snowBossDefeated;
        fireBossDefeatedS = GameSavingInformation.fireBossDefeated;
        finalBossDefeatedS = GameSavingInformation.finalBossDefeated;

        //Grasslands Quests
        cropsInspectedS = GameSavingInformation.cropsInspected;
        grassQuest1CompleteS = GameSavingInformation.grassQuest1Complete;
        townsFolkTalkedToS = GameSavingInformation.townsFolkTalkedTo;
        grassQuest2CompleteS = GameSavingInformation.grassQuest2Complete;
        grassQuest3CompleteS = GameSavingInformation.grassQuest3Complete;
        grassQuest4CompleteS = GameSavingInformation.grassQuest4Complete;
        grassQuest5ACompleteS = GameSavingInformation.grassQuest5AComplete;
        grassQuest5BCompleteS = GameSavingInformation.grassQuest5BComplete;

        //Forest Quests
        forestQuest1CompleteS = GameSavingInformation.forestQuest1Complete;
        forestQuest2ACompleteS = GameSavingInformation.forestQuest2AComplete;
        forestQuest2BCompleteS = GameSavingInformation.forestQuest2BComplete;
        forestQuest2CCompleteS = GameSavingInformation.forestQuest2CComplete;
        forestQuest2CompleteS = GameSavingInformation.forestQuest2Complete;
        forestQuest3CompleteS = GameSavingInformation.forestQuest3Complete;
        forestQuest4CompleteS = GameSavingInformation.forestQuest4Complete;
        forestQuest5CompleteS = GameSavingInformation.forestQuest5Complete;

        //Desert Quests
        desertQuest1CompleteS = GameSavingInformation.desertQuest1Complete;
        desertQuest2CompleteS = GameSavingInformation.desertQuest2Complete;
        desertQuest3CompleteS = GameSavingInformation.desertQuest3Complete;
        desertQuest4ACompleteS = GameSavingInformation.desertQuest4AComplete;
        desertQuest4BCompleteS = GameSavingInformation.desertQuest4BComplete;
        desertQuest5CompleteS = GameSavingInformation.desertQuest5Complete;

        //Snow Mountain Quests
        snowQuest1CompleteS = GameSavingInformation.snowQuest1Complete;
        snowQuest2CompleteS = GameSavingInformation.snowQuest2Complete;
        snowQuest3CompleteS = GameSavingInformation.snowQuest3Complete;
        snowQuest4CompleteS = GameSavingInformation.snowQuest4Complete;
        snowQuest5CompleteS = GameSavingInformation.snowQuest5Complete;

        //Volcano Quests
        volcanoQuest1CompleteS = GameSavingInformation.volcanoQuest1Complete;
        minersSpokenToS = GameSavingInformation.minersSpokenTo;
        volcanoQuest2CompleteS = GameSavingInformation.volcanoQuest2Complete;
        volcanoQuest3CompleteS = GameSavingInformation.volcanoQuest3Complete;
        volcanoQuest4CompleteS = GameSavingInformation.volcanoQuest4Complete;
        volcanoQuest5CompleteS = GameSavingInformation.volcanoQuest5Complete;

        //Final Quest
        finalQuest1CompleteS = GameSavingInformation.finalQuest1Complete;
        finalQuest2CompleteS = GameSavingInformation.finalQuest2Complete;  
        */
    }
}
