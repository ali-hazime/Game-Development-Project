using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [SerializeField] string title;
    [SerializeField] string description;

    [SerializeField] CollectObjective[] collectObjectives;
    [SerializeField] KillObjective[] killObjectives;
    [SerializeField] KillBoss[] killBosses;
    [SerializeField] EscortQuest[] escortQuests;
    [SerializeField] TalkToQuest[] talkToQuests;
    public QuestScript MyQuestScript { get; set; }

    public string QTitle
    {
        get
        {
            return title;
        }

        set
        {
            title = value;
        }
    }

    public string QDescription
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }

    public CollectObjective[] MyCollectObjectives
    {
        get
        {
            return collectObjectives;
        }
    }
    public KillObjective[] MyKillObjectives
    {
        get
        {
            return killObjectives;
        }
    }

    public KillBoss[] MyKillBosses
    {
        get
        {
            return killBosses;
        }
    }

    public EscortQuest[] MyEscortQuests
    {
        get
        {
            return escortQuests;
        }
    }

    public TalkToQuest[] MyTalkToQuests
    {
        get
        {
            return talkToQuests;
        }
    }
    public bool IsComplete
    {
        get
        {
            foreach (Objective o in collectObjectives)
            {
                if (!o.IsComplete)
                {
                    return false;
                }
            }

            foreach (Objective o in killObjectives)
            {
                if (!o.IsComplete)
                {
                    return false;
                }
            }

            foreach (Objective o in killBosses)
            {
                if (!o.IsComplete)
                {
                    return false;
                }
            }

            foreach (Objective o in escortQuests)
            {
                if (!o.IsComplete)
                {
                    return false;
                }
            }

            foreach (Objective o in talkToQuests)
            {
                if (!o.IsComplete)
                {
                    return false;
                }
            }

            return true;
        }
    }


}

[System.Serializable]
public abstract class Objective
{
    [SerializeField] int amount;
    [SerializeField] int currentAmount;
    [SerializeField] string type;
    //public int myCurrentAmount;

    public int MyAmount
    {
        get
        {
            return amount;
        }
    }

    /*
    public int MyCurrentAmount
    {
        get
        {
            return currentAmount;
        }

        set
        {
            currentAmount = value;
        }
    }
  */
    public string MyType
    {
        get
        {
            return type;
        }
    }

    public bool IsComplete
    {
        get
        {
            
            if (QuestTracker.isKillQuest)
            {
                return QuestTracker.killCount >= MyAmount;
            }
            else if (QuestTracker.isItemQuest)
            {
                return QuestTracker.itemCount >= MyAmount;
            }
            else if (QuestTracker.bossKilled)
            {
                return QuestTracker.bossKilled;
            }

            else if (QuestTracker.escortComplete)
            {
                return QuestTracker.escortComplete;
            }

            else if (QuestTracker.talkToComplete)
            {
                return QuestTracker.talkToComplete;
            }

            return false;

            //return MyCurrentAmount >= MyAmount;
            
        }
    }
}

[System.Serializable]
public class CollectObjective : Objective
{
    public void UpdateItemCount()
    {
        //MyCurrentAmount = QuestTracker.itemCount;
        //MyCurrentAmount++;
        QuestTracker.itemCount++;
        QuestLog.MyInstance.UpdateSelected();
        QuestLog.MyInstance.CheckCompletion();
        //Debug.Log("Item Amount: " + MyCurrentAmount);
    }
}

[System.Serializable]
public class KillObjective : Objective
{
    public void UpdateKillCount()
    {
        //MyCurrentAmount = QuestTracker.killCount;
        //currentAmount = QuestTracker.killCount;
        QuestLog.MyInstance.UpdateSelected();
        QuestLog.MyInstance.CheckCompletion();
        //Debug.Log("Kill count: " + MyCurrentAmount);
    }
}

[System.Serializable]
public class KillBoss : Objective
{
    public void UpdateBossStatus()
    {
        GameSavingInformation.grassBossDefeated = true;
        QuestTracker.bossKilled = true;
        QuestLog.MyInstance.UpdateSelected();
        QuestLog.MyInstance.CheckCompletion();
    }
}

[System.Serializable]
public class EscortQuest : Objective
{
    public void UpdateEscortQuest ()
    {
        QuestTracker.escortComplete = true;
        QuestLog.MyInstance.UpdateSelected();
        QuestLog.MyInstance.CheckCompletion();
    }
}

[System.Serializable]
public class TalkToQuest : Objective
{
    public void UpdateTalkToQuest()
    {
        QuestTracker.talkToComplete = true;
        QuestLog.MyInstance.UpdateSelected();
        QuestLog.MyInstance.CheckCompletion();
    }
}
