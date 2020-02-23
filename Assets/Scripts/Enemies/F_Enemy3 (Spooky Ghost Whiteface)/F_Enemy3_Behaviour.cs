using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Enemy3_Behaviour : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;

    public bool doingSomething = false;
    public GameObject scream;
    public int damage = 10;

    public bool screamOnCD = false;

    public float aggroMaxRange = 7;
    public float aggroMinRange = 0;
    public float countingTime = 0;
    public float speed = 2.5f;
    public float direction = 1.0f;
    public bool moveVert = false;
    public bool isMoving = true;
    public bool touchingPlayer = false;

    public bool isAggroed;
    public float fearTime = 2.5f;

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
            if (doingSomething == false && isColliding == false && isPinned == false)
            {
                anim.SetBool("isMoving", true);
                transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, speed * Time.fixedDeltaTime);
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

        if (screamOnCD)
        {
            screamAtPeople();
        }

        anim.SetFloat("speed", direction);

        if (isColliding || isPinned)
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            if (screamOnCD == false)
            {
                other.gameObject.GetComponent<PlayerChar>().TakeDamage(damage);
                other.rigidbody.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                GameObject screamAnimation = Instantiate(scream, transform.position, transform.rotation);
                doingSomething = true;
                screamOnCD = true;
                StartCoroutine(moveAgain());
                StartCoroutine(screamOffCD());
            }
        }
    }

    IEnumerator screamOffCD()
    {
        yield return new WaitForSeconds(5f);
        doingSomething = false;

    }

    IEnumerator moveAgain()
    {
        yield return new WaitForSeconds(fearTime);
        screamOnCD = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerChar>().CancelWalks();
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePosition;
    }

    void screamAtPeople()
    {
        if (Mathf.Abs(playerTarget.position.y - transform.position.y) > Mathf.Abs(playerTarget.position.x - transform.position.x))
        {
            if (playerTarget.position.y - transform.position.y > 0)
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerChar>().WalkingNorth(fearTime);
                playerTarget.position = Vector3.MoveTowards(playerTarget.position,  new Vector3(transform.position.x, transform.position.y + 4, 0), 1.0f * Time.deltaTime);
            }
            else
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerChar>().WalkingSouth(fearTime);
                playerTarget.position = Vector3.MoveTowards(playerTarget.position, new Vector3(transform.position.x, transform.position.y - 4, 0), 1.0f * Time.deltaTime);
            }
        }
        else
        {
            if (playerTarget.position.x - transform.position.x > 0)
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerChar>().WalkingRight(fearTime);
                playerTarget.position = Vector3.MoveTowards(playerTarget.position, new Vector3(transform.position.x + 4, transform.position.y, 0), 1.0f * Time.deltaTime);
            }
            else
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerChar>().WalkingLeft(fearTime);
                playerTarget.position = Vector3.MoveTowards(playerTarget.position, new Vector3(transform.position.x - 4, transform.position.y, 0), 1.0f * Time.deltaTime);
            }
        }
    }
}
