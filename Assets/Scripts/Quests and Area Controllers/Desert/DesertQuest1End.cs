using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertQuest1End : MonoBehaviour
{
    [SerializeField] UIToggle uiToggle;
    [SerializeField] followPlayer cam;
    [SerializeField] PlayerChar player;
    [SerializeField] GameObject standingNPC;
    public TalkToQuest talkToQuest;

    void Awake()
    {
        if (uiToggle == null)
        {
            uiToggle = FindObjectOfType<UIToggle>();
        }

        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (QuestTracker.desertQuestCount == 0)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(CameraPan());
                uiToggle.ToggleQuestLog();
                talkToQuest.UpdateTalkToQuest();
            }
        }
    }

    IEnumerator CameraPan()
    {
        cam.PanCamera(standingNPC.gameObject.transform.position, true);
        player.RestrictMovement(5.5f);
        yield return new WaitForSeconds(3f);
        cam.PanCamera(player.transform.position, true);
        yield return new WaitForSeconds(3f);
        cam.PanCamera(player.transform.position, false);
    }
}
