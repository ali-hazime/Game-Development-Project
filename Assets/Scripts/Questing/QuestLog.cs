using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{
    [SerializeField] GameObject questPrefab;
    [SerializeField] Transform questParent;
    [SerializeField] Text questDescription;
    private static QuestLog instance;
    private List<QuestScript> questScripts = new List<QuestScript>();
    public GameObject aQuest;
    private List<Quest> quests = new List<Quest>();

    private Quest selected;

    public static QuestLog MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestLog>();
            }
            return instance;
        }
    }

    public List<Quest> MyQuests
    {
        get
        {
            return quests;
        }

        set
        {
            quests = value;
        }
    }

    public void AcceptQuest(Quest quest)
    {
        QuestTracker.questInProgress = true;
        QuestTracker.killCount = 0;
        QuestTracker.itemCount = 0;
        QuestManager.UpdateQuestStatus();
        aQuest = Instantiate(questPrefab, questParent);
        QuestScript qs = aQuest.GetComponent<QuestScript>();
        quest.MyQuestScript = qs;
        qs.MyQuest = quest;
        qs.MyQuest.MyQuestScript = qs;
        aQuest.GetComponent<Text>().text = quest.QTitle;
        questScripts.Add(qs); 
        quests.Add(quest);
        ShowDescription(quest);
        //CheckCompletion();
    }

    public void CompleteQuest(QuestScript qs)
    {
        QuestManager.UpdateQuestStatus();
        //questScripts.Remove(qs);
        //qs.gameObject.SetActive(false);
        qs.gameObject.GetComponent<Button>().interactable = false;
        //MyQuests.Remove(qs.MyQuest);
        questDescription.text = string.Format("This Quest has been completed");
        selected = null; //Deselectring the quest
        //qs.MyQuest.MyQuestGiver.UpdateQuestStatus();
        qs = null;
    }

    public void HideQuests()
    {
        foreach (QuestScript qs in questScripts)
        {
            //questScripts.Remove(qs);
            qs.gameObject.SetActive(false);
            //MyQuests.Remove(qs.MyQuest);
            questDescription.text = string.Empty;
            selected = null; //Deselectring the quest
        }
    }

    public void EndQuest()
    {
        CompleteQuest(selected.MyQuestScript);
    }

    public void ShowDescription(Quest quest)
    {
        if (quest != null)
        {
            if (selected != null && selected != quest)
            {
                selected.MyQuestScript.DeSelect();
            }

     
            string objectives = "\nObjectives\n";

            selected = quest;
            string title = quest.QTitle;
            foreach (Objective obj in quest.MyCollectObjectives)
            {
                objectives += obj.MyType + ": " + QuestTracker.itemCount + "/" + obj.MyAmount + "\n";
                //objectives += obj.MyType + ": " + obj.MyCurrentAmount + "/" + obj.MyAmount + "\n";
            }
            foreach (Objective obj in quest.MyKillObjectives)
            {
                objectives += obj.MyType + ": " + QuestTracker.killCount + "/" + obj.MyAmount + "\n";
                //objectives += obj.MyType + ": " + obj.MyCurrentAmount + "/" + obj.MyAmount + "\n";
                //Debug.Log(obj.MyCurrentAmount);
            }

            foreach (Objective obj in quest.MyKillBosses)
            {
                objectives += obj.MyType + ": " + 0 + "/" + obj.MyAmount + "\n";
                //objectives += obj.MyType + ": " + obj.MyCurrentAmount + "/" + obj.MyAmount + "\n";
                //Debug.Log(obj.MyCurrentAmount);
            }

            foreach (Objective obj in quest.MyEscortQuests)
            {
                objectives += obj.MyType + ": " + 0 + "/" + obj.MyAmount + "\n";
                //objectives += obj.MyType + ": " + obj.MyCurrentAmount + "/" + obj.MyAmount + "\n";
                //Debug.Log(obj.MyCurrentAmount);
            }

            foreach (Objective obj in quest.MyTalkToQuests)
            {
                objectives += obj.MyType + ": " + 0 + "/" + obj.MyAmount + "\n";
                //objectives += obj.MyType + ": " + obj.MyCurrentAmount + "/" + obj.MyAmount + "\n";
                //Debug.Log(obj.MyCurrentAmount);
            }

            if (QuestTracker.questInProgress)
            {
                
                questDescription.text = string.Format("{0}\n\n{1}\n{2}", title, quest.QDescription, objectives);
            }
            /*
            else
            {
                questDescription.text = "No quests selected.";
            }
            */

        }
    }

    public void HideDescription()
    {
        selected.MyQuestScript.DeSelect();
        questDescription.text = "No quests selected.";
    }
    public void CheckCompletion()
    {
        foreach (QuestScript qs in questScripts)
        {
            qs.IsComplete();
        }
    }

    public void UpdateSelected()
    {
        ShowDescription(selected);
    }

    /*
    public bool HasQuest(Quest quest)
    {
        return quests.Exists(x => x.QTitle == quest.QTitle);
    }*/
}
