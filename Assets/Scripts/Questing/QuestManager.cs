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
            case 0:
                QuestTracker.isKillQuest = true;
                break;
            case 1:
                QuestTracker.isKillQuest = true;
                GameSavingInformation.grassQuest1Complete = true;
                break;
            case 2:
                QuestTracker.isItemQuest = true;
                QuestTracker.isKillQuest = false;
                GameSavingInformation.grassQuest2Complete = true;
                break;
            case 3:
                QuestTracker.isItemQuest = false;
                GameSavingInformation.grassQuest3Complete = true;
                break;
            case 4:
                QuestTracker.bossKilled = false; //may have to be moved
                GameSavingInformation.grassQuest4Complete = true;
                break;
            case 5:
                GameSavingInformation.grassQuest5AComplete = true;
                break;
            case 6:
                GameSavingInformation.grassQuest5BComplete = true;
                QuestLog.MyInstance.HideQuests(); //maybe place this somewhere else? when player enters next zone scene?
                //temp until i find a better way (see QuestScript)
                QuestTracker.desertQuestCount = 0;
                QuestTracker.forestQuestCount = 0;
                QuestTracker.snowMountainQuestCount = 0;
                QuestTracker.volcanoQuestCount = 0;
                break;
        }
    }
}
