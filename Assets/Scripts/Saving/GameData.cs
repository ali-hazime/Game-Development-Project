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

[System.Serializable]
public class QuestInfo
{
    public bool questInProgressS;
    public bool bossKilledS;
    public bool isKillQuestS;
    public bool isItemQuestS;
    public bool escortCompleteS;
    public bool talkToCompleteS;
    public bool beginDesertQ3S;
    public bool allTotemsCollectedS;
    public bool allObjCompletedS;

    public int killCountS;
    public int itemCountS;

    public int mainQuestCountS;
    public string questTypeS;
    public int grasslandsQuestCountS;
    public int desertQuestCountS;
    public int forestQuestCountS;
    public int snowMountainQuestCountS;
    public int volcanoQuestCountS;

    //Quest Item Bools

    public bool q1_Item1S;
    public bool q1_Item2S;
    public bool q1_Item3S;

    public bool fQ2_Item1S;
    public bool fQ2_Item2S;
    public bool fQ2_Item3S;

    public QuestInfo()
    { 
        questInProgressS = QuestTracker.questInProgress;
        bossKilledS = QuestTracker.bossKilled;
        isKillQuestS = QuestTracker.isKillQuest;
        isItemQuestS = QuestTracker.isItemQuest;
        escortCompleteS = QuestTracker.escortComplete;
        talkToCompleteS = QuestTracker.talkToComplete;
        beginDesertQ3S = QuestTracker.beginDesertQ3;
        allTotemsCollectedS = QuestTracker.allTotemsCollected;
        allObjCompletedS = QuestTracker.allObjCompleted;

        killCountS = QuestTracker.killCount;
        itemCountS = QuestTracker.itemCount;

        mainQuestCountS = QuestTracker.mainQuestCount;
        questTypeS = QuestTracker.questType;
        grasslandsQuestCountS = QuestTracker.grasslandsQuestCount;
        desertQuestCountS = QuestTracker.desertQuestCount;
        forestQuestCountS = QuestTracker.forestQuestCount;
        snowMountainQuestCountS = QuestTracker.snowMountainQuestCount;
        volcanoQuestCountS = QuestTracker.volcanoQuestCount;

        q1_Item1S = QuestTracker.q1_Item1;
        q1_Item2S = QuestTracker.q1_Item2;
        q1_Item3S = QuestTracker.q1_Item3;

        fQ2_Item1S = QuestTracker.fQ2_Item1;
        fQ2_Item2S = QuestTracker.fQ2_Item2;
        fQ2_Item3S = QuestTracker.fQ2_Item3;
    }
}

[System.Serializable]
public class InfoGameData
{
    public bool isNewGameS;

    //GameSavingInformation ---//
    public float playerXS;
    public float playerYS;
    public string whereAmIS;
    public string whereWasIS;

    //Bosses
    public bool grassBossDefeatedS;
    public bool forestBossDefeatedS;
    public bool desertBossDefeatedS;
    public bool snowBossDefeatedS;
    public bool fireBossDefeatedS;
    public bool finalBossDefeatedS;

    //Grasslands Quests
    public bool grassQuest1CompleteS; //Inspect 5 dead crops
    public bool grassQuest2CompleteS; //Go to the town and speak to 4 people in the town
    public bool grassQuest3CompleteS; //Defend the town
    public bool grassQuest4CompleteS; //Boss Quest
    public bool grassQuest5CompleteS; //Once player reaches desert
    public bool grassQuest6CompleteS; //Boss Quest
    public bool grassQuest7CompleteS; //Once player reaches desert

    //Forest Quests
    public bool forestQuest1CompleteS; //Get the NPC to the town
    public bool forestQuest2CompleteS; //Collected all totems and talked to shaman
    public bool forestQuest3CompleteS; //After escorting shaman to poison
    public bool forestQuest4CompleteS; //Boss Quest
    public bool forestQuest5CompleteS; //Speak to shaman after boss

    //Desert Quests
    public bool desertQuest1CompleteS; //Get to the town
    public bool desertQuest2CompleteS; //Missing townsfolk found
    public bool desertQuest3CompleteS; //Escort the missing townsfolk back to town
    public bool desertQuest4CompleteS; //Puzzle complete in ancient tombs
    public bool desertQuest5CompleteS; //Defeat the boss //Boss Quest
    public bool desertQuest6CompleteS; //Return to the town

    //Snow Mountain Quests
    public bool snowQuest1CompleteS; 
    public bool snowQuest2CompleteS; 
    public bool snowQuest3CompleteS; 

    //Volcano Quests
    public bool volcanoQuest1CompleteS; 
    public bool volcanoQuest2CompleteS; 
    public bool volcanoQuest3CompleteS; 
    public bool volcanoQuest4CompleteS; 
    public bool volcanoQuest5CompleteS; 

    public InfoGameData()
    {
        isNewGameS = GameSavingInformation.isNewGame;
        playerXS = GameSavingInformation.playerX;
        playerYS = GameSavingInformation.playerY;
        whereAmIS = GameSavingInformation.whereAmI;
        whereWasIS = GameSavingInformation.whereWasI;

        //Bosses
        grassBossDefeatedS = GameSavingInformation.grassBossDefeated;
        forestBossDefeatedS = GameSavingInformation.forestBossDefeated;
        desertBossDefeatedS = GameSavingInformation.desertBossDefeated;
        snowBossDefeatedS = GameSavingInformation.snowBossDefeated;
        fireBossDefeatedS = GameSavingInformation.fireBossDefeated;
        finalBossDefeatedS = GameSavingInformation.finalBossDefeated;

        //Grasslands Quests
        grassQuest1CompleteS = GameSavingInformation.grassQuest1Complete;
        grassQuest2CompleteS = GameSavingInformation.grassQuest2Complete;
        grassQuest3CompleteS = GameSavingInformation.grassQuest3Complete;
        grassQuest4CompleteS = GameSavingInformation.grassQuest4Complete;
        grassQuest5CompleteS = GameSavingInformation.grassQuest5Complete;
        grassQuest6CompleteS = GameSavingInformation.grassQuest6Complete;
        grassQuest7CompleteS = GameSavingInformation.grassQuest7Complete;

        //Forest Quests
        forestQuest1CompleteS = GameSavingInformation.forestQuest1Complete;
        forestQuest2CompleteS = GameSavingInformation.forestQuest2Complete;
        forestQuest3CompleteS = GameSavingInformation.forestQuest3Complete;
        forestQuest4CompleteS = GameSavingInformation.forestQuest4Complete;
        forestQuest5CompleteS = GameSavingInformation.forestQuest5Complete;

        //Desert Quests
        desertQuest1CompleteS = GameSavingInformation.desertQuest1Complete;
        desertQuest2CompleteS = GameSavingInformation.desertQuest2Complete;
        desertQuest3CompleteS = GameSavingInformation.desertQuest3Complete;
        desertQuest4CompleteS = GameSavingInformation.desertQuest4Complete;
        desertQuest5CompleteS = GameSavingInformation.desertQuest5Complete;
        desertQuest6CompleteS = GameSavingInformation.desertQuest6Complete;

        //Snow Mountain Quests
        snowQuest1CompleteS = GameSavingInformation.snowQuest1Complete;
        snowQuest2CompleteS = GameSavingInformation.snowQuest2Complete;
        snowQuest3CompleteS = GameSavingInformation.snowQuest3Complete;

        //Volcano Quests
        volcanoQuest1CompleteS = GameSavingInformation.volcanoQuest1Complete;
        volcanoQuest2CompleteS = GameSavingInformation.volcanoQuest2Complete;
        volcanoQuest3CompleteS = GameSavingInformation.volcanoQuest3Complete;
        volcanoQuest4CompleteS = GameSavingInformation.volcanoQuest4Complete;
        volcanoQuest5CompleteS = GameSavingInformation.volcanoQuest5Complete;

    }
}
/*
[System.Serializable]
public class QuestData
{

    public List<QuestData> MyQuestData { get; set; }

    public string QTitle { get; set; }

    public string QDescription { get; set; }

    public CollectObjective[] MyCollectObjectives { get; set; }

    public KillObjective[] MyKillObjectives { get; set; }

    public KillBoss[] MyKillBosses { get; set; }

    public EscortQuest[] MyEscortQuests { get; set; }

    public TalkToQuest[] MyTalkToQuests { get; set; }



    public QuestData(string title, string description, CollectObjective[] collectObjectives, KillObjective[] killObjectives, KillBoss[] killBosses, EscortQuest[] escortQuests, TalkToQuest[] talkToQuests)
    {
        QTitle = title;

        QDescription = description;

        MyCollectObjectives = collectObjectives;

        MyKillObjectives = killObjectives;

        MyKillBosses = killBosses;

        MyEscortQuests = escortQuests;

        MyTalkToQuests = talkToQuests;
    }
}
*/
