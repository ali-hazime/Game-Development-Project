using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerNPCScript : MonoBehaviour
{
    public int NPC_Number;
    public bool isTalkingNPC;
    public GameObject NPCtextbox;
    public NPC_Dialogue Dialogue;
    private Transform playerTarget;
    private Animator anim;
    [SerializeField] PlayerChar p;
    [Space]
    public float countingTime = 0;
    public float speed = 1.0f;
    public float direction = 1.0f;
    public bool moveVert = false;
    public bool isMoving;
    public bool touchingPlayer;
    public bool disableMovement;
    [Space]
    public bool faceNorth = false;
    public bool faceSouth = false;
    public bool faceEast = false;
    public bool faceWest = false;


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
        if (p == null)
        {
            p = FindObjectOfType<PlayerChar>();
        }
    }
    void Start()
    {
        if (anim == null)
        {
            anim = this.gameObject.GetComponent<Animator>();
        }

        playerTarget = FindObjectOfType<PlayerChar>().transform;
        anim.SetBool("moveVert", false);
        anim.SetBool("isMoving", false);
        anim.SetFloat("moveY", -1f);
    }


    private void Update()
    {
        if (touchingPlayer == true && Input.GetKeyDown(KeyCode.Z))
        {
            p.playerCurrentHealth += p.playerMaxHealth;

            if (isTalkingNPC == true && NPCtextbox.activeSelf == false)
            {
                NPCtextbox.SetActive(true);
                Dialogue.ConvoReset(NPC_Number, 0);
                Dialogue.once = true;
            }
        }
        /*if (QuestTracker.snowMountainQuestCount > 2)
        {
            NPC_Number = 78;
        }*/
    }

    void FixedUpdate()
    {
        if (faceSouth)
        {
            anim.SetBool("isMoving", false);
            anim.SetFloat("moveX", 0f);
            anim.SetFloat("moveY", -1f);
        }
        else if (faceNorth)
        {
            anim.SetBool("isMoving", false);
            anim.SetFloat("moveX", 0f);
            anim.SetFloat("moveY", 1f);
        }
        else if (faceWest)
        {
            anim.SetBool("isMoving", false);
            anim.SetFloat("moveX", -1f);
            anim.SetFloat("moveY", 0f);
        }
        else if (faceEast)
        {
            anim.SetBool("isMoving", false);
            anim.SetFloat("moveX", 1f);
            anim.SetFloat("moveY", 0f);
        }

            anim.SetBool("isMoving", false);


        if (touchingPlayer)
        {
            if (Mathf.Abs(playerTarget.position.y - transform.position.y) > Mathf.Abs(playerTarget.position.x - transform.position.x))
            {
                anim.SetFloat("moveX", 0f);
                anim.SetFloat("moveY", (playerTarget.position.y - transform.position.y));
                anim.SetBool("moveVert", true);
                speed = playerTarget.position.y - transform.position.y;
            }
            else
            {
                anim.SetFloat("moveX", (playerTarget.position.x - transform.position.x));
                anim.SetFloat("moveY", 0f);
                anim.SetBool("moveVert", false);
                speed = playerTarget.position.x - transform.position.x;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            touchingPlayer = true;
            isMoving = false;
            anim.SetBool("isMoving", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            touchingPlayer = false;
            isMoving = false;
            //anim.SetBool("isMoving", true);
        }
    }

}
