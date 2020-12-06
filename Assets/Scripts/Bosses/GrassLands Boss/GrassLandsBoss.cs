using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassLandsBoss : MonoBehaviour
{
    private GameObject playerTarget;
    public Vector3 myLocation;
    public Vector3 centerPos = new Vector3(0, 3.5f, 0);
    private Animator anim;
    public GameObject me;
    public GrassLandsBossHealth theBossHealth;
    public GameObject rockProjectile;
    public int hitsTaken = 0;
    public float aggroMaxRange;
    public float aggroMinRange;
    public float speed;
    public float countDown;
    public float getBack = 0;
    public float reset = 0;
    public bool dead = false;
    public bool isCentered = false;
    public bool isJumping = false;
    public bool isPunching = false;
    public bool isPinned = false;
    private Vector3 dir;
    private Vector3 offsetPos;
    public KillBoss killBoss;
    public bool phase3 = false;
    public bool phase2 = false;
    public float direction = 1.0f;
    public bool doingSomething = false;
    public float bossSpeed = 1.0f;
    private PlayerChar player;
    public bool started = false;
    public bool rockOnCD;
    public float rockCD;


    //private int maxHealth = 100;
    //public int attackDamage = 25;
    // Start is called before the first frame update
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }

    void Start()
    {
        theBossHealth = GetComponent<GrassLandsBossHealth>();
        anim = GetComponent<Animator>();
        playerTarget = GameObject.FindWithTag("Player");
        //punch.SetActive(false);
    }

    private void Update()
    {
        dir = (playerTarget.transform.position - transform.position).normalized;
        offsetPos = playerTarget.transform.position + (dir * 2f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(started)
        {
            //Increases the counter for boss slam
            countDown += Time.deltaTime;
            reset += Time.deltaTime;

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
            }
            else
            {
                anim.SetFloat("moveX", (playerTarget.transform.position.x - transform.position.x));
                anim.SetFloat("moveY", 0f);
                anim.SetBool("moveVert", false);
                direction = playerTarget.transform.position.x - transform.position.x;
            }

            if (theBossHealth.currentHealth < 1)
            {
                GLBossDeath();
            }
            else if (theBossHealth.currentHealth < theBossHealth.maxHealth * 0.3)
            {
                phase3 = true;
            }
            else if (theBossHealth.currentHealth < theBossHealth.maxHealth * 0.6)
            {
                phase2 = true;
            }

            if (rockOnCD == false)
            {
                rockOnCD = true;
                StartCoroutine(Shoot());
            }

            if (phase2)
            {
                GLBossPhaseTwo();
            }
            if (phase3)
            {
                GLBossPhaseThree();
            }

            anim.SetFloat("speed", direction);
            myLocation = new Vector3(me.transform.position.x, me.transform.position.y);

            if (reset > 5)
            {
                anim.SetBool("isPunching", false);
                isPunching = false;
                anim.SetBool("isJumping", false);
                isJumping = false;
                reset = 0;
            }
        }
    }

    IEnumerator Shoot()
    {
        shootRock();
        yield return new WaitForSeconds(rockCD);
        rockOnCD = false;
    }

    void shootRock()
    {
        GameObject rock = Instantiate(rockProjectile, this.transform.position, this.transform.rotation);
        Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();
        rb.velocity = (playerTarget.transform.position - transform.position).normalized * 5f;
    }

    public void GLBossPhaseTwo()
    {
        if (countDown > 7)
        {
            bossSlam();
        }     
    }

    public void GLBossPhaseThree()
    {
        if (isCentered == false)
        {
            WalkToCenter();
        }
        else 
        {
            anim.SetBool("onPhaseThree", true);
            doingSomething = true;
        }
    }

    public void GLBossDeath()
    {
        gameObject.GetComponent<ItemDropScript>().DropItem(true);
        killBoss.UpdateBossStatus();
        dead = true;
        //Destroy(me);
    }

    public void bossSlam()
    {
        if (Vector3.Distance(playerTarget.transform.position, transform.position) <= 4)
        {
            anim.SetBool("isJumping", true);
            isJumping = true;
            StartCoroutine(Jumping());
            countDown = 0;

        }
        else
        {
            anim.SetBool("isJumping", false);
            isJumping = false;
        }   
    }

    IEnumerator Jumping()
    {
        doingSomething = true;
        yield return new WaitForSeconds(3);
        doingSomething = false;
    }

    public void WalkToCenter()
    {
        getBack += Time.deltaTime;
        transform.position = Vector3.MoveTowards(myLocation, centerPos, 0.03f);
        if(myLocation == centerPos)
        isCentered = true;
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("isMoving", true);
    }

}
