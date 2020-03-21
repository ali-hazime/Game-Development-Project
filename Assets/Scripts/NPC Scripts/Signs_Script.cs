using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signs_Script : MonoBehaviour
{
    public int NPC_Number;
    public bool isTalkingNPC;
    public GameObject NPCtextbox;
    public NPC_Dialogue Dialogue;

    public bool touchingPlayer;

    
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

    private void Update()
    {
        if (touchingPlayer == true && Input.GetKeyDown(KeyCode.Z))
        {
            if (isTalkingNPC == true && NPCtextbox.activeSelf == false)
            {
                NPCtextbox.SetActive(true);
                Dialogue.ConvoReset(NPC_Number, 0);
                Dialogue.once = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            touchingPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            touchingPlayer = false;
        }
    }
}
