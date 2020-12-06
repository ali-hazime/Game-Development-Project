using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoBossEncounterController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Block;
    public GameObject TheBoss;
    public VolcanoBoss TheBossScript;
    public GameObject AttacksParent;
    [SerializeField] followPlayer cam;
    [Space]
    [SerializeField] PlayerChar player;
    [SerializeField] QuestController questController;
    [SerializeField] UIToggle uiToggle;
    public TalkToQuest talkToQuest;
    public KillBoss killBoss;
    [SerializeField] bool toggleOnce = true;
    [SerializeField] bool toggleOnce2 = true;
    [SerializeField] GameObject finalBoss;
    public AudioSource Music;
    [Space]
    public bool vStart;
    public bool vEnd;
    public bool once = true;


    void Start()
    {
        TheBoss = FindObjectOfType<VolcanoBoss>().gameObject;
        TheBossScript = FindObjectOfType<VolcanoBoss>();
        Player = GameObject.FindWithTag("Player");

        if (GameSavingInformation.fireBossDefeated == true)
        {
            TheBossScript.gameObject.SetActive(false);
        }
        else
        {
            TheBossScript.gameObject.SetActive(true);
        }

        if (questController == null)
        {
            questController = FindObjectOfType<QuestController>();
        }

        if (uiToggle == null)
        {
            uiToggle = FindObjectOfType<UIToggle>();
        }

        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }

    void Update()
    {
        if (vStart == false && vEnd == false)
        {
            if (Player.transform.position.y > 102.5 && !GameSavingInformation.fireBossDefeated)
            {
                if (once)
                {
                    StartCoroutine(BeginBossFight());
                    once = false;
                }
            }
        }
        else if (TheBossScript.dead == true)
        {
            EndFBossFight();
        }
    }

    IEnumerator BeginBossFight()
    {
        talkToQuest.UpdateTalkToQuest();
        QuestLog.MyInstance.HideQuests();
        yield return new WaitForSeconds(0.2f);
        uiToggle.ToggleQuestLog();
        yield return new WaitForSeconds(0.1f);
        questController.StartQuest(QuestTracker.volcanoQuestCount, "vM");
        QuestTracker.questType = "vM";
        yield return new WaitForSeconds(0.5f);
        startFBossFight();
    }

    void startFBossFight()
    {
        Music.Play();
        vStart = true;
        Block.SetActive(true);
        TheBossScript.isStarted = true;
    }

    void EndFBossFight()
    {
        if (toggleOnce2)
        {
            player.playerCurrentHealth += player.playerMaxHealth;
            vEnd = true;
            Block.SetActive(false);
            GameSavingInformation.fireBossDefeated = true;
            Destroy(TheBoss);
            Destroy(AttacksParent);
            StartCoroutine(EndBossQuest());
            StartCoroutine(FinalBossReveal());
            toggleOnce2 = false;
        }
        
    }

    IEnumerator EndBossQuest()
    {
        yield return new WaitForSeconds(0.1f);
        if (toggleOnce)
        {
            killBoss.UpdateBossStatus();
            yield return new WaitForSeconds(1f);
            uiToggle.ToggleQuestLog();
            toggleOnce = false;
        }
    }

    IEnumerator FinalBossReveal()
    {
        yield return new WaitForSeconds(2f);
        player.RestrictMovement(3f);
        cam.PanCamera(finalBoss.gameObject.transform.position, true);
        yield return new WaitForSeconds(0.5f);
        finalBoss.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        cam.PanCamera(player.transform.position, false);
        questController.StartQuest(QuestTracker.volcanoQuestCount, "vM");
        QuestTracker.questType = "vM";
    }
}
