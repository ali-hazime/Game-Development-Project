using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrostKingSoulOne : MonoBehaviour
{
    private GameObject playerTarget;
    private Animator anim;
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
    [Space]
    public bool isPinned = false;
    public bool dead = false;
    public bool started = false;
    public bool starting = true;
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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
                    GameObject.FindWithTag("Player").GetComponent<PlayerChar>().playerPinned(true);
                    isPinned = true;

                    Debug.DrawLine(transform.position, offsetPos, Color.yellow);
                }
                else
                {
                    GameObject.FindWithTag("Player").GetComponent<PlayerChar>().playerPinned(false);
                    isPinned = false;
                    Debug.DrawLine(transform.position, offsetPos, Color.cyan);
                }

                if (doingSomething == false && isPinned == false)
                {
                    anim.SetBool("isMoving", true);
                    transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, 1 * Time.fixedDeltaTime);
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

                if (doingSomething == false && basicAttackOnCD == false && Vector3.Distance(playerTarget.transform.position, transform.position) < 4)
                {
                    basicAttackOnCD = true;
                    doingSomething = true;
                    biteAttack(basicAttackCD);
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

                anim.SetFloat("speed", direction);
                
            }
        }
    }

    void shootTheArrows()
    {
        GameObject aD = Instantiate(ArrowDown, new Vector3(42f, 68f, 0f), Quaternion.identity);
        Rigidbody2D rb = aD.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, -1f) * arrowSpeed;

        GameObject aD2 = Instantiate(ArrowDown, new Vector3(60f, 68f, 0f), Quaternion.identity);
        Rigidbody2D rb2 = aD2.GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(0f, -1f) * arrowSpeed;

        GameObject aR = Instantiate(ArrowRight, new Vector3(38f, 63f, 0f), Quaternion.identity);
        Rigidbody2D rb3 = aR.GetComponent<Rigidbody2D>();
        rb3.velocity = new Vector2(1f, 0f) * arrowSpeed;

        GameObject aL = Instantiate(ArrowLeft, new Vector3(64f, 58f, 0f), Quaternion.identity);
        Rigidbody2D rb4 = aL.GetComponent<Rigidbody2D>();
        rb4.velocity = new Vector2(-1f, 0f) * arrowSpeed;

        /*shoot arrows from:
         * (42, 68), (60, 68) Down
         * (38, 63) Right, (64, 58)
        */
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
