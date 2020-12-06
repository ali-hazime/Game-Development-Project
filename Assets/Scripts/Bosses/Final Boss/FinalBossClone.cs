using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossClone : MonoBehaviour
{
    private PlayerChar player;
    private Transform playerTarget;
    private Animator anim;
    public CloneHealth bossStats;
    public GameObject AbilitiesParent;
    [Space]
    public bool isStarted = false;
    public bool dead = false;
    public bool doingSomething = false;
    [Space]
    public float speed = 0;
    public float phase3Start = 0.5f;
    public bool phase3 = false;
    [Space]
    //Basic Attacks
    public GameObject ShadowBoltPrefab;
    public bool shadowBoltOnCD = false;
    public float shadowBoltCD;
    [Space]
    public GameObject VoidOrbPrefab;
    public bool voidOrbOnCD = false;
    public float voidOrbCD = 17;
    [Space]
    public bool isPinned = false;
    private Vector3 dir;
    private Vector3 offsetPos;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
        AbilitiesParent = GameObject.FindWithTag("AbilityParent");
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        bossStats = GetComponent<CloneHealth>();
    }

    private void Update()
    {
        dir = (playerTarget.position - transform.position).normalized;
        offsetPos = playerTarget.position + (dir * 1.5f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        

            if (phase3 == false && (float)bossStats.currentHealth / (float)bossStats.maxHealth < phase3Start)
            {
                phase3 = true;
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

            if (voidOrbOnCD == false)
            {
                StartCoroutine(FireVoidOrb());
            }
    }

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
}
