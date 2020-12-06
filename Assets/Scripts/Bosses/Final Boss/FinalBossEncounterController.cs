using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossEncounterController : MonoBehaviour
{
    private GameObject Player;
    public GameObject TheBoss;
    public FinalBossScript TheBossScript;
    public GameObject AreaEdge;
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
    public bool vStart;
    public bool vEnd;
    public bool movePlayer = false;
    public bool once = true;
    public bool once2 = true;
    public bool once3 = true;
    public bool once4 = true;
    public bool talkingBegin = false;
    public int z = 0;
    public float stuff;
    public AudioSource Music;

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
        Dialogue.zCount = 0;
        if (QuestTracker.volcanoQuestCount > 2)
        {
            //TheBoss = FindObjectOfType<FinalBossScript>().gameObject;
            //TheBossScript = FindObjectOfType<FinalBossScript>();
        }
        if (Player == null)
        {

            Player = FindObjectOfType<PlayerChar>().gameObject;
        }
        if (PlayerScript == null)
        {
            PlayerScript = FindObjectOfType<PlayerChar>();
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

    // Update is called once per frame
    void Update()
    {

        if (QuestTracker.volcanoQuestCount > 2) 
        {
            if (vStart == false && vEnd == false)
            {
                if (Player.transform.position.y < 4.1 && (Player.transform.position.x > 2.5 && Player.transform.position.x < 3.5))
                {
                    if (once4)
                    {
                        if (QuestTracker.volcanoQuestCount == 3)
                        {
                            talkToQuest.UpdateTalkToQuest();
                            StartCoroutine(AcceptFinalQuest());
                        }
                        once = true;
                        once4 = false;
                    }
                    startIntro();
                }
            }
           
            if (TheBossScript.dead == true)
            {
                EndFBossFight();
            }
             
            if (Dialogue.zCount == 3)
            {
                if (once3)
                {
                    once3 = false;
                    StartCoroutine(StartFight());
                }
            }
        }

    }

    private void FixedUpdate()
    {
        //stuff = Vector3.Distance(new Vector3(3.5f, -8f, 0), Player.transform.position);
        //Debug.Log(stuff);
        if (movePlayer == true)
        {
            PlayerScript.walkSouth = true;
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, new Vector3(3.5f, -8f, 0), 3 * Time.fixedDeltaTime);
        }
    }
    void startIntro()
    {
        if (once)
        {
            Music.Pause();
            movePlayer = true;
            once = false;
        }

        if (Vector3.Distance( new Vector3(3.5f, -8f, 0), Player.transform.position) < 0.25f)
        {
            PlayerScript.walkSouth = false;
            movePlayer = false;
            if (once2 == true)
            {
                PlayerScript.RestrictMovementUntilTrue();
                StartCoroutine(SpawnArea());
                once2 = false;
            }
            if(talkingBegin)
            {
                if (NPCtextbox.activeSelf == false)
                {
                    NPCtextbox.SetActive(true);
                    Dialogue.ConvoReset(79, 0);
                    Dialogue.once = true;
                    
                }

                talkingBegin = false;
            }
        }
    }
    /*void startFBossFight()
    {
        vStart = true;
       // Block.SetActive(true);
        TheBossScript.isStarted = true;
    }*/

    void EndFBossFight()
    {
       // Block.SetActive(false);
        GameSavingInformation.forestBossDefeated = true;
        Destroy(TheBoss);

        //StartCoroutine(EndBossQuest());

    }

    IEnumerator StartFight()
    {
        yield return new WaitForSeconds(0.1f);
        talkingBegin = false;
        yield return new WaitForSeconds(0.1f);
        PlayerScript.breakTheFreeze();
        yield return new WaitForSeconds(0.2f);
        Player.transform.position = new Vector3(3.5f, -2, 0f);
        yield return new WaitForSeconds(0.5f);
        vStart = true;
        TheBossScript.isStarted = true;
    }

    IEnumerator SpawnArea()
    {
        yield return new WaitForSeconds(1f);
        GameObject ArenaWall10 = Instantiate(AreaEdge, new Vector3(1.5f, -1.5f, 0), Quaternion.Euler(0f, 0f, 0f));
        GameObject ArenaWall20 = Instantiate(AreaEdge, new Vector3(6.06f, -16.65f, 0), Quaternion.Euler(0f, 0f, -180f));
        GameObject ArenaWall30 = Instantiate(AreaEdge, new Vector3(-4f, -10.94f, 0), Quaternion.Euler(0f, 0f, 90f));
        GameObject ArenaWall40 = Instantiate(AreaEdge, new Vector3(11.55f, -7.159f), Quaternion.Euler(0f, 0f, -90f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall11 = Instantiate(AreaEdge, new Vector3(2.25f, -1.5f, 0), Quaternion.Euler(0f, 0f, 0f));
        GameObject ArenaWall21 = Instantiate(AreaEdge, new Vector3(11.55f, -7.91f, 0), Quaternion.Euler(0f, 0f, -90f));
        GameObject ArenaWall31 = Instantiate(AreaEdge, new Vector3(5.31f, -16.65f, 0), Quaternion.Euler(0f, 0f, -180f));
        GameObject ArenaWall41 = Instantiate(AreaEdge, new Vector3(-4f, -10.19f), Quaternion.Euler(0f, 0f, 90f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall12 = Instantiate(AreaEdge, new Vector3(3f, -1.5f, 0), Quaternion.Euler(0f, 0f, 0f));
        GameObject ArenaWall22 = Instantiate(AreaEdge, new Vector3(11.55f, -8.66f, 0), Quaternion.Euler(0f, 0f, -90f));
        GameObject ArenaWall32 = Instantiate(AreaEdge, new Vector3(4.56f, -16.65f, 0), Quaternion.Euler(0f, 0f, -180f));
        GameObject ArenaWall42 = Instantiate(AreaEdge, new Vector3(-4f, -9.44f, 0), Quaternion.Euler(0f, 0f, 90f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall13 = Instantiate(AreaEdge, new Vector3(3.75f, -1.5f, 0), Quaternion.Euler(0f, 0f, 0f));
        GameObject ArenaWall23 = Instantiate(AreaEdge, new Vector3(11.55f, -9.41f, 0), Quaternion.Euler(0f, 0f, -90f));
        GameObject ArenaWall33 = Instantiate(AreaEdge, new Vector3(3.81f, -16.65f, 0), Quaternion.Euler(0f, 0f, -180f));
        GameObject ArenaWall43 = Instantiate(AreaEdge, new Vector3(-4f, -8.69f, 0), Quaternion.Euler(0f, 0f, 90f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall14 = Instantiate(AreaEdge, new Vector3(4.5f, -1.5f, 0), Quaternion.Euler(0f, 0f, 0f));
        GameObject ArenaWall24 = Instantiate(AreaEdge, new Vector3(11.55f, -10.16f, 0), Quaternion.Euler(0f, 0f, -90f));
        GameObject ArenaWall34 = Instantiate(AreaEdge, new Vector3(3.06f, -16.65f, 0), Quaternion.Euler(0f, 0f, -180f));
        GameObject ArenaWall44 = Instantiate(AreaEdge, new Vector3(-4f, -8.69f, 0), Quaternion.Euler(0f, 0f, 90f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall15 = Instantiate(AreaEdge, new Vector3(5.25f, -1.5f, 0), Quaternion.Euler(0f, 0f, 0f));
        //GameObject ArenaWall2 = Instantiate(AreaEdge, new Vector3(11.55f, -8.66f, 0), Quaternion.Euler(0f, 0f, -90f)); ????????????
        GameObject ArenaWall35 = Instantiate(AreaEdge, new Vector3(2.31f, -16.65f, 0), Quaternion.Euler(0f, 0f, -180f));
        GameObject ArenaWall45 = Instantiate(AreaEdge, new Vector3(-4f, -7.94f, 0), Quaternion.Euler(0f, 0f, 90f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall16 = Instantiate(AreaEdge, new Vector3(6.075f, -1.65f, 0), Quaternion.Euler(0f, 0f, -15f));
        GameObject ArenaWall26 = Instantiate(AreaEdge, new Vector3(11.43f, -11.09f, 0), Quaternion.Euler(0f, 0f, -105f));
        GameObject ArenaWall36 = Instantiate(AreaEdge, new Vector3(1.5099f, -16.42f, 0), Quaternion.Euler(0f, 0f, 165f));
        GameObject ArenaWall46 = Instantiate(AreaEdge, new Vector3(-3.945f, -7.15f, 0), Quaternion.Euler(0f, 0f, 75f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall17 = Instantiate(AreaEdge, new Vector3(6.84f, -1.77f, 0), Quaternion.Euler(0f, 0f, -15f));
        GameObject ArenaWall27 = Instantiate(AreaEdge, new Vector3(11.31f, -11.86f, 0), Quaternion.Euler(0f, 0f, -105f));
        GameObject ArenaWall37 = Instantiate(AreaEdge, new Vector3(0.7299f, -16.3f, 0), Quaternion.Euler(0f, 0f, 165f));
        GameObject ArenaWall47 = Instantiate(AreaEdge, new Vector3(-3.825f, -6.38f, 0), Quaternion.Euler(0f, 0f, 75f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall18 = Instantiate(AreaEdge, new Vector3(7.68f, -1.95f, 0), Quaternion.Euler(0f, 0f, -30f));
        GameObject ArenaWall28 = Instantiate(AreaEdge, new Vector3(11.13f, -12.69f, 0), Quaternion.Euler(0f, 0f, -120f));
        GameObject ArenaWall38 = Instantiate(AreaEdge, new Vector3(0.095f, -16.12f, 0), Quaternion.Euler(0f, 0f, 150f));
        GameObject ArenaWall48 = Instantiate(AreaEdge, new Vector3(-3.645f, -5.55f, 0), Quaternion.Euler(0f, 0f, 60f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall19 = Instantiate(AreaEdge, new Vector3(8.505f, -2.205f, 0), Quaternion.Euler(0f, 0f, -30f));
        GameObject ArenaWall29 = Instantiate(AreaEdge, new Vector3(10.88f, -13.52f, 0), Quaternion.Euler(0f, 0f, -120f));
        GameObject ArenaWall39 = Instantiate(AreaEdge, new Vector3(-0.920f, -15.86f, 0), Quaternion.Euler(0f, 0f, 150f));
        GameObject ArenaWall49 = Instantiate(AreaEdge, new Vector3(-3.395f, -4.72f, 0), Quaternion.Euler(0f, 0f, 60f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall110 = Instantiate(AreaEdge, new Vector3(9.225f, -2.775f, 0), Quaternion.Euler(0f, 0f, -45f));
        GameObject ArenaWall210 = Instantiate(AreaEdge, new Vector3(10.31f, -14.24f, 0), Quaternion.Euler(0f, 0f, -135f));
        GameObject ArenaWall310 = Instantiate(AreaEdge, new Vector3(-1.64f, -15.29f, 0), Quaternion.Euler(0f, 0f, 135f));
        GameObject ArenaWall410 = Instantiate(AreaEdge, new Vector3(-2.825f, -4f, 0), Quaternion.Euler(0f, 0f, 45f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall111 = Instantiate(AreaEdge, new Vector3(9.84f, -3.36f, 0), Quaternion.Euler(0f, 0f, -45f));
        GameObject ArenaWall211 = Instantiate(AreaEdge, new Vector3(9.72f, -14.86f, 0), Quaternion.Euler(0f, 0f, -135f));
        GameObject ArenaWall311 = Instantiate(AreaEdge, new Vector3(-2.27f, -14.71f, 0), Quaternion.Euler(0f, 0f, 135f));
        GameObject ArenaWall411 = Instantiate(AreaEdge, new Vector3(-2.235f, -3.38f, 0), Quaternion.Euler(0f, 0f, 45f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall112 = Instantiate(AreaEdge, new Vector3(10.35f, -4.02f, 0), Quaternion.Euler(0f, 0f, -60f));
        GameObject ArenaWall212 = Instantiate(AreaEdge, new Vector3(9.0599f, -15.36f, 0), Quaternion.Euler(0f, 0f, -150f));
        GameObject ArenaWall312 = Instantiate(AreaEdge, new Vector3(-2.765f, -14.05f, 0), Quaternion.Euler(0f, 0f, 120f));
        GameObject ArenaWall412 = Instantiate(AreaEdge, new Vector3(-1.575f, -2.88f, 0), Quaternion.Euler(0f, 0f, 30f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall113 = Instantiate(AreaEdge, new Vector3(10.785f, -4.71f, 0), Quaternion.Euler(0f, 0f, -60f));
        GameObject ArenaWall213 = Instantiate(AreaEdge, new Vector3(8.3699f, -15.8f, 0), Quaternion.Euler(0f, 0f, -150f));
        GameObject ArenaWall313 = Instantiate(AreaEdge, new Vector3(-3.2f, -13.36f, 0), Quaternion.Euler(0f, 0f, 120f));
        GameObject ArenaWall413 = Instantiate(AreaEdge, new Vector3(-0.885f, -2.44f, 0), Quaternion.Euler(0f, 0f, 30f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall114 = Instantiate(AreaEdge, new Vector3(11.19f, -5.46f, 0), Quaternion.Euler(0f, 0f, -75f));
        GameObject ArenaWall214 = Instantiate(AreaEdge, new Vector3(7.619f, -16.21f, 0), Quaternion.Euler(0f, 0f, 195f));
        GameObject ArenaWall314 = Instantiate(AreaEdge, new Vector3(-3.62f, -12.61f, 0), Quaternion.Euler(0f, 0f, 105f));
        GameObject ArenaWall414 = Instantiate(AreaEdge, new Vector3(-0.135f, -2.03f, 0), Quaternion.Euler(0f, 0f, 15f));
        yield return new WaitForSeconds(0.1f);
        GameObject ArenaWall115 = Instantiate(AreaEdge, new Vector3(11.475f, -6.18f, 0), Quaternion.Euler(0f, 0f, -75f));
        GameObject ArenaWall215 = Instantiate(AreaEdge, new Vector3(6.9f, -16.49f, 0), Quaternion.Euler(0f, 0f, 195f));
        GameObject ArenaWall315 = Instantiate(AreaEdge, new Vector3(-3.89f, -11.89f, 0), Quaternion.Euler(0f, 0f, 105f));
        GameObject ArenaWall415 = Instantiate(AreaEdge, new Vector3(0.58f, -1.7f, 0), Quaternion.Euler(0f, 0f, 15f));
        yield return new WaitForSeconds(1f);
        talkingBegin = true;
    }

    IEnumerator AcceptFinalQuest()
    {
        yield return new WaitForSeconds(1f);
        QuestLog.MyInstance.HideQuests();
        uiToggle.ToggleQuestLog();
        yield return new WaitForSeconds(0.3f);
        questController.StartQuest(QuestTracker.volcanoQuestCount, "vM");
        QuestTracker.questType = "vM";
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
