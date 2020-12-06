using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrasslandsGameController : MonoBehaviour
{
    [SerializeField] GameObject GLBossGate;
    [SerializeField] GameObject GLBossTransition;
    [SerializeField] GameObject DesertBlock;
    [SerializeField] GameObject theFinalBoss;
    [SerializeField] GameObject ForestTopRightBlock;
    [SerializeField] GameObject ForestTopLeftBlock;
    [SerializeField] GameObject Corruption;
    [SerializeField] GameObject GreenGuy;
    [SerializeField] GameObject Birdy;
    [SerializeField] GameObject GlobbyGlob;
    [SerializeField] GameObject InvadingMonstersParent;
    [SerializeField] GameObject NPCsParent;
    [SerializeField] GameObject FBoff;
    [SerializeField] GameObject FBon;
    [SerializeField] GameObject Nguard;
    [SerializeField] GameObject Sguard;
    /*[SerializeField] GameObject GL_TFH_1;
    [SerializeField] GameObject GL_TFH_2;
    [SerializeField] GameObject GL_TFH_3;
    [SerializeField] GameObject GL_TFH_4;
    [SerializeField] GameObject GL_TFH_5;*/
    [SerializeField] GameObject GL_TF_1;
    [SerializeField] GameObject GL_TF_2;
    [SerializeField] GameObject GL_TF_3;
    [SerializeField] GameObject GL_TF_4;
    [SerializeField] GameObject GL_TF_5;
    [SerializeField] GameObject GL_TF_6;
    [SerializeField] GameObject GL_TF_7;
    [SerializeField] GameObject GL_TF_8;
    [SerializeField] GameObject GL_TF_9;
    [SerializeField] GameObject GL_TF_10;
    [SerializeField] QuestController questController;
    [SerializeField] UIToggle uiToggle;
    [SerializeField] bool toggleOnce = true;
    [SerializeField] GameObject Ruby1;
    [SerializeField] GameObject Ruby2;
    public AudioSource Music;
    void Awake()
    {

        if (QuestTracker.grasslandsQuestCount == 2)
        {
            SpawnMonsters();
        }

        if (QuestTracker.grasslandsQuestCount >= 3 && QuestTracker.volcanoQuestCount != 3)
        {
            Destroy(InvadingMonstersParent);
        }

        if (QuestTracker.grasslandsQuestCount == 1)
        {
             StartCoroutine(SpawnHelpNPCs());
        }

        if (QuestTracker.grasslandsQuestCount >= 6 && QuestTracker.volcanoQuestCount < 3)
        {
             StartCoroutine(SpawnVillageNPCs());
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

    private void Start()
    {
        if (GameSavingInformation.ruby1Collected)
        {
            Ruby1.SetActive(false);
        }
        else
        {
            Ruby1.SetActive(true);
        }

        if (GameSavingInformation.ruby2Collected)
        {
            Ruby2.SetActive(false);
        }
        else
        {
            Ruby2.SetActive(true);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (GameSavingInformation.grassBossDefeated == true)
        {
            GLBossGate.SetActive(true);
            GLBossTransition.SetActive(false);
        }
        else
        {
            GLBossGate.SetActive(false);
            GLBossTransition.SetActive(true);
        }

        if (QuestTracker.grasslandsQuestCount == 3)
        {
            if (toggleOnce)
            {
                uiToggle.ToggleQuestLog();
                toggleOnce = false;
                questController.StartQuest(QuestTracker.grasslandsQuestCount, "gM");
                QuestTracker.questType = "gM";
            }
            

        }

        if (QuestTracker.forestQuestCount > 2 && QuestTracker.volcanoQuestCount < 3)
        {
            Corruption.SetActive(false);
            DesertBlock.SetActive(false);
            ForestTopRightBlock.SetActive(false);
            ForestTopLeftBlock.SetActive(false);
        }
        else if (QuestTracker.desertQuestCount > 5 && QuestTracker.volcanoQuestCount < 3)
        {
            Corruption.SetActive(false);
            DesertBlock.SetActive(false);
            ForestTopRightBlock.SetActive(false);
        }
        else if (QuestTracker.grasslandsQuestCount > 6 && QuestTracker.volcanoQuestCount < 3)
        {
            Corruption.SetActive(false);
            DesertBlock.SetActive(false);
        }
        else if (QuestTracker.grasslandsQuestCount > 5 && QuestTracker.volcanoQuestCount < 3)
        {
            Corruption.SetActive(false);
        }
        else if (QuestTracker.volcanoQuestCount > 2)
        {
            Music.volume = 0.01f;
            Nguard.SetActive(false);
            Sguard.SetActive(false);
            FBon.SetActive(true);
            theFinalBoss.SetActive(true);
            FBoff.SetActive(false);
            DesertBlock.SetActive(false);
            ForestTopLeftBlock.SetActive(false);
            ForestTopRightBlock.SetActive(false);
            Corruption.SetActive(true);
        }
        else
        {
            Corruption.SetActive(true);
            DesertBlock.SetActive(true);
            ForestTopRightBlock.SetActive(true);
            ForestTopLeftBlock.SetActive(true);
        }
    }

    private void SpawnMonsters()
    {
        GameObject Qe1 = Instantiate(GreenGuy, new Vector3(8, -15, 0), transform.rotation);
        Qe1.transform.parent = InvadingMonstersParent.transform;
        GameObject Qe2 = Instantiate(GreenGuy, new Vector3(35, 0, 0), transform.rotation);
        Qe2.transform.parent = InvadingMonstersParent.transform;
        GameObject Qe3 = Instantiate(GreenGuy, new Vector3(7, -37.5f, 0), transform.rotation);
        Qe3.transform.parent = InvadingMonstersParent.transform;
        GameObject Qe4 = Instantiate(GlobbyGlob, new Vector3(3, -20, 0), transform.rotation);
        Qe4.transform.parent = InvadingMonstersParent.transform;
        GameObject Qe5 = Instantiate(Birdy, new Vector3(-14, -27, 0), transform.rotation);
        Qe5.transform.parent = InvadingMonstersParent.transform;
        GameObject Qe6 = Instantiate(Birdy, new Vector3(-5, -6, 0), transform.rotation);
        Qe6.transform.parent = InvadingMonstersParent.transform;
        GameObject Qe7 = Instantiate(GlobbyGlob, new Vector3(28, -30f, 0), transform.rotation);
        Qe7.transform.parent = InvadingMonstersParent.transform;
        GameObject Qe8 = Instantiate(GlobbyGlob, new Vector3(-20, -11, 0), transform.rotation);
        Qe8.transform.parent = InvadingMonstersParent.transform;
        GameObject Qe9 = Instantiate(GlobbyGlob, new Vector3(3, -2, 0), transform.rotation);
        Qe9.transform.parent = InvadingMonstersParent.transform;
        GameObject Qe10 = Instantiate(GlobbyGlob, new Vector3(35, -15, 0), transform.rotation);
        Qe10.transform.parent = InvadingMonstersParent.transform;
    }

    
    IEnumerator SpawnHelpNPCs()
    {

        GameObject NPC1 = Instantiate(GL_TF_1, new Vector3(-2.5f, -2.5f, 0), transform.rotation);
        GameObject NPC2 = Instantiate(GL_TF_2, new Vector3(-1.5f, -15, 0), transform.rotation);
        GameObject NPC3 = Instantiate(GL_TF_3, new Vector3(0.25f, -27.25f, 0), transform.rotation);
        GameObject NPC4 = Instantiate(GL_TF_4, new Vector3(25, -30.5f, 0), transform.rotation);
        GameObject NPC5 = Instantiate(GL_TF_5, new Vector3(18, -10.75f, 0), transform.rotation);

       /* NPC_Script NPC1T = NPC1.GetComponent<NPC_Script>();
        NPC_Script NPC2T = NPC2.GetComponent<NPC_Script>();
        NPC_Script NPC3T = NPC3.GetComponent<NPC_Script>();
        NPC_Script NPC4T = NPC4.GetComponent<NPC_Script>();
        NPC_Script NPC5T = NPC5.GetComponent<NPC_Script>();*/

        yield return new WaitForSeconds(0.1f);

        NPC1.transform.parent = NPCsParent.transform;
        NPC1.GetComponent<NPC_Script>().NPC_Number = 22;
        NPC1.GetComponent<NPC_Script>().disableMovement = true;
        NPC1.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC2.transform.parent = NPCsParent.transform;
        NPC2.GetComponent<NPC_Script>().NPC_Number = 24;
        NPC2.GetComponent<NPC_Script>().disableMovement = false;
        NPC2.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC3.transform.parent = NPCsParent.transform;
        NPC3.GetComponent<NPC_Script>().NPC_Number = 26;
        NPC3.GetComponent<NPC_Script>().disableMovement = true;
        NPC3.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC4.transform.parent = NPCsParent.transform;
        NPC4.GetComponent<NPC_Script>().NPC_Number = 28;
        NPC4.GetComponent<NPC_Script>().disableMovement = false;
        NPC4.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC5.transform.parent = NPCsParent.transform;
        NPC5.GetComponent<NPC_Script>().NPC_Number = 30;
        NPC5.GetComponent<NPC_Script>().disableMovement = true;
        NPC5.GetComponent<NPC_Script>().isTalkingNPC = true;
    }

    IEnumerator SpawnVillageNPCs()
    {

        GameObject NPC1 = Instantiate(GL_TF_1, new Vector3(-2.5f, -2.5f, 0), transform.rotation);
        GameObject NPC2 = Instantiate(GL_TF_2, new Vector3(-1.5f, -15, 0), transform.rotation);
        GameObject NPC3 = Instantiate(GL_TF_3, new Vector3(0.25f, -27.25f, 0), transform.rotation);
        GameObject NPC4 = Instantiate(GL_TF_4, new Vector3(16.5f, -19.5f), transform.rotation);
        GameObject NPC5 = Instantiate(GL_TF_5, new Vector3(18, -10.75f, 0), transform.rotation);
        GameObject NPC6 = Instantiate(GL_TF_6, new Vector3(6.25f, -0.5f, 0), transform.rotation);
        GameObject NPC7 = Instantiate(GL_TF_7, new Vector3(0, -3.25f, 0), transform.rotation);
        GameObject NPC8 = Instantiate(GL_TF_8, new Vector3(-14.25f, -20.75f, 0), transform.rotation);
        GameObject NPC9 = Instantiate(GL_TF_9, new Vector3(5.5f, -12.75f, 0), transform.rotation);
        GameObject NPC10 = Instantiate(GL_TF_10, new Vector3(6.5f, -12.75f, 0), transform.rotation);

        yield return new WaitForSeconds(0.1f);

        NPC1.transform.parent = NPCsParent.transform;
        NPC1.GetComponent<NPC_Script>().NPC_Number = 23;
        NPC1.GetComponent<NPC_Script>().disableMovement = true;
        NPC1.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC2.transform.parent = NPCsParent.transform;
        NPC2.GetComponent<NPC_Script>().NPC_Number = 25;
        NPC2.GetComponent<NPC_Script>().disableMovement = false;
        NPC2.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC3.transform.parent = NPCsParent.transform;
        NPC3.GetComponent<NPC_Script>().NPC_Number = 27;
        NPC3.GetComponent<NPC_Script>().disableMovement = true;
        NPC3.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC4.transform.parent = NPCsParent.transform;
        NPC4.GetComponent<NPC_Script>().NPC_Number = 29;
        NPC4.GetComponent<NPC_Script>().disableMovement = false;
        NPC4.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC5.transform.parent = NPCsParent.transform;
        NPC5.GetComponent<NPC_Script>().NPC_Number = 31;
        NPC5.GetComponent<NPC_Script>().disableMovement = true;
        NPC5.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC6.transform.parent = NPCsParent.transform;
        NPC6.GetComponent<NPC_Script>().NPC_Number = 32;
        NPC6.GetComponent<NPC_Script>().disableMovement = true;
        NPC6.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC7.transform.parent = NPCsParent.transform;
        NPC7.GetComponent<NPC_Script>().NPC_Number = 33;
        NPC7.GetComponent<NPC_Script>().disableMovement = false;
        NPC7.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC8.transform.parent = NPCsParent.transform;
        NPC8.GetComponent<NPC_Script>().NPC_Number = 34;
        NPC8.GetComponent<NPC_Script>().disableMovement = false;
        NPC8.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC9.transform.parent = NPCsParent.transform;
        NPC9.GetComponent<NPC_Script>().NPC_Number = 35;
        NPC9.GetComponent<NPC_Script>().disableMovement = true;
        NPC9.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC9.GetComponent<NPC_Script>().faceEast = true;
        NPC10.transform.parent = NPCsParent.transform;
        NPC10.GetComponent<NPC_Script>().NPC_Number = 36;
        NPC10.GetComponent<NPC_Script>().disableMovement = true;
        NPC10.GetComponent<NPC_Script>().isTalkingNPC = true;
        NPC10.GetComponent<NPC_Script>().faceWest = true;
    }
    
}
