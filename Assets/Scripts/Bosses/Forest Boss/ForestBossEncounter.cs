using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBossEncounter : MonoBehaviour
{

    private GameObject player;
    private PlayerChar PlayerScript;
    public GameObject treeBeforeBlock;
    public GameObject treeBlock;
    public GameObject cloudParent;
    public GameObject boltsParent;
    public ForestBoss bossScript;
    public GameObject theBoss;

    public bool fStart = false;
    public bool fEnd = false;
    [Space]
    [SerializeField] QuestController questController;
    [SerializeField] UIToggle uiToggle;
    [SerializeField] bool toggleOnce = true;
    [SerializeField] GameObject worldCorruption;
    public KillBoss killBoss;
    public AudioSource Music;


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

    private void Start()
    {
        if (GameSavingInformation.forestBossDefeated == true)
        {
            bossScript.gameObject.SetActive(false);
        }
        else
        {
            bossScript.gameObject.SetActive(true);
        }

    }

    void Update()
    {
        if (fStart == false && fEnd == false)
        {
            if (player.transform.position.y > 18 && !GameSavingInformation.forestBossDefeated)
            {
                startFBossFight();
            }
        }
        else if (bossScript.dead == true)
        {
            EndFBossFight();
            worldCorruption.SetActive(false);
        }

        if (QuestTracker.forestQuestCount > 3)
        {
            worldCorruption.SetActive(false);
        }
        else if (QuestTracker.forestQuestCount < 3)
        {
            worldCorruption.SetActive(true);
        }
    }

    void startFBossFight()
    {
        fStart = true;
        treeBlock.SetActive(true);
        treeBeforeBlock.SetActive(false);
        Music.Play();
        bossScript.started = true;
    }

    void EndFBossFight()
    {
        Destroy(cloudParent);
        Destroy(boltsParent);
        treeBlock.SetActive(false); 
        GameSavingInformation.forestBossDefeated = true;
        Destroy(theBoss);
        StartCoroutine(StartTurnInBossQuest());
    }

    IEnumerator StartTurnInBossQuest()
    {
        yield return new WaitForSeconds(0.5f);
        if (toggleOnce)
        {
            PlayerScript.playerCurrentHealth += PlayerScript.playerMaxHealth;
            killBoss.UpdateBossStatus();
            yield return new WaitForSeconds(1f);
            uiToggle.ToggleQuestLog();
            toggleOnce = false;
            questController.StartQuest(QuestTracker.forestQuestCount, "fM");
            QuestTracker.questType = "fM";
        }
    }
}

