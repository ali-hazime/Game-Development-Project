using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLBossTrigger : MonoBehaviour
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
        if (QuestTracker.grasslandsQuestCount == 4 && QuestTracker.triggerOnce2)
        {
            StartCoroutine(QuestStall());
            QuestTracker.triggerOnce2 = false;

        }
    }

    IEnumerator QuestStall()
    {
        yield return new WaitForSeconds(0.5f);
        talkToQuest.UpdateTalkToQuest();
        StartCoroutine(DefeatBossQuest());
    }

    IEnumerator DefeatBossQuest()
    {
        yield return new WaitForSeconds(1f);
        uiToggle.ToggleQuestLog();

        questController.StartQuest(QuestTracker.grasslandsQuestCount, "gM");

        QuestTracker.questType = "gM";
    }

}
