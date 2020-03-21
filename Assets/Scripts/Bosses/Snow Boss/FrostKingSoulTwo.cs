using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrostKingSoulTwo : MonoBehaviour
{
    private GameObject playerTarget;
    private Animator anim;
    public SoulHealthTwo healthScript;
    public GameObject currentHP;
    public GameObject maxHP;
    public GameObject EyeLeft;
    public GameObject EyeRight;
    public GameObject ArrowDown;
    public GameObject ArrowRight;
    public GameObject ArrowLeft;
    public GameObject basicNorth;
    public GameObject basicSouth;
    public GameObject basicEast;
    public GameObject basicWest;
    public GameObject Pillar;
    public GameObject Pillars;
    public GameObject Arrows;
    public SnowBossEnounter controller;
    [Space]
    public float phase3Start = 0.4f;
    public float bossSpeed = 1.0f;
    public bool isPinned = false;
    public bool dead = false;
    public bool started = false;
    public bool starting = true;
    public bool inPhase3 = false;
    private Vector3 dir;
    private Vector3 offsetPos;
    [Space]
    public float waitTime = 0;
    public float direction = 1.0f;
    public bool doingSomething = false;
    [Space]
    public float basicAttackCD;
    public bool basicAttackOnCD = false;
    [Space]
    public float arrowSpeed;
    public float shootArrowsCD;
    public bool arrowsOnCD = false;
    [Space]
    public float pillarCD = 20;
    public float randomX;
    public float randomY;
    public float randomX2;
    public float randomY2;
    public float randomX3;
    public float randomY3;
    public float randomX4;
    public float randomY4;
    public float randomX5;
    public float randomY5;
    [Space]
    public GameObject hitBoxS;
    public GameObject hitBoxN;
    public GameObject hitBoxW;
    public GameObject hitBoxE;
    public GameObject rageIndicator;
    public GameObject stunIndicator;
    public bool touchingPlayer = false;
    //public bool isAggro = false;
    public float chargeCD = 4.0f;
    public float chargeTimeCounter = 0f;
    public bool chargeOnCD = false;
    public float chargingTimer = 0f;
    public float chargeSpeed = 2f;
    public float chargeLength = 2f;
    public bool isCharging = false;
    public GameObject PositionChecker;
    public Vector3 targetPos;


    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        playerTarget = GameObject.FindWithTag("Player");

    }

    private void Update()
    {
        dir = (playerTarget.transform.position - transform.position).normalized;
        offsetPos = playerTarget.transform.position + (dir * 2f);
    }
    // Update is called once per frame
    [System.Obsolete]
    void FixedUpdate()
    {

        if (started)
        {
            if (starting)
            {
                anim.SetBool("moveVert", true);
                anim.SetFloat("speed", -1);
                anim.SetBool("isMoving", true);

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(55.5f, 63f, 0f), 1 * Time.fixedDeltaTime);
                currentHP.GetComponent<Image>().color = new Color(255, 255, 255, (Mathf.Abs(((((transform.position.y - 63f) * 2.5f) / 10f) * 255) - 255)) / 255);
                maxHP.GetComponent<Image>().color = new Color(255, 255, 255, (Mathf.Abs(((((transform.position.y - 63f) * 2.5f) / 10f) * 255) - 255)) / 255);

                if (transform.position.y == 63f)
                {
                    EyeLeft.SetActive(true);
                    EyeRight.SetActive(true);
                    starting = false;
                }
            }
            else
            {
                RaycastHit2D wallCheck = Physics2D.Linecast(transform.position, offsetPos, 1 << 15);
                RaycastHit2D playerCheck = Physics2D.Linecast(transform.position, offsetPos, 1 << 8);

                if (wallCheck.collider != null && playerCheck.collider != null && Vector3.Distance(playerTarget.transform.position, transform.position) < 2)
                {
                    GameObject.FindWithTag("Player").GetComponent<PlayerChar>().PlayerPinned(true);
                    isPinned = true;

                    Debug.DrawLine(transform.position, offsetPos, Color.yellow);
                }
                else
                {
                    GameObject.FindWithTag("Player").GetComponent<PlayerChar>().PlayerPinned(false);
                    isPinned = false;
                    Debug.DrawLine(transform.position, offsetPos, Color.cyan);
                }
                //test
                if (isCharging == false)
                {
                    if (doingSomething == false && isPinned == false)
                    {
                        anim.SetBool("isMoving", true);
                        transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, bossSpeed * Time.fixedDeltaTime);
                    }
                    else
                    {
                        anim.SetBool("isMoving", false);
                    }

                    if (Mathf.Abs(playerTarget.transform.position.y - transform.position.y) > Mathf.Abs(playerTarget.transform.position.x - transform.position.x))
                    {
                        anim.SetFloat("moveX", 0f);
                        anim.SetFloat("moveY", (playerTarget.transform.position.y - transform.position.y));
                        anim.SetBool("moveVert", true);
                        direction = playerTarget.transform.position.y - transform.position.y;

                        if (playerTarget.transform.position.y - transform.position.y > 0)
                        {
                            EyeLeft.SetActive(false);
                            EyeRight.SetActive(false);
                        }
                        else
                        {
                            EyeLeft.SetActive(true);
                            EyeRight.SetActive(true);
                        }
                    }
                    else
                    {
                        anim.SetFloat("moveX", (playerTarget.transform.position.x - transform.position.x));
                        anim.SetFloat("moveY", 0f);
                        anim.SetBool("moveVert", false);
                        direction = playerTarget.transform.position.x - transform.position.x;

                        if (playerTarget.transform.position.x - transform.position.x > 0)
                        {
                            EyeLeft.SetActive(true);
                            EyeRight.SetActive(false);
                        }
                        else
                        {
                            EyeLeft.SetActive(false);
                            EyeRight.SetActive(true);
                        }
                    }

                    if (doingSomething == false && basicAttackOnCD == false && Vector3.Distance(playerTarget.transform.position, transform.position) < 3.5)
                    {
                        basicAttackOnCD = true;
                        doingSomething = true;
                        biteAttack(basicAttackCD);
                    }
                }

                if (pillarCD < 0)
                {
                    SpawnPillar();
                    pillarCD = 20;
                }
                else
                {
                    pillarCD -= Time.fixedDeltaTime;
                }

                if (doingSomething == false && arrowsOnCD == false)
                {
                    shootTheArrows();
                    doingSomething = true;
                    StartCoroutine(shootArrows(shootArrowsCD));
                }

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

                if (isPinned)
                {
                    anim.SetBool("isMoving", false);
                }

                if (healthScript.currentHealth < healthScript.maxHealth * phase3Start)
                {
                    inPhase3 = true;
                }

                if (healthScript.currentHealth < 1)
                {
                    dead = true;
                    anim.SetBool("isMoving", false);
                    Destroy(Arrows);
                    Destroy(Pillars);
                    controller.SoulTwoDead = true;
                }

                
                //Phase 3
                if (inPhase3)
                {
                    if (isCharging == false)
                    {
                        anim.SetBool("charge", false);
                        rageIndicator.SetActive(false);
                    }

                    chargeTimeCounter += Time.fixedDeltaTime;

                    if (chargeOnCD == false)
                    {
                        ChargeAtPlayer();
                        chargeTimeCounter = 0;
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
                }

                anim.SetFloat("speed", direction);

            }
        }
    }

    void shootTheArrows()
    {
        GameObject aD = Instantiate(ArrowDown, new Vector3(42f, 68f, 0f), Quaternion.identity);
        aD.transform.parent = Arrows.transform;
        Rigidbody2D rb = aD.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, -1f) * arrowSpeed;

        GameObject aD2 = Instantiate(ArrowDown, new Vector3(60f, 68f, 0f), Quaternion.identity);
        aD2.transform.parent = Arrows.transform;
        Rigidbody2D rb2 = aD2.GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(0f, -1f) * arrowSpeed;

        GameObject aR = Instantiate(ArrowRight, new Vector3(38f, 63f, 0f), Quaternion.identity);
        aR.transform.parent = Arrows.transform;
        Rigidbody2D rb3 = aR.GetComponent<Rigidbody2D>();
        rb3.velocity = new Vector2(1f, 0f) * arrowSpeed;

        GameObject aL = Instantiate(ArrowLeft, new Vector3(64f, 58f, 0f), Quaternion.identity);
        aL.transform.parent = Arrows.transform;
        Rigidbody2D rb4 = aL.GetComponent<Rigidbody2D>();
        rb4.velocity = new Vector2(-1f, 0f) * arrowSpeed;

        /*shoot arrows from:
         * (42, 68), (60, 68) Down
         * (38, 63) Right, (64, 58)
        */
    }

    void ChargeAtPlayer()
    {
        anim.SetBool("charge", true);
        rageIndicator.SetActive(true);
        isCharging = true;
        PositionChecker.SetActive(true);
        targetPos = FindObjectOfType<TargetPosCheck>().GetComponent<TargetPosCheck>().targetPos;
        anim.SetBool("isMoving", true);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, chargeSpeed * Time.deltaTime);
        chargingTimer += Time.deltaTime;
    }
    void SpawnPillar()
    {
        randomX = Random.Range(40f, 62f);
        randomY = Random.Range(56f, 65f);

        randomX2 = Random.Range(40f, 62f);
        randomY2 = Random.Range(56f, 65f);

        randomX3 = Random.Range(40f, 62f);
        randomY3 = Random.Range(56f, 65f);

        randomX4 = Random.Range(40f, 62f);
        randomY4 = Random.Range(56f, 65f);

        randomX5 = Random.Range(40f, 62f);
        randomY5 = Random.Range(56f, 65f);
        while (randomX == randomX2 && randomY == randomY2)
        {
            randomX2 = Random.Range(40f, 62f);
            randomY2 = Random.Range(56f, 65f);
        }

        while ((randomX3 == randomX2 && randomY3 == randomY2) || (randomX3 == randomX && randomY3 == randomY))
        {
            randomX3 = Random.Range(40f, 62f);
            randomY3 = Random.Range(56f, 65f);
        }

        while ((randomX4 == randomX2 && randomY4 == randomY2) || (randomX4 == randomX && randomY4 == randomY) || (randomX3 == randomX4 && randomY3 == randomY4))
        {
            randomX4 = Random.Range(40f, 62f);
            randomY4 = Random.Range(56f, 65f);
        }

        while ((randomX5 == randomX2 && randomY5 == randomY2) || (randomX5 == randomX && randomY5 == randomY) || (randomX3 == randomX5 && randomY3 == randomY5) || (randomX5 == randomX4 && randomY5 == randomY4))
        {
            randomX5 = Random.Range(40f, 62f);
            randomY5 = Random.Range(56f, 65f);
        }

        StartCoroutine(SpawnPillarTimer());

    }

    IEnumerator SpawnPillarTimer()
    {
        GameObject p1 = Instantiate(Pillar, new Vector3(randomX, randomY, 0f), Quaternion.identity);
        GameObject p2 = Instantiate(Pillar, new Vector3(randomX2, randomY2, 0f), Quaternion.identity);
        GameObject p3 = Instantiate(Pillar, new Vector3(randomX3, randomY3, 0f), Quaternion.identity);
        GameObject p4 = Instantiate(Pillar, new Vector3(randomX4, randomY4, 0f), Quaternion.identity);
        GameObject p5 = Instantiate(Pillar, new Vector3(randomX5, randomY5, 0f), Quaternion.identity);
        p1.transform.parent = Pillars.transform;
        p2.transform.parent = Pillars.transform;
        p3.transform.parent = Pillars.transform;
        p4.transform.parent = Pillars.transform;
        p5.transform.parent = Pillars.transform;
        yield return new WaitForSeconds(9.95f);
        Destroy(p1);
        Destroy(p2);
        Destroy(p3);
        Destroy(p4);
        Destroy(p5);
    }

    void biteAttack(float basicAttackCD)
    {
        if (Mathf.Abs(playerTarget.transform.position.y - transform.position.y) > Mathf.Abs(playerTarget.transform.position.x - transform.position.x))
        {
            if (playerTarget.transform.position.y - transform.position.y > 0)
            {
                StartCoroutine(basicAttackNorth(basicAttackCD));
            }
            else
            {
                StartCoroutine(basicAttackSouth(basicAttackCD));
            }
        }
        else
        {
            if (playerTarget.transform.position.x - transform.position.x > 0)
            {
                StartCoroutine(basicAttackEast(basicAttackCD));
            }
            else
            {
                StartCoroutine(basicAttackWest(basicAttackCD));
            }
        }
    }
    IEnumerator shootArrows(float shootArrowsCD)
    {
        yield return new WaitForSeconds(0.1f);
        arrowsOnCD = true;
        yield return new WaitForSeconds(shootArrowsCD);
        // doingSomething = false;
        arrowsOnCD = false;
    }

    IEnumerator basicAttackNorth(float basicAttackCD)
    {
        basicNorth.SetActive(true);
        yield return new WaitForSeconds(1.05f);
        basicNorth.SetActive(false);
        yield return new WaitForSeconds(basicAttackCD - 1.05f);
        //doingSomething = false;
        basicAttackOnCD = false;

    }

    IEnumerator basicAttackSouth(float basicAttackCD)
    {
        basicSouth.SetActive(true);
        yield return new WaitForSeconds(1.05f);
        basicSouth.SetActive(false);
        yield return new WaitForSeconds(basicAttackCD - 1.05f);
        //doingSomething = false;
        basicAttackOnCD = false;

    }

    IEnumerator basicAttackEast(float basicAttackCD)
    {
        basicEast.SetActive(true);
        yield return new WaitForSeconds(1.05f);
        basicEast.SetActive(false);
        yield return new WaitForSeconds(basicAttackCD - 1.05f);
        //doingSomething = false;
        basicAttackOnCD = false;
    }

    IEnumerator basicAttackWest(float basicAttackCD)
    {
        basicWest.SetActive(true);
        yield return new WaitForSeconds(1.05f);
        basicWest.SetActive(false);
        yield return new WaitForSeconds(basicAttackCD - 1.05f);
        //doingSomething = false;
        basicAttackOnCD = false;

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
