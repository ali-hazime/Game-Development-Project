using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public KillObjective killObjective;
    //public CollectObjective collectObjective;
  
    void Start()
    {
        GameSavingInformation.minCurrency = 3;
        GameSavingInformation.maxCurrency = 7;
        InvokeRepeating("UpdateCounters", 0f, 1f);
    }

    public void UpdateCounters()
    {
        killObjective.UpdateKillCount();
        //collectObjective.UpdateItemCount();
    }

    public static void UpdateQuestStatus()
    {
        switch (QuestTracker.grasslandsQuestCount)
        {
            case 0: // Quest 1  
                QuestTracker.isItemQuest = true;
                break;
            case 1: // Quest 2
                QuestTracker.isItemQuest = false;
                GameSavingInformation.grassQuest1Complete = true;
                break;
            case 2: // Quest 3
                QuestTracker.talkToComplete = false;
                QuestTracker.isKillQuest = true;
                GameSavingInformation.grassQuest2Complete = true;
                break;
            case 3: // Quest 4
                QuestTracker.isKillQuest = false;
                GameSavingInformation.grassQuest3Complete = true;
                break;
            case 4: // Quest 5
                QuestTracker.talkToComplete = false;
                GameSavingInformation.grassQuest4Complete = true;
                break;
            case 5: // Quest 6
                QuestTracker.talkToComplete = false;
                GameSavingInformation.grassQuest5Complete = true;
                break;
            case 6: // Quest 7
                QuestTracker.bossKilled = false;
                GameSavingInformation.grassQuest6Complete = true;
                break;
            case 7: // All GL quests completed
                QuestTracker.talkToComplete = false;
                GameSavingInformation.grassQuest7Complete = true;
                QuestTracker.mainQuestCount = 0;
                QuestLog.MyInstance.HideQuests();
                break;
        }

        switch (QuestTracker.desertQuestCount)
        {
            case 0: // Quest 1
                break;
            case 1: // Quest 2
                QuestTracker.talkToComplete = false;
                GameSavingInformation.desertQuest1Complete = true;
                break;
            case 2: // Quest 3
                QuestTracker.talkToComplete = false;
                GameSavingInformation.desertQuest2Complete = true;
                break;
            case 3: // Quest 4
                QuestTracker.escortComplete = false;
                GameSavingInformation.desertQuest3Complete = true;
                break;
            case 4: // Quest 5
                QuestTracker.talkToComplete = false;
                GameSavingInformation.desertQuest4Complete = true;
                break;
            case 5: // Quest 6
                QuestTracker.bossKilled = false;
                GameSavingInformation.desertQuest5Complete = true;
                break;
            case 6: // All desert quests completed
                QuestTracker.talkToComplete = false;
                GameSavingInformation.desertQuest6Complete = true;
                QuestTracker.mainQuestCount = 0;
                QuestLog.MyInstance.HideQuests();
                break;
        }

        switch (QuestTracker.forestQuestCount)
        {
            case 0: // Quest 1
                break;
            case 1: // Quest 2
                QuestTracker.talkToComplete = false;
                QuestTracker.isItemQuest = true;
                GameSavingInformation.forestQuest1Complete = true;
                break;
            case 2: // Quest 3
                QuestTracker.isItemQuest = false;
                QuestTracker.talkToComplete = false;
                GameSavingInformation.forestQuest2Complete = true;
                break;
            case 3: // Quest 4
                QuestTracker.talkToComplete = false;
                GameSavingInformation.forestQuest3Complete = true;
                break;
            case 4: // Quest 5
                QuestTracker.bossKilled = false;
                QuestTracker.talkToComplete = false;
                GameSavingInformation.forestQuest4Complete = true;
                break;
            case 5: // All forest quests complete
                QuestTracker.talkToComplete = false;
                GameSavingInformation.forestQuest5Complete = true;
                QuestTracker.mainQuestCount = 0;
                QuestLog.MyInstance.HideQuests();
                break;
             
        }
        
        switch (QuestTracker.snowMountainQuestCount)
        {
            case 0: // Quest 1
                break;
            case 1: // Quest 2
                QuestTracker.talkToComplete = false;
                GameSavingInformation.snowQuest1Complete = true;
                break;
            case 2: // Quest 3
                QuestTracker.talkToComplete = false;
                GameSavingInformation.snowQuest2Complete = true;
                break;
            case 3: // All snow mountain quests completed
                QuestTracker.bossKilled = false;
                QuestTracker.talkToComplete = false;
                GameSavingInformation.snowQuest3Complete = true;
                QuestLog.MyInstance.HideQuests();
                break;
        }
        
        switch (QuestTracker.volcanoQuestCount)
        {
            case 0: // Quest 1
                break;
            case 1: // Quest 2
                QuestTracker.talkToComplete = false;
                GameSavingInformation.volcanoQuest1Complete = true;
                break;
            case 2: // Quest 3
                QuestTracker.talkToComplete = false;
                GameSavingInformation.volcanoQuest2Complete = true;
                break;
            case 3: // Quest 3
                QuestTracker.bossKilled = false;
                GameSavingInformation.volcanoQuest3Complete = true;
                break;
            case 4: // Quest 4
                QuestTracker.talkToComplete = false;
                GameSavingInformation.volcanoQuest4Complete = true;
                break;
            case 5: // All quests completed
                QuestTracker.bossKilled = false;
                GameSavingInformation.volcanoQuest5Complete = true;
                QuestLog.MyInstance.HideQuests();
                break;
        }
    }
}
