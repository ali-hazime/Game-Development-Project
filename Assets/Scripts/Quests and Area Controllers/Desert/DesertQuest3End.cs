using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertQuest3End : MonoBehaviour
{
    [SerializeField] UIToggle uiToggle;
    public EscortQuest escortQuest;
    [SerializeField] QuestController questController;
    [SerializeField] NPC_DesertStranded0 strandedNPC;

    void Awake()
    {
        if (uiToggle == null)
        {
            uiToggle = FindObjectOfType<UIToggle>();
        }

        if (questController == null)
        {
            questController = FindObjectOfType<QuestController>();
        }

        if (strandedNPC == null)
        {
            strandedNPC = FindObjectOfType<NPC_DesertStranded0>();
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (QuestTracker.desertQuestCount == 2)
        {
            if (other.CompareTag("Player"))
            {
                uiToggle.ToggleQuestLog();
                escortQuest.UpdateEscortQuest();
                strandedNPC.startFollow = false;
                StartCoroutine(AcceptTombQuest());
            }
        }
    }

    IEnumerator AcceptTombQuest()
    {
        yield return new WaitForSeconds(2f);
        questController.StartQuest(QuestTracker.desertQuestCount, "dM");
        QuestTracker.questType = "dM";

    }
}
