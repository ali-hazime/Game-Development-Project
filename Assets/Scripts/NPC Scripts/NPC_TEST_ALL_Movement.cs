using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_TEST_ALL_Movement : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    public GameObject player;
    public GameObject NPCtextbox;
    public NPC_Dialogue Dialogue;
    public float countingTime = 0;
    public float speed = 1.0f;
    public float direction = 1.0f;
    public bool moveVert = false;
    public bool isMoving = true;
    public bool touchingPlayer = false;


    //Diff for each NPC
    //START AT -4, 6, 0
    private Vector3 pos0 = new Vector3(-4, 6, 0);
    private Vector3 pos1 = new Vector3(2, 6, 0);
    private Vector3 pos2 = new Vector3(5, 6, 0);
    private Vector3 pos3 = new Vector3(2, 0, 0);
    private Vector3 pos4 = new Vector3(0, 0, 0);
    public bool dest0 = false;
    public bool dest1 = true;
    public bool dest2 = false;
    public bool dest3 = false;
    public bool dest4 = false;

    public int nextDirection;
    public int whenNext;

    public bool once = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        anim.SetBool("moveVert", false);
        anim.SetBool("isMoving", true);
    }

    void Update()
    {
        if (touchingPlayer == false)
        {

            //Any movement stuff
            countingTime += Time.deltaTime;
            if (dest0 == true)
            {
                anim.SetBool("isMoving", true);
                anim.SetBool("moveVert", false);
                direction = -1.0f;
                transform.position = Vector3.MoveTowards(transform.position, pos0, 0.03f);

                if (transform.position == pos0)
                {
                    if (once == true)
                    {
                        countingTime = 0;
                        nextDirection = Random.Range(0, 2);
                        whenNext = Random.Range(3, 8);
                        once = false;
                    }

                    anim.SetBool("isMoving", false);
                    if (countingTime > whenNext)
                    {
                        switch (nextDirection)
                        {
                            case 0:
                                dest1 = true;
                                direction = 1.0f;
                                break;
                            case 1:
                                dest2 = true;
                                break;
                        }
                        once = true;
                        dest0 = false;
                    }
                }
            }
            else if (dest1 == true)
            {
                anim.SetBool("isMoving", true);
                transform.position = Vector3.MoveTowards(transform.position, pos1, 0.03f);

                if (transform.position == pos1)
                {
                    if (once == true)
                    {
                        countingTime = 0;
                        nextDirection = Random.Range(0, 3);
                        whenNext = Random.Range(3, 8);
                        once = false;
                    }

                    anim.SetBool("isMoving", false);
                    if (countingTime > whenNext)
                    {
                        switch (nextDirection)
                        {
                            case 0: dest0 = true;
                                break;
                            case 1: dest2 = true;
                                break;
                            case 2: dest3 = true;
                                    direction = -1.0f;
                                    anim.SetBool("moveVert", true);
                                break;
                        }
                        once = true;
                        dest1 = false;
                    }
                }
            }
            else if (dest2 == true)
            {
                anim.SetBool("isMoving", true);
                anim.SetBool("moveVert", false);
                direction = 1.0f;
                transform.position = Vector3.MoveTowards(transform.position, pos2, 0.03f);

                if (transform.position == pos2)
                {
                    if (once == true)
                    {
                        countingTime = 0;
                        nextDirection = Random.Range(0, 2);
                        whenNext = Random.Range(3, 8);
                        once = false;
                    }

                    anim.SetBool("isMoving", false);
                    if (countingTime > whenNext)
                    {
                        switch (nextDirection)
                        {
                            case 0:
                                dest0 = true;
                                break;
                            case 1:
                                dest1 = true;
                                direction = -1.0f;
                                break;
                        }
                        once = true;
                        dest2 = false;
                    }
                }
            }
            else if (dest3 == true)
            {
                anim.SetBool("isMoving", true);
                transform.position = Vector3.MoveTowards(transform.position, pos3, 0.03f);

                if (transform.position == pos3)
                {
                    if (once == true)
                    {
                        countingTime = 0;
                        nextDirection = Random.Range(0, 2);
                        whenNext = Random.Range(3, 8);
                        once = false;
                    }

                    anim.SetBool("isMoving", false);
                    if (countingTime > whenNext)
                    {
                        switch (nextDirection)
                        {
                            case 0:
                                dest4 = true;
                                break;
                            case 1:
                                dest1 = true;
                                direction = 1.0f;
                                anim.SetBool("moveVert", true);
                                break;
                        }
                        once = true;
                        dest3 = false;
                    }
                }
            }
            else if (dest4 == true)
            {
                anim.SetBool("isMoving", true);
                anim.SetBool("moveVert", false);
                direction = -1.0f;
                transform.position = Vector3.MoveTowards(transform.position, pos4, 0.03f);

                if (transform.position == pos4)
                {
                    if (once == true)
                    {
                        countingTime = 0;
                        whenNext = Random.Range(3, 8);
                        once = false;
                    }

                    anim.SetBool("isMoving", false);
                    if (countingTime > whenNext)
                    {
                        dest3 = true;
                        direction = 1.0f;
                        once = true;
                        dest4 = false;
                    }
                }
            }

            anim.SetFloat("speed", direction);
        }
        else if(touchingPlayer == true && Input.GetKeyDown(KeyCode.Z))
        {
            NPCtextbox.SetActive(true);
            Dialogue.NPCnumber = 1;
        }

        //anim.SetFloat("moveY", (playerTarget.position.y - transform.position.y));

        if (Mathf.Abs(playerTarget.position.y - transform.position.y) > Mathf.Abs(playerTarget.position.x - transform.position.x))
        {
            anim.SetFloat("moveX", 0f);
            anim.SetFloat("moveY", (playerTarget.position.y - transform.position.y));
        }
        else
        {
            anim.SetFloat("moveX", (playerTarget.position.x - transform.position.x));
            anim.SetFloat("moveY", 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            touchingPlayer = true;
            isMoving = false;
            anim.SetBool("isMoving", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touchingPlayer = false;
        isMoving = false;
        anim.SetBool("isMoving", true);
    }

}
