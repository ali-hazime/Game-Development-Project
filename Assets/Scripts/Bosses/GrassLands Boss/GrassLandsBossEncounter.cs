using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassLandsBossEncounter : MonoBehaviour
{
    public GameObject player;
    public GameObject normalLadder;
    public GameObject brokenLadder;
    public GrassLandsBoss bossScript;
    public bool GLStart = false;
    public bool GLEnd = false;
    [SerializeField] QuestController questController;
    [SerializeField] UIToggle uiToggle;
    [SerializeField] bool toggleOnce = true;
    public TalkToQuest talkToQuest;

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

    void Start()
    {
        if (GameSavingInformation.grassBossDefeated == true)
        {
            bossScript.gameObject.SetActive(false);
        }
        else
        {
            bossScript.gameObject.SetActive(true);
        }

        if(QuestTracker.grasslandsQuestCount == 4)
        {
            talkToQuest.UpdateTalkToQuest();
            StartCoroutine(DefeatBossQuest());
        }
    }

    IEnumerator DefeatBossQuest()
    {
        yield return new WaitForSeconds(1f);
        uiToggle.ToggleQuestLog();
        questController.StartQuest(QuestTracker.grasslandsQuestCount, "gM");
        QuestTracker.questType = "gM";
    }

    void Update()
    {
        if (GLStart == false && GLEnd == false)
        {
            WallCheck();
        } else if (bossScript.hitsTaken == 8)
        {
            EndGLBossFight();
        }
    }

    void WallCheck()
    {
        if (player.transform.position.y > 0)
        {
            GLStart = true;
            StartGLBossFight();
        }
    }

    //Notes - Make boss start sitting at y = 4 location

    void StartGLBossFight()
    {
        MakeBarrier();
    }

    void MakeBarrier()
    {
        normalLadder.SetActive(false);
        brokenLadder.SetActive(true);

        //Add rock falling sounds
    }

    void EndGLBossFight()
    {
        GLEnd = true;
        GLStart = false;
        GameSavingInformation.grassBossDefeated = true;
        BreakBarrier();
        StartCoroutine(StartTurnInBossQuest());
    }

    IEnumerator StartTurnInBossQuest()
    {
        yield return new WaitForSeconds(1f);
        if (toggleOnce)
        {
            uiToggle.ToggleQuestLog();
            toggleOnce = false;
        }
        
        questController.StartQuest(QuestTracker.grasslandsQuestCount, "gM");
        QuestTracker.questType = "gM";
    }

   void BreakBarrier()
    {
        normalLadder.SetActive(true);
        brokenLadder.SetActive(false);

        //Add rock breaking sounds
    }
}
