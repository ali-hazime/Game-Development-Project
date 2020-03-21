using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GL_Enemy4_Behaviour : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    [Space]
    public int damage = 50;
    public GameObject explosion;
    [Space]
    public float aggroMaxRange = 7;
    public float aggroMinRange = 0;
    public float countingTime = 0;
    public float speed = 1.0f;
    public float direction = 1.0f;
    public bool moveVert = false;
    public bool isMoving = true;
    public bool touchingPlayer = false;
    [Space]
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
    public bool isAggroed = false;

    public float newPlace;
    [Space]
    public bool isColliding = false;
    private PlayerChar player;
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }

    void Start()
    {
        startPos = this.gameObject.transform.position;
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        anim.SetBool("moveVert", false);
        anim.SetBool("isMoving", true);
    }

    private void FixedUpdate()
    {

        //Linecast to check for wall/other enemies between monster and player
        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTarget.position, 1 << 15 | 1 << 9 | 1 << 4);

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
            /*
            //Any movement stuff
            countingTime += Time.fixedDeltaTime;
            if (dest0 == true)
            {
                anim.SetBool("isMoving", true);
                anim.SetBool("moveVert", false);
                anim.SetFloat("moveX", -1f);
                anim.SetFloat("moveY", (0f));
                anim.SetFloat("speed", direction);

                direction = -1.0f;

                if (once2 == true)
                {
                    newPlace = startPos.x - 1;
                    once2 = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(newPlace, startPos.y, 0), 3 * Time.fixedDeltaTime);

                if (transform.position.x == newPlace)
                {
                    if (once == true)
                    {
                        countingTime = 0;
                        if (transform.position.x == startPos.x + 1)
                        {
                            nextDirection = Random.Range(1, 4);
                        }
                        else
                        {
                            nextDirection = Random.Range(0, 2);
                        }

                        whenNext = Random.Range(3, 8);
                        once = false;
                    }

                    anim.SetBool("isMoving", false);
                    anim.SetFloat("moveX", -1f);
                    anim.SetFloat("moveY", (0f));
                    // anim.SetBool("moveVert", false);


                    if (countingTime > whenNext)
                    {
                        dest0 = false;
                        switch (nextDirection)
                        {
                            case 0:
                                dest2 = true;
                                break;
                            case 1:
                                dest1 = true;
                                break;
                            case 2:
                                dest4 = true;
                                break;
                            case 3:
                                dest0 = true;
                                break;
                        }
                        once2 = true;
                        once = true;
                    }
                }
            }
            else if (dest1 == true)
            {
                anim.SetBool("isMoving", true);
                anim.SetBool("moveVert", false);
                anim.SetFloat("moveX", 1f);
                anim.SetFloat("moveY", (0f));
                anim.SetFloat("speed", direction);

                direction = 1.0f;

                if (once2 == true)
                {
                    newPlace = startPos.x + 1;
                    once2 = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(newPlace, startPos.y, 0), 3 * Time.fixedDeltaTime);

                if (transform.position.x == newPlace)
                {
                    if (once == true)
                    {
                        countingTime = 0;
                        if (transform.position.x == startPos.x + 1)
                        {
                            nextDirection = Random.Range(1, 4);
                        }
                        else
                        {
                            nextDirection = Random.Range(0, 2);
                        }
                        whenNext = Random.Range(3, 8);
                        once = false;
                    }

                    anim.SetBool("isMoving", false);
                    anim.SetFloat("moveX", 1f);
                    anim.SetFloat("moveY", (0f));
                    // anim.SetBool("moveVert", false);

                    if (countingTime > whenNext)
                    {
                        dest1 = false;
                        switch (nextDirection)
                        {
                            case 0:
                                dest3 = true;
                                break;
                            case 1:
                                dest0 = true;
                                break;
                            case 2:
                                dest4 = true;
                                break;
                            case 3:
                                dest1 = true;
                                break;
                        }
                        once2 = true;
                        once = true;
                    }
                }
            }
            else if (dest2 == true)
            {
                anim.SetBool("isMoving", true);
                anim.SetBool("moveVert", false);
                anim.SetFloat("moveX", 1f);
                anim.SetFloat("moveY", (0f));
                anim.SetFloat("speed", direction);

                direction = 1.0f;
                if (once2 == true)
                {
                    newPlace = startPos.x + 2;
                    once2 = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(newPlace, startPos.y, 0), 3 * Time.fixedDeltaTime);

                if (transform.position.x == newPlace)
                {
                    if (once == true)
                    {
                        countingTime = 0;
                        nextDirection = Random.Range(0, 2);
                        whenNext = Random.Range(3, 8);
                        once = false;
                    }


                    // nextDirection = Random.Range(0, 2);


                    anim.SetBool("isMoving", false);
                    anim.SetFloat("moveX", 1f);
                    anim.SetFloat("moveY", (0f));
                    // anim.SetBool("moveVert", false);

                    if (countingTime > whenNext)
                    {
                        switch (nextDirection)
                        {
                            case 0:
                                dest0 = true;
                                break;
                            case 1:
                                dest3 = true;
                                break;
                        }
                        once2 = true;
                        once = true;
                        dest2 = false;
                    }
                }
            }
            else if (dest3 == true)
            {
                anim.SetBool("isMoving", true);
                anim.SetBool("moveVert", false);
                anim.SetFloat("moveX", -1f);
                anim.SetFloat("moveY", (0f));
                anim.SetFloat("speed", direction);

                direction = -1.0f;

                if (once2 == true)
                {
                    newPlace = startPos.x - 2;
                    once2 = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(newPlace, startPos.y, 0), 3 * Time.fixedDeltaTime);

                if (transform.position.x == newPlace)
                {
                    if (once == true)
                    {
                        countingTime = 0;
                        nextDirection = Random.Range(0, 2);
                        whenNext = Random.Range(3, 8);
                        once = false;
                    }

                    anim.SetBool("isMoving", false);
                    anim.SetFloat("moveX", -1f);
                    anim.SetFloat("moveY", (0f));
                    // anim.SetBool("moveVert", false);

                    if (countingTime > whenNext)
                    {
                        switch (nextDirection)
                        {
                            case 0:
                                dest1 = true;
                                break;
                            case 1:
                                dest2 = true;
                                break;
                        }
                        once2 = true;
                        once = true;
                        dest3 = false;
                    }
                }
            }
            else if (dest4 == true)
            {
                anim.SetBool("isMoving", true);
                anim.SetBool("moveVert", true);
                anim.SetFloat("moveX", 0f);
                anim.SetFloat("moveY", (-1f));
                anim.SetFloat("speed", direction);

                direction = -1.0f;

                if (once2 == true)
                {
                    newPlace = startPos.y - 1;
                    once2 = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPos.x + 1, newPlace, 0), 3 * Time.fixedDeltaTime);

                if (transform.position.y == newPlace)
                {
                    if (once == true)
                    {
                        countingTime = 0;
                        whenNext = Random.Range(3, 8);
                        once = false;
                    }

                    anim.SetBool("isMoving", false);
                    anim.SetFloat("moveX", 0f);
                    anim.SetFloat("moveY", (-1f));
                    // anim.SetBool("moveVert", false);

                    if (countingTime > whenNext)
                    {
                        dest5 = true;

                        once2 = true;
                        once = true;
                        dest4 = false;
                    }
                }
            }
            else if (dest5 == true)
            {
                anim.SetBool("isMoving", true);
                anim.SetBool("moveVert", true);
                anim.SetFloat("moveX", 0f);
                anim.SetFloat("moveY", (1f));
                anim.SetFloat("speed", direction);

                direction = 1.0f;

                if (once2 == true)
                {
                    newPlace = startPos.y + 1;
                    once2 = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPos.x + 1, newPlace, 0), 3 * Time.fixedDeltaTime);

                if (transform.position.y == newPlace)
                {
                    if (once == true)
                    {
                        countingTime = 0;
                        nextDirection = Random.Range(0, 2);
                        whenNext = Random.Range(3, 8);
                        once = false;
                    }

                    anim.SetBool("isMoving", false);
                    anim.SetFloat("moveX", 0f);
                    anim.SetFloat("moveY", (1f));
                    //anim.SetBool("moveVert", false);

                    if (countingTime > whenNext)
                    {
                        switch (nextDirection)
                        {
                            case 0:
                                dest0 = true;
                                break;
                            case 1:
                                dest1 = true;
                                break;
                        }

                        once2 = true;
                        once = true;
                        dest5 = false;
                    }
                }
            }
            */
            anim.SetFloat("speed", direction); 

        }
        else if (isColliding == false)
        {
            anim.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, 2.5f * Time.fixedDeltaTime);
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
        if (isColliding)
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            player.TakeDamage(damage);
            GameObject deathAnimation = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
