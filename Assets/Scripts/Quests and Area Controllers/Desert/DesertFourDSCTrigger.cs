using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertFourDSCTrigger : MonoBehaviour
{
    [SerializeField] int NPC_Number = 44;
    [SerializeField] bool isTalkingNPC;
    public GameObject NPCtextbox;
    public NPC_Dialogue Dialogue;

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


    private void OnTriggerEnter2D(Collider2D thing)
    {
        if (QuestTracker.desertQuestCount == 2)
        {
            if (thing.CompareTag("Player"))
            {
                NPCtextbox.SetActive(true);
                Dialogue.ConvoReset(NPC_Number, 0);
                Dialogue.once = true;
                Destroy(this.gameObject);
            }
        }
    
    }
}
