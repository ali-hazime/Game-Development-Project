using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Enemy2_Behaviour : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    public GameObject poisonObj;
    [Space]
    public float aggroMaxRange = 10f;
    public float aggroMinRange = 0f;
    public float aggroAttackRange = 12f;
    public float direction = 0f;
    public float moveSpeed = 0.75f;
    public bool moveVert = false;
    [Space]
    public bool poisonOnCD = false;
    public bool touchingPlayer = false;
    public bool isAggro;
    public bool attackIsOn;
    public bool isAwake = false;
    public bool isColliding = false;
    public bool isPinned = false;
    private Vector3 dir;
    private Vector3 offsetPos;
    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        anim.SetBool("moveVert", false);
        poisonObj.SetActive(false);
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(playerTarget.position, transform.position) <= aggroMaxRange && Vector3.Distance(playerTarget.position, transform.position) >= aggroMinRange)
        {
            isAggro = true;
            isAwake = true;
        }
        else
        {
            anim.SetBool("isMoving", false);
            isAggro = false;
        }
        if (Vector3.Distance(playerTarget.position, transform.position) <= aggroAttackRange)
        {
            attackIsOn = true;
        }
        else
        {
            attackIsOn = false;
        }


        if (isAggro && isColliding == false && isPinned == false)
        {
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

            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, moveSpeed * Time.fixedDeltaTime);
            anim.SetBool("isMoving", true);
            anim.SetFloat("speed", direction);
        }

        if (attackIsOn && isAwake)
        {
            if (poisonOnCD == false)
            {
                StartCoroutine(PoisonAoE());
            }
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

        if (wallCheck.collider != null && playerCheck.collider != null && Vector3.Distance(playerTarget.position, transform.position) < 2.25f)
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

    IEnumerator PoisonAoE()
    {
        poisonObj.SetActive(true);
        yield return new WaitForSeconds(5f);
        StartCoroutine(ResetCD());
        poisonOnCD = true;
    }
    IEnumerator ResetCD()
    {
        poisonObj.SetActive(false);
        yield return new WaitForSeconds(5.0f);
        poisonOnCD = false;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            touchingPlayer = true;
            //anim.SetBool("isMoving", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touchingPlayer = false;
        //anim.SetBool("isMoving", true);
    }

}
