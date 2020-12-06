using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBossEncounterVoidRealm : MonoBehaviour
{
    private GameObject Player;
    public GameObject abilityParent;
    public GameObject TheBoss;
    public FinalBossVoidRealm TheBossScript;
    public PlayerChar PlayerScript;
    public GameObject NPCtextbox;
    public NPC_Dialogue Dialogue;
    [Space]
    [SerializeField] QuestController questController;
    [SerializeField] UIToggle uiToggle;
    [SerializeField] bool toggleOnce = true;
    public KillBoss killBoss;
    public TalkToQuest talkToQuest;
    [Space]
    public static int clonesKilled = 0;
    public bool vStart;
    public bool vEnd;
    public bool once = true;

    private void OnEnable()
    {
        if (NPCtextbox == null)
        {
            NPCtextbox = FindObjectOfType<NPC_Dialogue>().gameObject;
        }
        if (Dialogue == null)
        {
            Dialogue = FindObjectOfType<NPC_Dialogue>();
        }
    }
    void Start()
    {
        clonesKilled = 0;


        TheBoss = FindObjectOfType<FinalBossVoidRealm>().gameObject;
        TheBossScript = FindObjectOfType<FinalBossVoidRealm>();
        Player = GameObject.FindWithTag("Player");
        PlayerScript = FindObjectOfType<PlayerChar>();

        if (questController == null)
        {
            questController = FindObjectOfType<QuestController>();
        }

        if (uiToggle == null)
        {
            uiToggle = FindObjectOfType<UIToggle>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(clonesKilled);
        if (clonesKilled == 5)
        {
            TheBoss.SetActive(true);
            TheBossScript.shadowBoltOnCD = false;
            TheBossScript.spawnMinionsOnCD = false;
            TheBossScript.voidOrbOnCD = false;
            clonesKilled = 0;
        }

        if (QuestTracker.volcanoQuestCount > 2)
        {
            if (vStart == false && vEnd == false)
            {
                TheBossScript.isStarted = true;
                vStart = true;
               
            }
            else if (TheBossScript.dead == true)
            {
                EndFBossFight();
            }
        }
    }

    void EndFBossFight()
    {
        // Block.SetActive(false);
        GameSavingInformation.finalBossDefeated = true;

        if (once)
        {
            StartCoroutine(EndBossQuest());
            Destroy(TheBoss);
            Destroy(abilityParent);
            once = false;

            StartCoroutine(BackToStart());
        }

        if (NPCtextbox.activeSelf == false)
        {
            NPCtextbox.SetActive(true);
            Dialogue.ConvoReset(82, 0);
            Dialogue.once = true;

        }


    }
    IEnumerator BackToStart()
    {
        yield return new WaitForSeconds(11);
        SceneManager.LoadScene("MainMenu");

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