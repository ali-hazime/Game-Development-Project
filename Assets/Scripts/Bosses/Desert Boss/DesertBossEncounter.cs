using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBossEncounter : MonoBehaviour
{
    private GameObject player;
    private PlayerChar PlayerScript;
    public GameObject rocks;
    public DesertBoss bossScript;
    public GameObject sandStorm;
    public GameObject theBoss;
    public ParticleSystem SSright;
    public ParticleSystem SSleft;
    public bool dStart = false;
    public bool dEnd = false;
    public float endTimer = 5;
    public KillBoss killBoss;
    public bool once = true;
    [Space]
    [SerializeField] QuestController questController;
    [SerializeField] UIToggle uiToggle;
    [SerializeField] bool toggleOnce = true;
    public TalkToQuest talkToQuest;
    public AudioSource Music;

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

    private void OnEnable()
    {
        if (PlayerScript == null)
        {
            PlayerScript = FindObjectOfType<PlayerChar>();
        }
    }

    void Start()
    {
        if (GameSavingInformation.desertBossDefeated == true)
        {
            bossScript.gameObject.SetActive(false);
        }
        else
        {
            bossScript.gameObject.SetActive(true);
        }

        if (QuestTracker.desertQuestCount == 3 && QuestTracker.triggerOnce2)
        {
            StartCoroutine(QuestStuff());
        }
    }

    IEnumerator QuestStuff()
    {
        yield return new WaitForSeconds(0.5f);
        talkToQuest.UpdateTalkToQuest();
        StartCoroutine(DefeatBossQuest());
        QuestTracker.triggerOnce2 = false;
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
            if (player.transform.position.y > 35 && !GameSavingInformation.desertBossDefeated)
            {
                startDBossFight();
            }
        }
        
        if (bossScript.dead == true)
        {
            EndDBossFight();
        }

    }

    void startDBossFight()
    {
        Music.Play();
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
            emissionR.rateOverTime = endTimer * 200;
            emissionL.rateOverTime = endTimer * 200;
        }
        else
        {
            sandStorm.SetActive(false);
            rocks.SetActive(false);
        }
        Destroy(theBoss);
        //killBoss.UpdateBossStatus();
        GameSavingInformation.desertBossDefeated = true;
        StartCoroutine(StartTurnInBossQuest());
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
            questController.StartQuest(QuestTracker.desertQuestCount, "dM");
            QuestTracker.questType = "dM";
            once = false;
        }
    }
}
