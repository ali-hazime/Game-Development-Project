using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowQuest1Trigger : MonoBehaviour
{
    [SerializeField] UIToggle uiToggle;
    [SerializeField] QuestController questController;

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
        if (QuestTracker.snowMountainQuestCount == 0 && QuestTracker.triggerOnce2)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(ToggleQuest());
                QuestTracker.triggerOnce2 = false;
            }
        }
    }

    IEnumerator ToggleQuest()
    {
        yield return new WaitForSeconds(1f);
        questController.StartQuest(QuestTracker.snowMountainQuestCount, "sM");
        QuestTracker.questType = "sM";
        uiToggle.ToggleQuestLog();
    }
}