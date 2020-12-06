using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassLandsBossEncounter : MonoBehaviour
{
    public GameObject player;
    private PlayerChar PlayerScript;
    public GameObject normalLadder;
    public GameObject brokenLadder;
    public GrassLandsBoss bossScript;
    public bool GLStart = false;
    public bool GLEnd = false;
    [SerializeField] GameObject DoorGate;
    [SerializeField] QuestController questController;
    [SerializeField] UIToggle uiToggle;
    [SerializeField] bool toggleOnce = true;
    public TalkToQuest talkToQuest;
    public AudioSource Music;
    public bool once = true;

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

    private void OnEnable()
    {
        if (PlayerScript == null)
        {
            PlayerScript = FindObjectOfType<PlayerChar>();
        }
    }

    void Start()
    {
        if (GameSavingInformation.grassBossDefeated == true)
        {
            bossScript.gameObject.SetActive(false);
            DoorGate.SetActive(false);
        }
        else
        {
            bossScript.gameObject.SetActive(true);
            DoorGate.SetActive(true);
        }

       /* if(QuestTracker.grasslandsQuestCount == 4 && QuestTracker.triggerOnce2)
        {
            StartCoroutine(QuestStall());
            QuestTracker.triggerOnce2 = false;
            
        }*/
    }

   /* IEnumerator QuestStall()
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
    }*/

    void Update()
    {
        if (GLStart == false && GLEnd == false)
        {
            WallCheck();
        } else if (bossScript.dead == true)
        {
            EndGLBossFight();
        }

        if (GameSavingInformation.grassBossDefeated == true)
        {
            DoorGate.SetActive(false);
        }
        else
        {
            DoorGate.SetActive(true);
        }
    }

    void WallCheck()
    {
        if (player.transform.position.y > 0 && !GameSavingInformation.grassBossDefeated)
        {
            GLStart = true;
            StartGLBossFight();
        }
    }

    //Notes - Make boss start sitting at y = 4 location

    void StartGLBossFight()
    {
        Music.Play();
        bossScript.started = true;
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
        if (bossScript)
        {
            Destroy(bossScript.gameObject);
        }
    }

    IEnumerator StartTurnInBossQuest()
    {
        yield return new WaitForSeconds(1f);
        if (toggleOnce)
        {
            PlayerScript.playerCurrentHealth += PlayerScript.playerMaxHealth;
            uiToggle.ToggleQuestLog();
            toggleOnce = false;
        }
        if (once)
        {
            questController.StartQuest(QuestTracker.grasslandsQuestCount, "gM");
            QuestTracker.questType = "gM";
            once = false;
        }
    }

   void BreakBarrier()
    {
        normalLadder.SetActive(true);
        brokenLadder.SetActive(false);

        //Add rock breaking sounds
    }
}
