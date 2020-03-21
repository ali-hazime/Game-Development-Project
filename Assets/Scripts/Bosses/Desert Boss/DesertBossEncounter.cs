using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBossEncounter : MonoBehaviour
{
    private GameObject player;
    public GameObject rocks;
    public DesertBoss bossScript;
    public GameObject sandStorm;
    public GameObject theBoss;
    public ParticleSystem SSright;
    public ParticleSystem SSleft;
    public bool dStart = false;
    public bool dEnd = false;
    public float endTimer = 5;
    [Space]
    [SerializeField] QuestController questController;
    [SerializeField] UIToggle uiToggle;
    [SerializeField] bool toggleOnce = true;
    public TalkToQuest talkToQuest;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");

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
        if (QuestTracker.desertQuestCount == 3)
        {
            talkToQuest.UpdateTalkToQuest();
            StartCoroutine(DefeatBossQuest());
        }
    }

    IEnumerator DefeatBossQuest()
    {
        yield return new WaitForSeconds(1f);
        uiToggle.ToggleQuestLog();
        questController.StartQuest(QuestTracker.desertQuestCount, "dM");
        QuestTracker.questType = "dM";
    }

    // Update is called once per frame
    void Update()
    {
        if (dStart == false && dEnd == false)
        {
            if (player.transform.position.y > 35)
            {
                startDBossFight();
            }
        }
        else if (bossScript.dead == true)
        {
            EndDBossFight();
        }

    }

    void startDBossFight()
    {
        dStart = true;
        rocks.SetActive(true);
        bossScript.started = true;
    }

    void EndDBossFight()
    {
        var emissionR = SSleft.emission;
        var emissionL = SSright.emission;

        if (endTimer > 0)
        {
            endTimer -= Time.deltaTime;
            emissionR.rateOverTime = endTimer * 1000;
            emissionL.rateOverTime = endTimer * 1000;
        }
        else
        {
            sandStorm.SetActive(false);
            rocks.SetActive(false);
        }

        Destroy(theBoss);
        GameSavingInformation.desertBossDefeated = true;
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

        questController.StartQuest(QuestTracker.desertQuestCount, "dM");
        QuestTracker.questType = "dM";
    }
}
