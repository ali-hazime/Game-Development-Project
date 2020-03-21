using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderEncounterController : MonoBehaviour
{
    [SerializeField] GameObject grasslandsGuard;
    [SerializeField] NPC_GLelder grasslandsElder;
    [SerializeField] QuestController questController;
    [SerializeField] followPlayer followPlayer;
    [SerializeField] PlayerChar player;
    public TalkToQuest talkToQuest;
    public GameObject NPCtextbox;
    public NPC_Dialogue Dialogue;

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

        if (grasslandsElder == null)
        {
            grasslandsElder = FindObjectOfType<NPC_GLelder>();
        }
    }

    private void FixedUpdate()
    {
        if (questController == null)
        {
            questController = FindObjectOfType<QuestController>();
        }
    }

    public void SpeakWithElder()
    {
        StartCoroutine(GuardEnters());
        talkToQuest.UpdateTalkToQuest();
    }
    public void SpeakWithElder2()
    {
        talkToQuest.UpdateTalkToQuest();
        StartCoroutine(AcceptCaveQuest());
    }

    IEnumerator AcceptCaveQuest()
    {
        yield return new WaitForSeconds(2f);
        questController.StartQuest(QuestTracker.grasslandsQuestCount, "gM");
        QuestTracker.questType = "gM";
    }

    public void SpeakWithElder3()
    {
        talkToQuest.UpdateTalkToQuest();
    }

    public void SpeakWithElder4()
    {
        talkToQuest.UpdateTalkToQuest();
    }

    IEnumerator GuardEnters()
    {
        grasslandsGuard.SetActive(true);
        yield return new WaitForSeconds(1f);
        followPlayer.PanCamera(grasslandsGuard.gameObject.transform.position, true);
        player.RestrictMovement(5f);
        yield return new WaitForSeconds(2f);
        NPCtextbox.SetActive(true);
        Dialogue.ConvoReset(13, 0);
        Dialogue.once = true;
        yield return new WaitForSeconds(2f);
        followPlayer.PanCamera(player.transform.position, true);
        yield return new WaitForSeconds(2f);
        followPlayer.PanCamera(player.transform.position, false);
        grasslandsGuard.SetActive(false);
        questController.StartQuest(QuestTracker.grasslandsQuestCount, "gM");
        QuestTracker.questType = "gM";
    }
}
