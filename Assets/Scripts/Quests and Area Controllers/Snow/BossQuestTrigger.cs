using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossQuestTrigger : MonoBehaviour
{
    [SerializeField] UIToggle uiToggle;
    [SerializeField] QuestController questController;
    public TalkToQuest talkToQuest;
    public bool triggerOnce = true;

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
        if (QuestTracker.snowMountainQuestCount == 1)
        {
            if (other.CompareTag("Player"))
            {
                talkToQuest.UpdateTalkToQuest();

                if (QuestTracker.triggerOnce2)
                {
                    StartCoroutine(AcceptBossQuest());
                    QuestTracker.triggerOnce2 = false;
                } 
            }
        }

        if (QuestTracker.snowMountainQuestCount > 2 && QuestTracker.volcanoQuestCount == 0)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(AcceptVolcanoQuest());
            }
        }
    }

    IEnumerator AcceptBossQuest()
    {
        yield return new WaitForSeconds(1f);
        uiToggle.ToggleQuestLog();
        QuestLog.MyInstance.HideQuests();
        yield return new WaitForSeconds(0.2f);
        questController.StartQuest(QuestTracker.snowMountainQuestCount, "sM");
        QuestTracker.questType = "sM";
        yield return new WaitForSeconds(1f);
        if (QuestTracker.snowMountainQuestCount == 2)
        {
            QuestTracker.allObjCompleted = false;
        }
    }

    IEnumerator AcceptVolcanoQuest()
    {
        if (triggerOnce)
        {
            uiToggle.ToggleQuestLog();
            yield return new WaitForSeconds(0.3f);
            questController.StartQuest(QuestTracker.volcanoQuestCount, "vM");
            QuestTracker.questType = "vM";
            triggerOnce = false;
        }
        
    }
}
