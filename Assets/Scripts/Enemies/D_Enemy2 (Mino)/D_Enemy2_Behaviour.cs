using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Enemy2_Behaviour : MonoBehaviour
{
    private Transform playerTarget;
    public GameObject PositionChecker;
    private Animator anim;
    public GameObject rageIndicator;
    public GameObject stunIndicator;
    [Space]
    public float aggroMaxRange = 7;
    public float aggroMinRange = 0;
    public float countingTime = 0;
    public float speed = 0f;
    public float chargeSpeed = 2f;
    public float direction = 1.0f;
    public float threshold = 4f;
    public Vector3 targetPos;
    [Space]
    public bool touchingPlayer = false;
    public bool isAggro = false;
    public float chargeCD = 4.0f;
    public float chargeTimeCounter = 0f;
    public bool chargeOnCD = false;
    public float chargingTimer = 0f;
    public float chargeLength = 2f;
    public bool isCharging = false;
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

            if (isCharging == false)
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

                rageIndicator.SetActive(false);
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

        if ((chargeCD - chargeTimeCounter) > 0 && (chargeCD - chargeTimeCounter) <= 1)
        {
            rageIndicator.SetActive(true);
        }

        
        if (chargingTimer > chargeLength)
        {
            chargeOnCD = true;
            isCharging = false;
            anim.SetBool("isMoving", false);
            PositionChecker.SetActive(false);
            chargingTimer = 0;
        }

        if (chargeOnCD)
        {
            anim.SetBool("isMoving", false);
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

        if (Vector3.Distance(transform.position, playerTarget.position) <= threshold)
        {
            Debug.Log("Test");
        }


        if (isColliding || isPinned)
        {
            anim.SetBool("isMoving", false);
        }

        dir = (playerTarget.position - transform.position).normalized;
        offsetPos = playerTarget.position + (dir * 2f);

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

        if (wallCheck.collider != null && playerCheck.collider != null && Vector3.Distance(playerTarget.position, transform.position) < 1.25f)
        {
            isPinned = true;
            Debug.DrawLine(transform.position, offsetPos, Color.yellow);
        }
        else
        {
            isPinned = false;
            Debug.DrawLine(transform.position, offsetPos, Color.cyan);
        }
    }

    void ChargeAtPlayer()
    {
        rageIndicator.SetActive(true);
        isCharging = true;
        PositionChecker.SetActive(true);
        targetPos = FindObjectOfType<TargetPosCheck>().GetComponent<TargetPosCheck>().targetPos;
        anim.SetBool("isMoving", true);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, chargeSpeed * Time.deltaTime);
        chargingTimer += Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            PositionChecker.SetActive(false);
            touchingPlayer = true;
            chargeOnCD = true;
            anim.SetBool("isMoving", false);
            isCharging = false;
            chargingTimer = 0;
            StartCoroutine(StunIndicator());

        }

        if (other.collider.CompareTag("Wall"))
        {
            PositionChecker.SetActive(false);
            chargeOnCD = true;
            anim.SetBool("isMoving", false);
            isCharging = false;
            chargingTimer = 0;
            StartCoroutine(StunIndicator());
        }
    }

    IEnumerator StunIndicator()
    {
        stunIndicator.SetActive(true);
        yield return new WaitForSeconds(1f);
        stunIndicator.SetActive(false);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        touchingPlayer = false;
    }
}
