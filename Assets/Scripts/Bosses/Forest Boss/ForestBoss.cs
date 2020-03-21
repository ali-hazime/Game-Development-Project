using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBoss : MonoBehaviour
{

    private Transform playerTarget;
    private Animator anim;
    public ForestBossHealth bossStats;

    public bool dead = false;
    public bool started = false;

    public float speed = 0;
    public float waitTime = 0;
    public bool doingSomething = false;
    public bool doingPhase2 = false;
    [Space]
    //melee basic attack
    public float slashCoolDown;
    public bool slash;
    [Space]
    //shoot basic attack
    public GameObject BApoisonProjectile;
    public float shootCoolDown;
    public float shootCDAmount = 2.5f;
    public bool shootOnCD;

    public bool phase1 = true;
    [Space]
    //phase2
    public GameObject phase2Indcator;
    public GameObject boltsParent;
    public GameObject poisonBigShotU;
    public GameObject poisonBigShotD;
    public GameObject poisonBigShotR;
    public GameObject poisonBigShotL;
    public GameObject poisonBigShotUR;
    public GameObject poisonBigShotUL;
    public GameObject poisonBigShotDR;
    public GameObject poisonBigShotDL;
    public bool phase2 = false;
    public float phase2CD = 5f;
    public float phase2GO = 2f;
    public float phase2Start = 0.7f;
    public bool once1P2 = true;
    public bool once2P2 = true;
    public bool once3P2 = true;
    public bool once4P2 = true;
    [Space]
    //phases3
    public GameObject cloudsParent;
    public GameObject cloud;
    public bool phase3 = false;
    public bool makeCloud = true;
    public float phase3Start = 0.3f;
    [Space]
    public bool isPinned = false;
    private Vector3 dir;
    private Vector3 offsetPos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
    }

    void Update()
    {
        dir = (playerTarget.position - transform.position).normalized;
        offsetPos = playerTarget.position + (dir * 1.5f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (started)
        {
            if(phase2)
            {
                phase2CD -= Time.deltaTime;
            }

            shootCoolDown += Time.deltaTime;
            slashCoolDown += Time.deltaTime;

            anim.SetBool("isMoving", true);
            anim.SetFloat("speed", speed);

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

            if (phase2 == true && phase2CD < 0)
            {
                phase2Indcator.SetActive(false);
                phase2GO -= Time.deltaTime;
                if (phase2GO > 1.5)
                {
                    if (once1P2)
                    {
                        transform.position = new Vector3(-12, 24, 0);
                        ShootPoisonBolt();
                        once1P2 = false;
                    }
                }
                else if (phase2GO > 1)
                {
                    if (once2P2)
                    {
                        transform.position = new Vector3(-13, 17, 0);
                        ShootPoisonBolt();
                        once2P2 = false;
                    }
                }
                else if (phase2GO > 0.5)
                {
                    if (once3P2)
                    {
                        transform.position = new Vector3(1, 25, 0);
                        ShootPoisonBolt();
                        once3P2 = false;
                    }
                }
                else if (phase2GO > 0)
                {
                    if (once4P2)
                    {
                        transform.position = new Vector3(0, 16, 0);
                        ShootPoisonBolt();
                        once4P2 = false;
                    }
                }
                else
                {
                    once1P2 = true;
                    once2P2 = true;
                    once3P2 = true;
                    once4P2 = true;
                    phase2GO = 2;
                    phase2CD = 10;
                }
            }
            else if (phase2 == true && phase2CD < 2)
            {
                phase2Indcator.SetActive(true);
            }

            if (phase3 == true)
            {
                if (makeCloud == true)
                {
                    makeTheCloud();
                }
            }


            if (slashCoolDown > 2f && Mathf.Abs(transform.position.y - playerTarget.position.y) + Mathf.Abs(transform.position.x - playerTarget.position.x) < 3 && doingPhase2 == false)
            {
                doingSomething = true;
                slash = true;
                anim.SetBool("swipe", true);
                slashCoolDown = 0;
            }
            else
            {
                if (shootCoolDown > shootCDAmount && doingPhase2 == false)
                {
                    doingSomething = true;
                    shootBAPoison();
                    shootOnCD = true;
                    shootCoolDown = 0;
                }
                else
                {

                    if (doingSomething == true && waitTime < 1)
                    {
                        waitTime += Time.deltaTime;
                        anim.SetBool("isMoving", false);
                    }
                    else if (doingSomething == true && waitTime > 0.75)
                    {
                        doingSomething = false;
                        anim.SetBool("isMoving", true);
                        waitTime = 0;
                    }
                }
            }

            if (slashCoolDown > 0.5f && slash == true)
            {
                anim.SetBool("swipe", false);
                slash = false;
            }

            if (doingSomething == false && doingPhase2 == false && isPinned == false)
            { 
                transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, 5.0f * Time.deltaTime);
            }


            if (phase2 == false && (float)bossStats.currentHealth / (float)bossStats.maxHealth < phase2Start)
            {
                phase2 = true;
            }
            else if (phase3 == false && (float)bossStats.currentHealth / (float)bossStats.maxHealth < phase3Start)
            {
                phase3 = true;
                makeCloud = true;
            }
        }

        if (bossStats.currentHealth <= 0)
        {
            dead = true;
        }

        RaycastHit2D wallCheck = Physics2D.Linecast(transform.position, offsetPos, 1 << 15);
        RaycastHit2D playerCheck = Physics2D.Linecast(transform.position, offsetPos, 1 << 8);

        if (wallCheck.collider != null && playerCheck.collider != null && Vector3.Distance(playerTarget.position, transform.position) < 1.5)
        {
            isPinned = true;
            anim.SetBool("isMoving", false);
            GameObject.FindWithTag("Player").GetComponent<PlayerChar>().PlayerPinned(true);
            //Debug.DrawLine(transform.position, offsetPos, Color.yellow);
        }
        else
        {
            isPinned = false;
            GameObject.FindWithTag("Player").GetComponent<PlayerChar>().PlayerPinned(false);
            //Debug.DrawLine(transform.position, offsetPos, Color.cyan);
        }

    }

    void shootBAPoison()
    {
        GameObject BApoisonShot = Instantiate(BApoisonProjectile, transform.position, transform.rotation);
        Rigidbody2D rb = BApoisonShot.GetComponent<Rigidbody2D>();
        rb.velocity = (playerTarget.transform.position - transform.position).normalized * 5f;
    }

    void makeTheCloud()
    {
        GameObject pCloud = Instantiate(cloud, transform.position, transform.rotation);
        pCloud.transform.parent = cloudsParent.transform;
        makeCloud = false;
    }

    void ShootPoisonBolt()
    {
        //Up
        GameObject poisonShotU = Instantiate(poisonBigShotU, transform.position, transform.rotation);
        poisonShotU.transform.parent = boltsParent.transform;
        Rigidbody2D rbU = poisonShotU.GetComponent<Rigidbody2D>();
        rbU.velocity = new Vector2(0, 1) * 5f;

        //Down
        GameObject poisonShotD = Instantiate(poisonBigShotD, transform.position, transform.rotation);
        poisonShotD.transform.parent = boltsParent.transform;
        Rigidbody2D rbD = poisonShotD.GetComponent<Rigidbody2D>();
        rbD.velocity = new Vector2(0, -1) * 5f;

        //Left
        GameObject poisonShotL = Instantiate(poisonBigShotL, transform.position, transform.rotation);
        poisonShotL.transform.parent = boltsParent.transform;
        Rigidbody2D rbL = poisonShotL.GetComponent<Rigidbody2D>();
        rbL.velocity = new Vector2(-1, 0) * 5f;

        //Right
        GameObject poisonShotR = Instantiate(poisonBigShotR, transform.position, transform.rotation);
        poisonShotR.transform.parent = boltsParent.transform;
        Rigidbody2D rbR = poisonShotR.GetComponent<Rigidbody2D>();
        rbR.velocity = new Vector2(1, 0) * 5f;

        //UpRight
        GameObject poisonShotUR = Instantiate(poisonBigShotUR, transform.position, transform.rotation);
        poisonShotUR.transform.parent = boltsParent.transform;
        Rigidbody2D rbUR = poisonShotUR.GetComponent<Rigidbody2D>();
        rbUR.velocity = new Vector2(1, 1) * 5f;

        //UpLeft
        GameObject poisonShotUL = Instantiate(poisonBigShotUL, transform.position, transform.rotation);
        poisonShotUL.transform.parent = boltsParent.transform;
        Rigidbody2D rbUL = poisonShotUL.GetComponent<Rigidbody2D>();
        rbUL.velocity = new Vector2(-1, 1) * 5f;

        //DownRight
        GameObject poisonShotDR = Instantiate(poisonBigShotDR, transform.position, transform.rotation);
        poisonShotDR.transform.parent = boltsParent.transform;
        Rigidbody2D rbDR = poisonShotDR.GetComponent<Rigidbody2D>();
        rbDR.velocity = new Vector2(1, -1) * 5f;

        //DownLeft
        GameObject poisonShotDL = Instantiate(poisonBigShotDL, transform.position, transform.rotation);
        poisonShotDL.transform.parent = boltsParent.transform;
        Rigidbody2D rbDL = poisonShotDL.GetComponent<Rigidbody2D>();
        rbDL.velocity = new Vector2(-1, -1) * 5f;
    }

    private void OnTriggerStay2D(Collider2D thing)
    {
        if (phase3 == true)
        {
            if (thing.CompareTag("poisonCloud"))
            {
                makeCloud = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D thing)
    {
        if (phase3 == true)
        {
            if (thing.CompareTag("poisonCloud"))
            {
                makeCloud = true;
            }
        }
    }
}
