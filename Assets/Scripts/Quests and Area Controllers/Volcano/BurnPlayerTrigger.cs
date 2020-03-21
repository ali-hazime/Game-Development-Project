using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnPlayerTrigger : MonoBehaviour
{
    private PlayerChar player;
    public TalkToQuest talkToQuest;
    [SerializeField] UIToggle uiToggle;
    [SerializeField] QuestController questController;
    public bool triggerOnce = true;
    void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }

        if (questController == null)
        {
            questController = FindObjectOfType<QuestController>();
        }

        if (uiToggle == null)
        {
            uiToggle = FindObjectOfType<UIToggle>();
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (QuestTracker.snowMountainQuestCount <= 2)
        {
            if (other.CompareTag("Player"))
            {
                player.BurnPlayer(true, 120f, 1);
                player.TakeDamage(1);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       if (QuestTracker.volcanoQuestCount == 0 && QuestTracker.snowMountainQuestCount > 2)
       {
            if (other.CompareTag("Player"))
            {
                talkToQuest.UpdateTalkToQuest();
                StartCoroutine(AcceptQuest2());
            }
       } 
    }

    IEnumerator AcceptQuest2()
    {
        yield return new WaitForSeconds(1f);
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
