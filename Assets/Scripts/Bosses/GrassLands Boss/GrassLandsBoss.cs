using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassLandsBoss : MonoBehaviour
{
    private Transform playerTarget;
    public Vector3 myLocation;
    public Vector3 centerPos = new Vector3(0, 3.5f, 0);
    private Animator anim;
    public GameObject me;
    public int hitsTaken = 0;
    public float aggroMaxRange;
    public float aggroMinRange;
    public float speed;
    public float countDown;
    public float getBack = 0;
    public float reset = 0;
    public bool isCentered = false;
    public bool isJumping = false;
    public bool isPunching = false;

    

    //private int maxHealth = 100;
    //public int attackDamage = 25;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        //punch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Increases the counter for boss slam
        countDown += Time.deltaTime;
        reset += Time.deltaTime;

        Debug.Log("Hits = " + hitsTaken);
        //This vector 3 is essentially aggro range
        if (Vector3.Distance(playerTarget.position, transform.position) <= aggroMaxRange && Vector3.Distance(playerTarget.position, transform.position) >= aggroMinRange)
        {
            FollowPlayer();
            aggroMaxRange = 10;
        }
        else
        {
            anim.SetBool("isAggro", false);
            aggroMaxRange = 4;
        }

        //Determine Phase
        if (hitsTaken < 3)
        {
            GLBossPhaseOne();
        }
        else if (hitsTaken < 6)
        {
            GLBossPhaseTwo();
        }
        else if (hitsTaken < 8)
        {
            GLBossPhaseThree();
        }
        else
        {
            GLBossDeath();
        }

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

    public void FollowPlayer()
    {
        //transform to follow player
        if (isPunching == false && isJumping == false && isCentered == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);
        }
        anim.SetBool("isAggro", true);
        //allows the enemy to turn and face player
        anim.SetFloat("moveX", (playerTarget.position.x - transform.position.x));
        anim.SetFloat("moveY", (playerTarget.position.y - transform.position.y));

        //punching

    }

    //Boss health
    public void BossHits()
    {
        hitsTaken++;
    }

    public void GLBossPhaseOne()
    {
        bossPunch();
    }

    public void GLBossPhaseTwo()
    {
        if (countDown > 7)
        {
            bossSlam();
        }
        else 
        {
            bossPunch();
        }      
    }

    public void GLBossPhaseThree()
    {
        if (isCentered == false)
        {
            anim.SetBool("onPhaseThree", true);
            WalkToCenter();
        }
        else 
        {
            bossSlam();
        }
    }

    public void GLBossDeath()
    {
        Destroy(me);
    }

    public void bossPunch()
    {
        if (((playerTarget.position.y - transform.position.y) < 0 && Mathf.Abs(playerTarget.position.y - transform.position.y) > Mathf.Abs(playerTarget.position.x - transform.position.x)) && Vector3.Distance(playerTarget.position, transform.position) <= 2.5)
        {
            //Punching Down
            anim.SetBool("isPunching", true);
            anim.SetBool("isPunchingDown", true);
            anim.SetBool("isPunchingUp", false);
            anim.SetBool("isPunchingRight", false);
            anim.SetBool("isPunchingLeft", false);
            isPunching = true;

        }
        else if (((playerTarget.position.y - transform.position.y) > 0 && Mathf.Abs(playerTarget.position.y - transform.position.y) > Mathf.Abs(playerTarget.position.x - transform.position.x)) && Vector3.Distance(playerTarget.position, transform.position) <= 2.5)
        {
            //Punching Up
            anim.SetBool("isPunching", true);
            anim.SetBool("isPunchingUp", true);
            anim.SetBool("isPunchingDown", false);
            anim.SetBool("isPunchingRight", false);
            anim.SetBool("isPunchingLeft", false);
            isPunching = true;
        }
        else if (((playerTarget.position.x - transform.position.x) > 0 && Mathf.Abs(playerTarget.position.y - transform.position.y) < Mathf.Abs(playerTarget.position.x - transform.position.x)) && Vector3.Distance(playerTarget.position, transform.position) <= 2.5)
        {
            //Punching Right
            anim.SetBool("isPunching", true);
            anim.SetBool("isPunchingRight", true);
            anim.SetBool("isPunchingDown", false);
            anim.SetBool("isPunchingUp", false);
            anim.SetBool("isPunchingLeft", false);
            isPunching = true;
        }
        else if (((playerTarget.position.x - transform.position.x) < 0 && Mathf.Abs(playerTarget.position.y - transform.position.y) < Mathf.Abs(playerTarget.position.x - transform.position.x)) && Vector3.Distance(playerTarget.position, transform.position) <= 2.5)
        {
            //Punching Left
            anim.SetBool("isPunching", true);
            anim.SetBool("isPunchingLeft", true);
            anim.SetBool("isPunchingDown", false);
            anim.SetBool("isPunchingUp", false);
            anim.SetBool("isPunchingRight", false);
            isPunching = true;
        }
        else
        {
            anim.SetBool("isPunching", false);
            anim.SetBool("isPunchingDown", false);
            anim.SetBool("isPunchingUp", false);
            anim.SetBool("isPunchingRight", false);
            anim.SetBool("isPunchingLeft", false);
            isPunching = false;
        }
    }

    public void bossSlam()
    {
        if (Vector3.Distance(playerTarget.position, transform.position) <= 4)
        {
            anim.SetBool("isJumping", true);
            isJumping = true;
            countDown = 0;

        }
        else
        {
            anim.SetBool("isJumping", false);
            isJumping = false;
        }   
    }

    public void WalkToCenter()
    {
        getBack += Time.deltaTime;
        transform.position = Vector3.MoveTowards(myLocation, centerPos, 0.03f);
        if(myLocation == centerPos)
            isCentered = true;
        
    }
}
