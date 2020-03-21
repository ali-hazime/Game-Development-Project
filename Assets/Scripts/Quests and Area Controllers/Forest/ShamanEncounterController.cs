using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanEncounterController : MonoBehaviour
{
    [SerializeField] NPC_ForestShaman forestShaman;
    [SerializeField] ForestQIC forestQIC;
    [SerializeField] QuestController questController;
    [SerializeField] followPlayer camPan;
    [SerializeField] PlayerChar player;
    [SerializeField] UIToggle uiToggle;
    public TalkToQuest talkToQuest;
    public GameObject NPCtextbox;
    public NPC_Dialogue Dialogue;
    public GameObject totem1;
    public GameObject totem2;
    public GameObject totem3;
    public GameObject poisonParent;
    public bool inProgress = false;

    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
        if (NPCtextbox == null)
        {
            NPCtextbox = FindObjectOfType<NPC_Dialogue>().gameObject;
        }

        if (Dialogue == null)
        {
            Dialogue = FindObjectOfType<NPC_Dialogue>();
        }

        if (forestShaman == null)
        {
            forestShaman = FindObjectOfType<NPC_ForestShaman>();
        }

        if (forestQIC == null)
        {
            forestQIC = FindObjectOfType<ForestQIC>();
        }

        if (uiToggle == null)
        {
            uiToggle = FindObjectOfType<UIToggle>();
        }

        if (QuestTracker.forestQuestCount == 0 && QuestTracker.questInProgress)
        {
            inProgress = true;
            forestShaman.gameObject.transform.position = new Vector3(28, 66, 0);
        }

        if (QuestTracker.forestQuestCount == 0 && !QuestTracker.questInProgress)
        {
            forestShaman.transform.position = new Vector3(15, 5.5f, 0);
        }

        if (QuestTracker.forestQuestCount >= 3)
        {
            poisonParent.SetActive(false);
        }

        if (QuestTracker.forestQuestCount >= 1 && QuestTracker.forestQuestCount < 5)
        {
            forestShaman.gameObject.transform.position = new Vector3(-123, 10, 0);
        }

        if (QuestTracker.forestQuestCount >= 5)
        {
            forestShaman.gameObject.transform.position = new Vector3(28, 66, 0);
        }
        
    }

    private void FixedUpdate()
    {
        if (questController == null)
        {
            questController = FindObjectOfType<QuestController>();
        }
    }

    public void FirstShamanInteraction()
    {
        if (!inProgress)
        {
            StartCoroutine(ShamanInteraction());
        }  
    }
    public void SpeakWithShaman()
    {
        QuestTracker.fQ2_Item1 = true;
        QuestTracker.fQ2_Item2 = true;
        QuestTracker.fQ2_Item3 = true;
        talkToQuest.UpdateTalkToQuest();
        StartCoroutine(AcceptTotemQuest());
    }

    public void SpeakWithShaman2()
    {
        QuestTracker.allObjCompleted = true;
        StartCoroutine(TurnInTotems());
        StartCoroutine(AcceptProtectQuest());
    }

    public void SpeakWithShaman3()
    {
        uiToggle.ToggleQuestLog();
        questController.StartQuest(QuestTracker.forestQuestCount, "fM"); // accepting boss quest
        QuestTracker.questType = "fM";
    }

    public void SpeakWithShaman4()
    {
        uiToggle.ToggleQuestLog();
        talkToQuest.UpdateTalkToQuest();
    }

    IEnumerator TurnInTotems()
    {
        yield return new WaitForSeconds(1f);
        talkToQuest.UpdateTalkToQuest();
    }

    IEnumerator ShamanInteraction()
    {
        yield return new WaitForSeconds(0.2f);
        player.RestrictMovement(5f);
        yield return new WaitForSeconds(1f);
        forestShaman.exclMark.GetComponent<SpriteRenderer>().enabled = false;
        NPCtextbox.SetActive(true);
        Dialogue.ConvoReset(76, 0);
        Dialogue.once = true;
        
        yield return new WaitForSeconds(2f);
        uiToggle.ToggleQuestLog();
        questController.StartQuest(QuestTracker.forestQuestCount, "fM");
        QuestTracker.questType = "fM";
        yield return new WaitForSeconds(1f);
        StartCoroutine(ShamanFade());
        yield return new WaitForSeconds(1.1f);
        forestShaman.gameObject.transform.position = new Vector3(28, 66, 0);
        forestShaman.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 225f / 255f);
    }

    IEnumerator ShamanFade()
    {
        forestShaman.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 225f / 255f);
        yield return new WaitForSeconds(0.2f);
        forestShaman.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 200f / 255f);
        yield return new WaitForSeconds(0.2f);
        forestShaman.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 150f / 255f);
        yield return new WaitForSeconds(0.2f);
        forestShaman.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 100f / 255f);
        yield return new WaitForSeconds(0.2f);
        forestShaman.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 50f / 255f);
        yield return new WaitForSeconds(0.2f);
        forestShaman.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0f / 255f);
    }

    IEnumerator AcceptTotemQuest()
    {
        yield return new WaitForSeconds(2f);
        uiToggle.ToggleQuestLog();
        questController.StartQuest(QuestTracker.forestQuestCount, "fM");
        QuestTracker.questType = "fM";
        yield return new WaitForSeconds(10f);
        QuestTracker.allObjCompleted = false;
        yield return new WaitForSeconds(80f);
        StartCoroutine(ShamanFade());
        forestShaman.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1.1f);
        forestShaman.gameObject.transform.position = new Vector3(-123, 10, 0);
        forestShaman.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 225f / 255f);
        forestShaman.GetComponent<Collider2D>().enabled = true;

    }

    IEnumerator AcceptProtectQuest()
    {
        yield return new WaitForSeconds(2f);
        uiToggle.ToggleQuestLog();
        questController.StartQuest(QuestTracker.forestQuestCount, "fM");
        QuestTracker.questType = "fM";
        forestShaman.faceSouth = true;
        yield return new WaitForSeconds(1f);
        forestQIC.FullTotemShow();
        StartCoroutine(ForestQuest3Begin());
    }

    IEnumerator ForestQuest3Begin()
    {
        // script to spawn monsters
        yield return new WaitForSeconds(60f);
        // stop spawning monsters
        talkToQuest.UpdateTalkToQuest();
        //StartCoroutine(FadePoison());
        yield return new WaitForSeconds(1.5f);
        poisonParent.SetActive(false);
    }
}
