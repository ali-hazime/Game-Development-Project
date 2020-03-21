using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHouseQIC : MonoBehaviour
{
    [SerializeField] GameObject qItem1;
    [SerializeField] GameObject qItem2;
    [SerializeField] GameObject qItem3;
    [SerializeField] GameObject TTinteract;
    [SerializeField] GameObject TTinventory;
    [SerializeField] GameObject TTequip;
    void Awake()
    {
        QuestInfo questStuff = SaveSystem.LoadQuestInfo();
        QuestTracker.questInProgress = questStuff.questInProgressS;
        QuestTracker.q1_Item1 = questStuff.q1_Item1S;
        QuestTracker.q1_Item2 = questStuff.q1_Item2S;
        QuestTracker.q1_Item3 = questStuff.q1_Item3S;
        QuestTracker.grasslandsQuestCount = questStuff.grasslandsQuestCountS;
    }

    void Start()
    {
        if (QuestTracker.q1_Item1 && QuestTracker.questInProgress)
        {
            Debug.Log("INSIDE" + QuestTracker.q1_Item1);

            qItem1.SetActive(true);
        }

        if (QuestTracker.q1_Item2 && QuestTracker.questInProgress)
        {
            Debug.Log("INSIDE" + QuestTracker.q1_Item2);
            qItem2.SetActive(true);
        }

        if (QuestTracker.q1_Item3 && QuestTracker.questInProgress)
        {
            Debug.Log("INSIDE" + QuestTracker.q1_Item3);
            qItem3.SetActive(true);
        }

        if (QuestTracker.grasslandsQuestCount >= 1)
        {
            Destroy(TTinteract);
            Destroy(TTinventory);
            Destroy(TTequip);
        }
    }
}
