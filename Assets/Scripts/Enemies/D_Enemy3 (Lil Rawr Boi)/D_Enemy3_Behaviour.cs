using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Enemy3_Behaviour : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    public GameObject biteN;
    public GameObject biteS;
    public GameObject biteE;
    public GameObject biteW;
    [Space]
    public float aggroMaxRange = 7;
    public float aggroMinRange = 0;
    public float countingTime = 0;
    public float speed = 5f;
    public float direction = 1.0f;
    public bool moveVert = false;
    public bool isMoving = true;
    public bool touchingPlayer = false;
    [Space] 
    public bool isAggroed;
    public bool doingSomething = false;
    public bool biteOnCD = false;
    public int biteCD = 4;
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

        if(wallCheck.collider != null && playerCheck.collider != null && Vector3.Distance(playerTarget.position, transform.position) < 2)
        {
            isPinned = true;
            GameObject.FindWithTag("Player").GetComponent<PlayerChar>().playerPinned(true);

            //Debug.DrawLine(transform.position, offsetPos, Color.yellow);
        }
        else
        {
            isPinned = false;
            GameObject.FindWithTag("Player").GetComponent<PlayerChar>().playerPinned(false);

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
            if (touchingPlayer == false && doingSomething == false && isColliding == false && isPinned == false)
            {
                anim.SetBool("isMoving", true);
                transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }

            if (Vector3.Distance(playerTarget.position, transform.position) < 4 && biteOnCD == false)
            {
                anim.SetBool("isMoving", false);
                biteOnCD = true;
                doingSomething = true;
                biteAttack();
                StartCoroutine(bite());
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



    void biteAttack()
    {
        if (Mathf.Abs(playerTarget.position.y - transform.position.y) > Mathf.Abs(playerTarget.position.x - transform.position.x))
        {
            if (playerTarget.position.y - transform.position.y > 0)
            {
                StartCoroutine(biteNorth());
            }
            else
            {
                StartCoroutine(biteSouth());
            }
        }
        else
        {
            if (playerTarget.position.x - transform.position.x > 0)
            {
                StartCoroutine(biteEast());
            }
            else
            {
                StartCoroutine(biteWest());
            }
        }
    }

    IEnumerator biteNorth()
    {
        biteN.SetActive(true);
        yield return new WaitForSeconds(0.99f);
        biteN.SetActive(false);
    }

    IEnumerator biteSouth()
    {
        biteS.SetActive(true);
        yield return new WaitForSeconds(0.99f);
        biteS.SetActive(false);
    }

    IEnumerator biteEast()
    {
        biteE.SetActive(true);
        yield return new WaitForSeconds(0.99f);
        biteE.SetActive(false);
    }

    IEnumerator biteWest()
    {
        biteW.SetActive(true);
        yield return new WaitForSeconds(0.99f);
        biteW.SetActive(false);
    }

    IEnumerator bite()
    {
        yield return new WaitForSeconds(1);
        doingSomething = false;
        yield return new WaitForSeconds(biteCD-1);
        biteOnCD = false;
    }

    IEnumerator Go()
    {
        yield return new WaitForSeconds(1);
        touchingPlayer = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            touchingPlayer = true;
            StartCoroutine(Go());
        }
    }
}
