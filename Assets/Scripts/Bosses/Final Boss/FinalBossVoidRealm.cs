using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossVoidRealm : MonoBehaviour
{
    private PlayerChar player;
    private Transform playerTarget;
    private Animator anim;
    public Transform firePoint;
    public FinalBossVoidRealmHealth bossStats;
    public GameObject AbilitiesParent;
    [Space]
    public bool isStarted = false;
    public bool dead = false;
    public bool doingSomething = false;
    [Space]
    public float speed = 0;
    public float phase3Start = 0.6f;
    public bool phase3 = false;
    public float phase4Start = 0.35f;
    public bool phase4 = false;
    [Space]
    //Basic Attacks
    public GameObject ShadowBoltPrefab;
    public bool shadowBoltOnCD = false;
    public float shadowBoltCD;
    [Space]
    public GameObject MinionPrefab;
    public bool spawnMinionsOnCD = false;
    public float spawnMinionsCD = 20;
    [Space]
    public GameObject VoidOrbPrefab;
    public bool voidOrbOnCD = false;
    public float voidOrbCD = 17;
    [Space]
    public GameObject ClonePrefab;
    public bool clonesOnCD = false;
    public float theCD;
    public float clonesCD = 30;
    [Space]
    public GameObject PillarOrbsPrefab;
    public bool pillarOrbIsOn = false;
    [Space]
    public bool isPinned = false;
    private Vector3 dir;
    private Vector3 offsetPos;
    public bool isTouching = false;
    // Start is called before the first frame update

   /* private void Awake()
    {
        Controller = GetComponent<FinalBossEncounterVoidRealm>();
    }*/

    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
        AbilitiesParent = GameObject.FindWithTag("AbilityParent");
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        bossStats = GetComponent<FinalBossVoidRealmHealth>();

        shadowBoltOnCD = false;
        spawnMinionsOnCD = false;
        voidOrbOnCD = false;
    }

    private void Update()
    {
        //Debug.Log("T- " + theCD);
        dir = (playerTarget.position - transform.position).normalized;
        offsetPos = playerTarget.position + (dir * 1.5f);

        if (bossStats.currentHealth < 1)
        {
            dead = true;
        }

        if (isTouching == false)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isStarted)
        {
            if (doingSomething == false && isPinned == false && isTouching == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, 2.5f * Time.deltaTime);
            }

            if (phase3 == false && (float)bossStats.currentHealth / (float)bossStats.maxHealth < phase3Start)
            {
                phase3 = true;
            }

            if (phase4 == false && (float)bossStats.currentHealth / (float)bossStats.maxHealth < phase4Start)
            {
                phase4 = true;
            }

            if (clonesOnCD)
            {
                //clonesCD;
                theCD += Time.fixedDeltaTime;
                if (theCD > clonesCD)
                {
                    clonesOnCD = false;
                    theCD = 0;
                }
            }

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

            if (shadowBoltOnCD == false)
            {
                StartCoroutine(FireShadowBolt());
            }

            if (spawnMinionsOnCD == false)
            {
                StartCoroutine(SpawnMinion());
            }

            if (voidOrbOnCD == false)
            {
                StartCoroutine(FireVoidOrb());
            }

            if ((clonesOnCD == false && phase3) || (clonesOnCD == false && phase4))
            {
                clonesOnCD = true;
                FinalBossEncounterVoidRealm.clonesKilled = 0;
                GameObject Clone1 = Instantiate(ClonePrefab, new Vector3(12, -32, 0), transform.rotation);
                Clone1.transform.parent = AbilitiesParent.transform;
                GameObject Clone2 = Instantiate(ClonePrefab, new Vector3(27, -30, 0), transform.rotation);
                Clone2.transform.parent = AbilitiesParent.transform;
                GameObject Clone3 = Instantiate(ClonePrefab, new Vector3(32, -22, 0), transform.rotation);
                Clone3.transform.parent = AbilitiesParent.transform;
                GameObject Clone4 = Instantiate(ClonePrefab, new Vector3(13, -20, 0), transform.rotation);
                Clone4.transform.parent = AbilitiesParent.transform;
                GameObject Clone5 = Instantiate(ClonePrefab, new Vector3(25.5f, -14.5f, 0), transform.rotation);
                Clone5.transform.parent = AbilitiesParent.transform;
                this.gameObject.SetActive(false);
                //clonesOnCD = false;
            }

            if (pillarOrbIsOn == false && phase4)
            {
                TurnOnOrbs();
                pillarOrbIsOn = true;
            }
        }

        RaycastHit2D wallCheck = Physics2D.Linecast(transform.position, offsetPos, 1 << 15);
        RaycastHit2D playerCheck = Physics2D.Linecast(transform.position, offsetPos, 1 << 8);

        if (wallCheck.collider != null && playerCheck.collider != null && Vector3.Distance(playerTarget.position, transform.position) < 3)
        {
            isPinned = true;
            anim.SetBool("isMoving", false);
            player.PlayerPinned(true);
            Debug.DrawLine(transform.position, offsetPos, Color.yellow);
        }
        else
        {
            isPinned = false;
            player.PlayerPinned(false);
            Debug.DrawLine(transform.position, offsetPos, Color.cyan);
        }

    }

    public void TurnOnOrbs()
    {
        GameObject PillarOrb1 = Instantiate(PillarOrbsPrefab, new Vector3(35.75f, -22, 0), transform.rotation);
        PillarOrb1.transform.parent = AbilitiesParent.transform;
        GameObject PillarOrb2 = Instantiate(PillarOrbsPrefab, new Vector3(30f, -10.5f, 0), transform.rotation);
        PillarOrb2.transform.parent = AbilitiesParent.transform;
        GameObject PillarOrb3 = Instantiate(PillarOrbsPrefab, new Vector3(16.42f, -7.5f, 0), transform.rotation);
        PillarOrb3.transform.parent = AbilitiesParent.transform;
        GameObject PillarOrb4 = Instantiate(PillarOrbsPrefab, new Vector3(7.5f, -16.65f, 0), transform.rotation);
        PillarOrb4.transform.parent = AbilitiesParent.transform;
    }
    /*
    IEnumerator StartClones()
    {
        clonesOnCD = true;
        FinalBossEncounterVoidRealm.clonesKilled = 0;
        GameObject Clone1 = Instantiate(ClonePrefab, new Vector3(9, -32, 0), transform.rotation);
        Clone1.transform.parent = AbilitiesParent.transform;
        GameObject Clone2 = Instantiate(ClonePrefab, new Vector3(27, -30, 0), transform.rotation);
        Clone2.transform.parent = AbilitiesParent.transform;
        GameObject Clone3 = Instantiate(ClonePrefab, new Vector3(32, -22, 0), transform.rotation);
        Clone3.transform.parent = AbilitiesParent.transform;
        GameObject Clone4 = Instantiate(ClonePrefab, new Vector3(13, -20, 0), transform.rotation);
        Clone4.transform.parent = AbilitiesParent.transform;
        GameObject Clone5 = Instantiate(ClonePrefab, new Vector3(25.5f, -14.5f, 0), transform.rotation);
        Clone5.transform.parent = AbilitiesParent.transform;
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(clonesCD);
        clonesOnCD = false;
    } */

    IEnumerator FireVoidOrb()
    {
        voidOrbOnCD = true;
        doingSomething = true;
        GameObject VoidOrb = Instantiate(VoidOrbPrefab, transform.position, transform.rotation);
        VoidOrb.transform.parent = AbilitiesParent.transform;
        Rigidbody2D rb = VoidOrb.GetComponent<Rigidbody2D>();
        rb.velocity = (playerTarget.position - transform.position).normalized * 2.5f;
        yield return new WaitForSeconds(1.5f);
        doingSomething = false;
        yield return new WaitForSeconds(voidOrbCD - 1.5f);
        voidOrbOnCD = false;
    }

    IEnumerator SpawnMinion()
    {
        spawnMinionsOnCD = true;
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        GameObject Minion1 = Instantiate(MinionPrefab, new Vector3(Random.Range(5, 9), Random.Range(-27, -24), 0f), transform.rotation);
        Minion1.transform.parent = AbilitiesParent.transform;
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        GameObject Minion2 = Instantiate(MinionPrefab, new Vector3(Random.Range(28, 33), Random.Range(-29, -25), 0f), transform.rotation);
        Minion2.transform.parent = AbilitiesParent.transform;
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        GameObject Minion3 = Instantiate(MinionPrefab, new Vector3(Random.Range(19, 24), Random.Range(-13, -9), 0f), transform.rotation);
        Minion3.transform.parent = AbilitiesParent.transform;
        yield return new WaitForSeconds(spawnMinionsCD);
        spawnMinionsOnCD = false;
    }

    IEnumerator FireShadowBolt()
    {
        shadowBoltOnCD = true;
        GameObject ShadowBolt = Instantiate(ShadowBoltPrefab, transform.position, transform.rotation);
        ShadowBolt.transform.parent = AbilitiesParent.transform;
        Rigidbody2D rb = ShadowBolt.GetComponent<Rigidbody2D>();
        rb.velocity = (playerTarget.position - transform.position).normalized * 5f;
        yield return new WaitForSeconds(shadowBoltCD);
        shadowBoltOnCD = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isTouching = false;
        }
    }

}

