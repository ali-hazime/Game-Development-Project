using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestQIC : MonoBehaviour
{
    [SerializeField] GameObject fQ2Item1;
    [SerializeField] GameObject fQ2Item2;
    [SerializeField] GameObject fQ2Item3;
    [SerializeField] GameObject totemFull;

    void Awake()
    {
        QuestInfo questStuff = SaveSystem.LoadQuestInfo();
        QuestTracker.questInProgress = questStuff.questInProgressS;
        QuestTracker.fQ2_Item1 = questStuff.fQ2_Item1S;
        QuestTracker.fQ2_Item2 = questStuff.fQ2_Item2S;
        QuestTracker.fQ2_Item3 = questStuff.fQ2_Item3S;
        QuestTracker.forestQuestCount = questStuff.forestQuestCountS;
    }

    void Update()
    {
        if (QuestTracker.forestQuestCount == 1)
        {
            if (QuestTracker.fQ2_Item1 && QuestTracker.questInProgress)
            {
                fQ2Item1.SetActive(true); 
            }

            if (QuestTracker.fQ2_Item2 && QuestTracker.questInProgress)
            {
                fQ2Item2.SetActive(true);
            }

            if (QuestTracker.fQ2_Item3 && QuestTracker.questInProgress)
            {
                fQ2Item3.SetActive(true);
            }
        }
    }

    public void FullTotemShow()
    {
        totemFull.SetActive(true);
    }

    public void FullTotemRemove()
    {
        totemFull.SetActive(false);
    }
}
