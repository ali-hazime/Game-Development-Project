using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Enemy1_Behaviour : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    [Space]
    public float aggroMaxRange = 7;
    public float aggroMinRange = 0;
    public float countingTime = 0;
    public float speed = 0f;
    public float chargeSpeed = 2f;
    public float direction = 1.0f;
    [Space]
    public bool touchingPlayer = false;
    public bool isAggro = false;
    public float chargeCD = 4.0f;
    public float chargeTimeCounter = 0f;
    public bool chargeOnCD = false;
    public float chargingTimer = 0f;
    public float chargeLength = 4.0f;
    [Space]
    public bool isColliding = false;
    public bool isPinned = false;
    private Vector3 dir;
    private Vector3 offsetPos;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        anim.SetBool("moveVert", false);
        anim.SetBool("isMoving", true);
    }

    void FixedUpdate()
    {
        

        if (Vector3.Distance(playerTarget.position, transform.position) <= aggroMaxRange && Vector3.Distance(playerTarget.position, transform.position) >= aggroMinRange)
        {
            isAggro = true;
        }
        else
        {
            isAggro = false;
        }

        if (isAggro && isColliding == false && isPinned == false)
        {
            chargeTimeCounter += Time.fixedDeltaTime;

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
            anim.SetFloat("speed", speed);

           if (chargeOnCD == false)
            {
                ChargeAtPlayer();
                chargeTimeCounter = 0;
            }
        }

        if (chargeTimeCounter > chargeCD && chargeOnCD)
        {
            chargeOnCD = false;
        }
        
        if (chargingTimer > chargeLength)
        {
            chargeOnCD = true;
            anim.SetBool("isMoving", false);
            chargingTimer = 0;
        }

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

        dir = (playerTarget.position - transform.position).normalized;
        offsetPos = playerTarget.position + (dir * 2f);

        if (isColliding || isPinned)
        {
            anim.SetBool("isMoving", false);
        }

        //Linecast to check for wall/other enemies between monster and player
        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTarget.position, 1 << 15 | 1 << 9);

        if (hit.collider != null)
        {
            isColliding = true;
            Debug.DrawLine(transform.position, playerTarget.position, Color.red);
        }
        else
        {
            isColliding = false;
            Debug.DrawLine(transform.position, playerTarget.position, Color.green);
        }

        //Linecast to make sure player does not get pinned against wall
        RaycastHit2D wallCheck = Physics2D.Linecast(transform.position, offsetPos, 1 << 15);
        RaycastHit2D playerCheck = Physics2D.Linecast(transform.position, offsetPos, 1 << 8);

        if (wallCheck.collider != null && playerCheck.collider != null && Vector3.Distance(playerTarget.position, transform.position) < 1f)
        {
            isPinned = true;
            GameObject.FindWithTag("Player").GetComponent<PlayerChar>().playerPinned(true);
            Debug.DrawLine(transform.position, offsetPos, Color.yellow);
        }
        else
        {
            isPinned = false;
            GameObject.FindWithTag("Player").GetComponent<PlayerChar>().playerPinned(false);
            Debug.DrawLine(transform.position, offsetPos, Color.cyan);
        }
    }

    void ChargeAtPlayer()
    {   
        if (chargeOnCD == false)
        {
            anim.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, chargeSpeed * Time.fixedDeltaTime);
            chargingTimer += Time.fixedDeltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            touchingPlayer = true;
            chargeOnCD = true;
            anim.SetBool("isMoving", false);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        touchingPlayer = false;
    }
}
