using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoBossEncounterController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Block;
    public GameObject TheBoss;
    public VolcanoBoss TheBossScript;
    [Space]
    [SerializeField] QuestController questController;
    [SerializeField] UIToggle uiToggle;
    public TalkToQuest talkToQuest;
    public KillBoss killBoss;
    [SerializeField] bool toggleOnce = true;
    [Space]
    public bool vStart;
    public bool vEnd;

    void Start()
    {
        TheBoss = FindObjectOfType<VolcanoBoss>().gameObject;
        TheBossScript = FindObjectOfType<VolcanoBoss>();
        Player = GameObject.FindWithTag("Player");

        if (questController == null)
        {
            questController = FindObjectOfType<QuestController>();
        }

        if (uiToggle == null)
        {
            uiToggle = FindObjectOfType<UIToggle>();
        }
    }

    void Update()
    {
        if (vStart == false && vEnd == false)
        {
            if (Player.transform.position.y > 102.5)
            {
                StartCoroutine(BeginBossFight());
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
        vStart = true;
        Block.SetActive(true);
        TheBossScript.isStarted = true;
    }

    void EndFBossFight()
    {
        Block.SetActive(false);
        GameSavingInformation.forestBossDefeated = true;
        Destroy(TheBoss);
        StartCoroutine(EndBossQuest());
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
}
