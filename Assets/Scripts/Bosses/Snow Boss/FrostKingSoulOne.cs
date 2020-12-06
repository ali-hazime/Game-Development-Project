using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrostKingSoulOne : MonoBehaviour
{
    private GameObject playerTarget;
    private Animator anim;
    public SoulHealthOne healthScript;
    public GameObject mySoul;
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
    private PlayerChar player;
    [Space]
    public float phase2Start = 0.4f;
    public float bossSpeed = 1.0f;
    public bool isPinned = false;
    public bool dead = false;
    public bool started = false;
    public bool starting = true;
    public bool inPhase2 = false;
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

    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }
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

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(46f, 63f, 0f), 1 * Time.fixedDeltaTime);
                currentHP.GetComponent<Image>().color = new Color(255, 255, 255, (Mathf.Abs(((((transform.position.y - 63f) * 2.5f) / 10f) * 255) - 255))/255);
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
                    player.PlayerPinned(true);
                    isPinned = true;

                    Debug.DrawLine(transform.position, offsetPos, Color.yellow);
                }
                else
                {
                    player.PlayerPinned(false);
                    isPinned = false;
                    Debug.DrawLine(transform.position, offsetPos, Color.cyan);
                }

                if (doingSomething == false && isPinned == false && dead == false)
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

                if (inPhase2 && pillarCD < 0)
                {
                    SpawnPillar();
                    pillarCD = 20;
                }
                else if (inPhase2)
                {
                    pillarCD -= Time.fixedDeltaTime;
                }

                if (doingSomething == false && arrowsOnCD == false && dead == false)
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
                else if (doingSomething == true && waitTime > 0.75 && dead == false)
                {
                    doingSomething = false;
                    anim.SetBool("isMoving", true);
                    waitTime = 0;
                }

                if (isPinned)
                {
                    anim.SetBool("isMoving", false);
                }

                if (healthScript.currentHealth < healthScript.maxHealth * phase2Start)
                {
                    inPhase2 = true;
                    bossSpeed = 2.5f;
                }

                if (healthScript.currentHealth < 1)
                {
                    dead = true;
                    Destroy(Arrows);
                    Destroy(Pillars);
                    GameObject soul = Instantiate(mySoul, this.gameObject.transform.position, Quaternion.identity);
                    anim.SetBool("isMoving", false);
                    controller.SoulOneDead = true;
                    controller.StartSOD();
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

    void SpawnPillar()
    {
        randomX = Random.Range(40f, 62f);
        randomY = Random.Range(56f, 65f);

        randomX2 = Random.Range(40f, 62f);
        randomY2 = Random.Range(56f, 65f);

        randomX3 = Random.Range(40f, 62f);
        randomY3 = Random.Range(56f, 65f);
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

        StartCoroutine(SpawnPillarTimer());

    }

    IEnumerator SpawnPillarTimer()
    {
        GameObject p1 = Instantiate(Pillar, new Vector3(randomX, randomY, 0f), Quaternion.identity);
        GameObject p2 = Instantiate(Pillar, new Vector3(randomX2, randomY2, 0f), Quaternion.identity);
        GameObject p3 = Instantiate(Pillar, new Vector3(randomX3, randomY3, 0f), Quaternion.identity);
        p1.transform.parent = Pillars.transform;
        p2.transform.parent = Pillars.transform;
        p3.transform.parent = Pillars.transform;
        yield return new WaitForSeconds(9.95f);
        Destroy(p1);
        Destroy(p2);
        Destroy(p3);
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
        yield return new WaitForSeconds(basicAttackCD-1.05f);
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
}
