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
        if (MyQuest.IsComplete && !markedComplete)
        {
            markedComplete = true;
            GetComponent<Text>().text += "\n(Quest Completed)";
            QuestTracker.questInProgress = false;
            StartCoroutine(WaitSomeTime());
            QuestLog.MyInstance.EndQuest();

            //this is temp until i have a better way
            QuestTracker.grasslandsQuestCount++;
            QuestTracker.desertQuestCount++;
            QuestTracker.forestQuestCount++;
            QuestTracker.snowMountainQuestCount++;
            QuestTracker.volcanoQuestCount++;
            
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
