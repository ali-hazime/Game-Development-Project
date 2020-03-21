using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] Quest[] quests;
    [SerializeField] QuestLog questLog;

    private void Awake()
    {
        questLog.AcceptQuest(quests[0]);
    }


}
