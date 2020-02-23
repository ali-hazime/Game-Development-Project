using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBoss : MonoBehaviour
{
    public bool dead = false;

    private Transform playerTarget;
    private Animator anim;
    private PlayerChar playerScript;
    public GameObject rockProjectile;
    public GameObject dropRock;
    public GameObject sandStorm;
    public Transform firePoint;
    public DesertBossHealth bossStats;
    public ParticleSystem SSright;
    public ParticleSystem SSleft;

    //public float bossHealth;

    //Animations
    public float dropRockCoolDown = 0;
    public float biteCoolDown = 0;
    public float shootCoolDown = 0;
    public float dropTime = 10;
    public bool shootOnCD = false;
    [Space]
    public int stormInitialDmg = 2;
    public int stormFinalDmg = 4;
    [Space]
    public bool inPhase2 = false;
    public bool inPhase3 = false;
    public float phase2Start = 0.75f;
    public float phase3Start = 0.50f;
    [Space]
    public bool moveVert = false;
    public bool isMoving = true;
    [Space]
    public float sandStormIntense = 0;
    public float endGame = 0;
    public bool STARTTHECLOCK = false;
    public float dot = 0;

    public bool doingSomething = false;
    public bool started = false;

    public bool onceFirst = true;

    public float newPlace;
    [Space]
    //Mechanics
    public bool bite = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerScript = FindObjectOfType<PlayerChar>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        anim.SetBool("moveVert", false);
        anim.SetBool("isMoving", false);
    }

    void Update()
    {
        if (started)
        {
            biteCoolDown += Time.deltaTime;
            shootCoolDown += Time.deltaTime;
            dropRockCoolDown += Time.deltaTime;

            if (STARTTHECLOCK)
            {
                sandStormIntense += Time.deltaTime;
                dot += Time.deltaTime;
                if (dot > 1)
                {
                    if (endGame != 5000)
                    {
                        playerScript.TakeDamage(stormInitialDmg);
                    }
                    else
                    {
                        playerScript.TakeDamage(stormFinalDmg);
                    }
                    dot = 0;
                }

                if (sandStormIntense < 15)
                {
                    endGame = Mathf.Pow(sandStormIntense, 3);
                }
                else
                {
                    endGame = 5000;
                }

            }

            if (onceFirst)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(-18f, 38f, 0f), 1 * Time.deltaTime);
                anim.SetBool("isMoving", true);
                anim.SetBool("moveVert", true);
                anim.SetFloat("speed", -1.0f);
                if (transform.position.y == 38f)
                {
                    anim.SetBool("isMoving", false);
                    onceFirst = false;
                }
            }
            else
            {
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

                if (biteCoolDown > 1.3f && Mathf.Abs(transform.position.y - playerTarget.position.y) + Mathf.Abs(transform.position.x - playerTarget.position.x) < 3)
                {
                    bite = true;
                    anim.SetBool("bite", true);
                    biteCoolDown = 0;
                }
                else
                {
                    if (shootOnCD == false)
                    {
                        shootRock();
                        shootOnCD = true;
                        shootCoolDown = 0;
                    }
                }

                if (inPhase2 && dropRockCoolDown > dropTime)
                {
                    dropTheRock();
                    dropRockCoolDown = 0;
                }

                if (inPhase3)
                {
                    var emissionR = SSleft.emission;
                    var emissionL = SSright.emission;
                    emissionR.rateOverTime = endGame;
                    emissionL.rateOverTime = endGame;
                }

                if (biteCoolDown > 0.98f && bite == true)
                {
                    bite = false;
                    anim.SetBool("bite", false);
                }

                if (shootCoolDown > 2.5f && shootOnCD == true)
                {
                    shootOnCD = false;
                }
                
                if (inPhase2 == false && (float)bossStats.currentHealth / (float)bossStats.maxHealth < phase2Start)
                {
                    inPhase2 = true;
                }
                else if (inPhase3 == false && (float)bossStats.currentHealth / (float)bossStats.maxHealth < phase3Start)
                {
                    dropTime = 5;
                    inPhase3 = true;
                    STARTTHECLOCK = true;
                    sandStorm.SetActive(true);
                }
            }
        }

        if (bossStats.currentHealth <= 0)
        {
            dead = true;
        }
    }

    void shootRock()
    {
        GameObject rock = Instantiate(rockProjectile, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();
        rb.velocity = (playerTarget.transform.position - transform.position).normalized * 5f;
    }

    void dropTheRock()
    {
        GameObject rockFall = Instantiate(dropRock, playerTarget.position, playerTarget.rotation);
    }
}
