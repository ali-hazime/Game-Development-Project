using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_Enemy2_Behaviour : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    public Transform firePoint;
    public GameObject tornado;
    [Space]
    public float aggroMaxRange = 7;
    public float aggroMinRange = 0;
    public float countingTime = 0;
    public float moveSpeed = 1.0f;
    public float direction = 1.0f;
    [Space]
    public bool moveVert = false;
    public bool isMoving = true;
    public bool touchingPlayer = false;
    public bool isAggro = false;
    public bool isAttackAggro;
    public bool isColliding = false;
    [Space]
    public float shootCD = 5.0f;
    public float shootTimer = 0;
    public bool shootOnCD = false;
    public int burnDamage;
    public float burnLength;
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
    public float newPlace;
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

    void FixedUpdate()
    {
        shootTimer += Time.fixedDeltaTime;
        if (Vector3.Distance(playerTarget.position, transform.position) <= aggroMaxRange && Vector3.Distance(playerTarget.position, transform.position) >= aggroMinRange)
        {
            isAggro = true;
        }
        else
        {
            isAggro = false;
        }

        if (Vector3.Distance(playerTarget.position, transform.position) <= aggroMaxRange)
        {
            isAttackAggro = true;
        }

        else
        {
            isAttackAggro = false;
        }

        if (isAggro && isColliding == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, moveSpeed * Time.fixedDeltaTime);
            anim.SetBool("isMoving", true);
            anim.SetFloat("speed", direction);
        }

        if (isAttackAggro)
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
            anim.SetFloat("speed", direction);
        }

        if (isAttackAggro && shootOnCD == false)
        {
            ShootProjectile();
            shootOnCD = true;
            shootTimer = 0;
        }

        if (shootTimer > shootCD && shootOnCD == true)
        {
            shootOnCD = false;
        }

        if (touchingPlayer == false && isAttackAggro == false)
        {
            /*
            //Any movement stuff
            countingTime += Time.fixedDeltaTime;
            if (dest0 == true)
            {
                anim.SetBool("isMoving", true);
                anim.SetBool("moveVert", false);
                direction = -1.0f;

                if (once2 == true)
                {
                    newPlace = transform.position.x - 1;
                    once2 = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(newPlace, transform.position.y, 0), 0.03f);

                if (transform.position.x == newPlace)
                {
                    if (once == true)
                    {
                        countingTime = 0;
                        if (startPos.x + transform.position.x == 0)
                        {
                            nextDirection = Random.Range(0, 2);
                        }
                        else
                        {
                            nextDirection = Random.Range(1, 4);
                        }

                        whenNext = Random.Range(3, 8);
                        once = false;
                    }

                    anim.SetBool("isMoving", false);

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
                direction = 1.0f;

                if (once2 == true)
                {
                    newPlace = transform.position.x + 1;
                    once2 = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(newPlace, transform.position.y, 0), 0.03f);

                if (transform.position.x == newPlace)
                {
                    if (once == true)
                    {
                        countingTime = 0;
                        if (startPos.x + transform.position.x == 2)
                        {
                            nextDirection = Random.Range(0, 2);
                        }
                        else
                        {
                            nextDirection = Random.Range(1, 4);
                        }
                        whenNext = Random.Range(3, 8);
                        once = false;
                    }

                    anim.SetBool("isMoving", false);
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
                direction = 1.0f;
                if (once2 == true)
                {
                    newPlace = transform.position.x + 2;
                    once2 = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(newPlace, transform.position.y, 0), 0.03f);

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
                direction = -1.0f;

                if (once2 == true)
                {
                    newPlace = transform.position.x - 2;
                    once2 = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(newPlace, transform.position.y, 0), 0.03f);

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
                direction = -1.0f;

                if (once2 == true)
                {
                    newPlace = transform.position.y - 1;
                    once2 = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, newPlace, 0), 0.03f);

                if (transform.position.y == newPlace)
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
                direction = 1.0f;

                if (once2 == true)
                {
                    newPlace = transform.position.y + 1;
                    once2 = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, newPlace, 0), 0.03f);

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

        if (isColliding)
        {
            anim.SetBool("isMoving", false);
        }

        //Linecast to check for wall/other enemies between monster and player
        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTarget.position, 1 << 15 | 1 << 9 | 1 << 4);

        if (hit.collider != null)
        {
            isColliding = true;
            //Debug.Log(hit.collider);
            Debug.DrawLine(transform.position, playerTarget.position, Color.red);
        }
        else
        {
            isColliding = false;
            Debug.DrawLine(transform.position, playerTarget.position, Color.green);
        }
    }

    void ShootProjectile()
    {
        GameObject Nado = Instantiate(tornado, firePoint.position, firePoint.rotation);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            touchingPlayer = true;
            isMoving = false;
            anim.SetBool("isMoving", false);
            player.BurnPlayer(true, burnLength, burnDamage);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touchingPlayer = false;
        isMoving = false;
        anim.SetBool("isMoving", true);
    }
}
