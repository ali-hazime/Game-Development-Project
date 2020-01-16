using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_TEST_NS_Movement : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    public GameObject player;
    private Vector3 pos1 = new Vector3(4, 6, 0);
    private Vector3 pos2 = new Vector3(4, -3, 0);
    public float countingTime = 0;
    public float speed = 1.0f;
    public float direction = 1.0f;
    public bool moveVert = false;
    public bool isMoving = true;
    public bool touchingPlayer = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        anim.SetBool("moveVert", true);
        anim.SetBool("isMoving", true);
    }

    void Update()
    {

        if (touchingPlayer == false)
        {

            //Any movement stuff
            countingTime += Time.deltaTime;

            transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * countingTime) + 1.0f) / 2.0f);

            if (transform.position.y <= -2.99f)
            {
                direction = 1.0f;
            }
            else if (transform.position.y >= 2.99f)
            {
                direction = -1.0f;
            }

            anim.SetFloat("speed", direction);
        }
        else
        {

        }

        anim.SetFloat("moveX", (playerTarget.position.x - transform.position.x));

        if (Mathf.Abs(playerTarget.position.y - transform.position.y) < Mathf.Abs(playerTarget.position.x - transform.position.x))
        {
            anim.SetFloat("moveY", 0f);
        }
        else
        {
            anim.SetFloat("moveY", (playerTarget.position.y - transform.position.y));
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

    //RANDOM MOVE STUFF
    /*
    public float changeTimer = 0;
    public float randomNumber, UDorLR;
    public float speed = 1.0f;
    public GameObject me;
    public bool timeToMove = false;

    void Start()
    {
        findRandom();
        InvokeRepeating("moveALittleRandomly", 5.0f, 5.0f);
    }
    // Update is called once per frame
    void Update()
    {
        
        changeTimer += Time.deltaTime;

        if (changeTimer > randomNumber)
        {
            timeToMove = true;

            changeTimer = 0;
            findRandom();
        }

        if (changeTimer > 5 && timeToMove == true)
        {
            timeToMove = false;
        }

        if (timeToMove == true)
        {
            moveALittleRandomly();
        }
        
    }

    void findRandom()
    {
        randomNumber = Random.Range(7.0f, 12.0f);
    }

    //Moves the NPC a little bit randomly
    void moveALittleRandomly()
    {
        UDorLR = Random.Range(1.0f, 2.0f);

        if (UDorLR > 1.5f)
        {
            if (UDorLR > 1.75f)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(3f, 0f, 0.0f), speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(-3f, 0f, 0.0f), speed * Time.deltaTime);
            }
        }
        else
        {
            if (UDorLR > 1.25f)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 3f, 0.0f), speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, -3f, 0.0f), speed * Time.deltaTime);
            }
        }
    } */
}
