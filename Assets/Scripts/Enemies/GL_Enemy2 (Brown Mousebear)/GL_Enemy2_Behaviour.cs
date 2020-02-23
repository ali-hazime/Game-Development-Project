using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GL_Enemy2_Behaviour : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    public GameObject player;
    // public GameObject NPCtextbox;
    // public NPC_Dialogue Dialogue;

    public float aggroMaxRange = 7;
    public float aggroMinRange = 0;
    public float countingTime = 0;
    public float speed = 1.0f;
    public float direction = 1.0f;
    public bool moveVert = false;
    public bool isMoving = true;
    public bool touchingPlayer = false;
    public bool doingSomething = false;

    public float FULLTEST;
    //Diff for each NPC
    public Vector3 startPos = new Vector3(0, 0, 0);
    public bool dest0 = false;
    public bool dest1 = true;
    public bool dest2 = false;
    public bool dest3 = false;
    public bool dest4 = false;
    public bool dest5 = false;

    public int nextDirection;
    public int whenNext;

    public bool once = true;
    public bool once2 = true;

    public float newPlace;

    public float waitTime = 0;
    public float stabCoolDown;
    public bool stab;
    public bool isAggroed = false;
    [Space]
    public bool isPinned = false;
    public bool isColliding = false;
    private Vector3 dir;
    private Vector3 offsetPos;


    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        anim.SetBool("moveVert", false);
        anim.SetBool("isMoving", true);
    }

    void Update()
    {
       
        dir = (playerTarget.position - transform.position).normalized;
        offsetPos = playerTarget.position + (dir * 2f);

    }

    private void FixedUpdate()
    {

        //Linecast to check for wall/other enemies between monster and player
        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTarget.position, 1 << 15 | 1 << 9);

        if (hit.collider != null)
        {
            isColliding = true;
            //Debug.DrawLine(transform.position, playerTarget.position, Color.red);
        }
        else
        {
            isColliding = false;
            //Debug.DrawLine(transform.position, playerTarget.position, Color.green);
        }

        //Linecast to make sure player does not get pinned against wall
        RaycastHit2D wallCheck = Physics2D.Linecast(transform.position, offsetPos, 1 << 15);
        RaycastHit2D playerCheck = Physics2D.Linecast(transform.position, offsetPos, 1 << 8);

        if (wallCheck.collider != null && playerCheck.collider != null && Vector3.Distance(playerTarget.position, transform.position) < 2)
        {
            isPinned = true;
            //Debug.DrawLine(transform.position, offsetPos, Color.yellow);
        }
        else
        {
            isPinned = false;
            //Debug.DrawLine(transform.position, offsetPos, Color.cyan);
        }

        if (Vector3.Distance(playerTarget.position, transform.position) <= aggroMaxRange)
        {
            isAggroed = true;
        }
        else
        {
            isAggroed = false;
        }

        if (isAggroed == false)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {

            stabCoolDown += Time.deltaTime;

            if (stabCoolDown > 0.7f && Mathf.Abs(transform.position.y - playerTarget.position.y) + Mathf.Abs(transform.position.x - playerTarget.position.x) < 3)
            {
                doingSomething = true;
                stab = true;
                anim.SetBool("isMoving", false);
                isMoving = false;
                anim.SetBool("stab", true);
                stabCoolDown = 0;
            }

            if (doingSomething == true && waitTime < 1)
            {
                waitTime += Time.deltaTime;
                anim.SetBool("isMoving", false);
                isMoving = false;
            }
            else if (doingSomething == true && waitTime > 0.75)
            {
                doingSomething = false;
                anim.SetBool("isMoving", true);
                isMoving = true;
                waitTime = 0;
            }


            if (stabCoolDown > 0.6f && stab == true)
            {
                anim.SetBool("stab", false);
                stab = false;
            }

            //Move
            if (doingSomething == false && isColliding == false && isPinned == false)
            {
                anim.SetBool("isMoving", true);
                isMoving = true;
                transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, 3.5f * Time.deltaTime);
            }
        }

        if (Mathf.Abs(playerTarget.position.y - transform.position.y) > Mathf.Abs(playerTarget.position.x - transform.position.x))
        {
            anim.SetFloat("moveX", 0f);
            anim.SetFloat("moveY", (playerTarget.position.y - transform.position.y));
            anim.SetBool("moveVert", true);
            direction = playerTarget.position.y - transform.position.y;
        }
        else
        {
            anim.SetFloat("moveX", (playerTarget.position.x - transform.position.x));
            anim.SetFloat("moveY", 0f);
            anim.SetBool("moveVert", false);
            direction = playerTarget.position.x - transform.position.x;
        }

        anim.SetFloat("speed", direction);

        if (isColliding || isPinned)
        {
            anim.SetBool("isMoving", false);
        }
    }
}
