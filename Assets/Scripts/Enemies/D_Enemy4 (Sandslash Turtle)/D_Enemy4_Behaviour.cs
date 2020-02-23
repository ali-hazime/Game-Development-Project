using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Enemy4_Behaviour : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    [Space]
    public int spikeCD = 3;
    public bool spikeOnCD = false;
    [Space]
    public GameObject spikeUpObj;
    public GameObject spikeDownObj;
    public GameObject spikeRightObj;
    public GameObject spikeLeftObj;
    [Space]
    public float aggroMaxRange = 7;
    public float aggroMinRange = 0;
    public float countingTime = 0;
    public float speed = 0f;
    public float direction = 0f;
    public bool moveVert = false;
    public bool isMoving = false;
    public bool touchingPlayer = false;
    [Space]
    public bool isAggroed;
    public bool doingSomething = false;
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
                transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, 3.0f * Time.fixedDeltaTime);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }

            if (Vector3.Distance(playerTarget.position, transform.position) < 4 && spikeOnCD == false)
            {
                shootSpikes();
                anim.SetBool("isMoving", false);
                doingSomething = true;
                StartCoroutine(shootSpikesCD());
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
    }

    void shootSpikes()
    {
        GameObject spikeUp = Instantiate(spikeUpObj, transform.position, transform.rotation);
        Rigidbody2D rbUp = spikeUp.GetComponent<Rigidbody2D>();
        rbUp.velocity = new Vector2(0, 1) * 5f;

        GameObject spikeDown = Instantiate(spikeDownObj, transform.position, transform.rotation);
        Rigidbody2D rbDown = spikeDown.GetComponent<Rigidbody2D>();
        rbDown.velocity = new Vector2(0, -1) * 5f;

        GameObject spikeRight = Instantiate(spikeRightObj, transform.position, transform.rotation);
        Rigidbody2D rbRight = spikeRight.GetComponent<Rigidbody2D>();
        rbRight.velocity = new Vector2(1, 0) * 5f;

        GameObject spikeLeft = Instantiate(spikeLeftObj, transform.position, transform.rotation);
        Rigidbody2D rbLeft = spikeLeft.GetComponent<Rigidbody2D>();
        rbLeft.velocity = new Vector2(-1, 0) * 5f;

        spikeOnCD = true;
    }

    IEnumerator shootSpikesCD()
    {
        yield return new WaitForSeconds(1);
        doingSomething = false;
        yield return new WaitForSeconds(spikeCD-1);
        spikeOnCD = false;
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
