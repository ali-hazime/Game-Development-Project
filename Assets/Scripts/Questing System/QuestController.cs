using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [SerializeField] SaveLoadButton SaveSystemObj;
    [SerializeField] Quest[] grasslandsMainQuests;
    [SerializeField] Quest[] desertMainQuests;
    [SerializeField] Quest[] forestMainQuests;
    [SerializeField] Quest[] snowMountainMainQuests;
    [SerializeField] Quest[] volcanoMainQuests;
    [SerializeField] QuestLog questLog;
    void Start()
    {
        if (questLog == null)
        {
            questLog = FindObjectOfType<QuestLog>();
        }

        if (QuestTracker.forestQuestCount != 1)
        {
            QuestTracker.allObjCompleted = true; // temp
        }

    }

    void Update()
    {
        //Debug.Log(GameObject.Find("SaveSystem").GetComponent<SaveLoadButton>());
        
        if (SaveSystemObj == null)
        {
            if (GameObject.Find("SaveSystem") != null)
            {
                SaveSystemObj = GameObject.Find("SaveSystem").GetComponent<SaveLoadButton>();
            }
        }
    }

    public void StartQuest(int qNumber, string questType)
    {
        

        QuestManager.UpdateQuestStatus();

        if (Equals(questType, "gM"))
        {
            if (!QuestTracker.questInProgress && QuestTracker.triggerOnce)
            {
                questLog.AcceptQuest(grasslandsMainQuests[qNumber]);
                QuestTracker.triggerOnce = false;
            }
        }

        else if (Equals(questType, "dM"))
        {
            if (!QuestTracker.questInProgress)
            {
                questLog.AcceptQuest(desertMainQuests[qNumber]);
            }
        }

        else if (Equals(questType, "fM"))
        {
            if (!QuestTracker.questInProgress)
            {
                questLog.AcceptQuest(forestMainQuests[qNumber]);
            }
        }

        else if (Equals(questType, "sM"))
        {
            if (!QuestTracker.questInProgress)
            {
                questLog.AcceptQuest(snowMountainMainQuests[qNumber]);
            }
        }

        else if (Equals(questType, "vM"))
        {
            if (!QuestTracker.questInProgress)
            {
                questLog.AcceptQuest(volcanoMainQuests[qNumber]);
            }
        }
        Debug.Log("InStartQuest");
        if (QuestTracker.forestQuestCount != 2 && QuestTracker.volcanoQuestCount < 1)
        {
            SaveSystemObj.Save();
        }

    }

    public void ContinueQuest(int qNumber, string questType)
    {
        if (Equals(questType, "gM"))
        {
            questLog.ContinueQuest(grasslandsMainQuests[qNumber]);
        }

        else if (Equals(questType, "dM"))
        {
            questLog.ContinueQuest(desertMainQuests[qNumber]);
        }

        else if (Equals(questType, "fM"))
        {
            questLog.ContinueQuest(forestMainQuests[qNumber]);
        }

        else if (Equals(questType, "sM"))
        {
            questLog.ContinueQuest(snowMountainMainQuests[qNumber]);
        }

        else if (Equals(questType, "vM"))
        {
            questLog.ContinueQuest(volcanoMainQuests[qNumber]);
        }

       // SaveSystemObj.Save();
        Debug.Log("Continue");
    }
}
