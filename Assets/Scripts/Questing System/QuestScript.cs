using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestScript : MonoBehaviour
{

    public Quest MyQuest { get; set; }
    public bool markedComplete = false;

    public void Select()
    {
        GetComponent<Text>().color = Color.cyan;
        QuestLog.MyInstance.ShowDescription(MyQuest);
    }

    public void DeSelect()
    {
        GetComponent<Text>().color = Color.white;
    }

    public void IsComplete()
    {
        if (!QuestTracker.allObjCompleted)
        {
            return;
        }
        if (MyQuest.IsComplete && !markedComplete)
        { 
            markedComplete = true;
            GetComponent<Text>().text += "\n(Quest Completed)";
            QuestTracker.questInProgress = false;
            StartCoroutine(WaitSomeTime());
            QuestLog.MyInstance.EndQuest();
            QuestTracker.mainQuestCount++;

            if (QuestTracker.grasslandsQuestCount < 7)
            {
                QuestTracker.grasslandsQuestCount++;
            }
            
            if (QuestTracker.grasslandsQuestCount == 8 && QuestTracker.desertQuestCount < 6)
            {
                QuestTracker.desertQuestCount++;
            }

            if (QuestTracker.desertQuestCount == 7 && QuestTracker.forestQuestCount < 5)
            {
                QuestTracker.forestQuestCount++;
            }

            if (QuestTracker.forestQuestCount == 6 && QuestTracker.snowMountainQuestCount < 3)
            {
                QuestTracker.snowMountainQuestCount++;
            }

            if (QuestTracker.snowMountainQuestCount == 4 && QuestTracker.volcanoQuestCount < 6)
            {
                QuestTracker.volcanoQuestCount++;
            }  
        }
        /*
        else if (!MyQuest.IsComplete)
        {
            markedComplete = false;
            GetComponent<Text>().text = MyQuest.QTitle;
        }
        */
    }
    IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(1f);
        QuestManager.UpdateQuestStatus();
    }
}
