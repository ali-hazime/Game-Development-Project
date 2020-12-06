using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DesertQuest1Trigger : MonoBehaviour
{
    [SerializeField] UIToggle uiToggle;
    [SerializeField] QuestController questController;
    private bool triggerOnce = true;

    void Awake()
    {
        if (questController == null)
        {
            questController = FindObjectOfType<QuestController>();
        }

        if (uiToggle == null)
        {
            uiToggle = FindObjectOfType<UIToggle>();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (QuestTracker.desertQuestCount == 0)
        {   
            if (other.CompareTag("Player"))
            {
                if (triggerOnce)
                {
                    uiToggle.ToggleQuestLog();
                    questController.StartQuest(QuestTracker.desertQuestCount, "dM");
                    QuestTracker.questType = "dM";
                    triggerOnce = false;
                }
            }
        }
    }
}
