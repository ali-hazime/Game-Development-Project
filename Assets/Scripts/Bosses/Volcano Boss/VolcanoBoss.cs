using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoBoss : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    public Transform firePoint;
    public VolcanoBossHealth bossStats;
    public GameObject FireBallParent;
    [Space]
    public float minRange = 10;
    public float speed = 0;
    public float fireBallCD = 5;
    public float phase2Start = 0.7f;
    public float phase3Start = 0.3f;
    [Space]
    public bool isStarted = false;
    public bool dead = false;
    public bool isNotInMinRange = false;
    public bool doingSomething = false;
    public bool fireballOnCD = false;
    [Space]
    public GameObject FireBallPrefab;
    public GameObject FireBallRightPrefab;
    public GameObject FireBallLeftPrefab;
    public float fireBallSideCD = 15f;
    public bool fireBallSideOnCD = false;
    [Space]
    public GameObject FireBeamPart;
    public bool phase2 = false;
    public float fireBeamCD = 20f;
    public bool fireBeamOnCD = false;
    [Space]
    public GameObject FireDrop;
    public bool phase3 = false;
    public bool fireDropOnCD = false;
    public float fireDropCD = 15f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        bossStats = GetComponent<VolcanoBossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (Mathf.Abs(Vector3.Distance(transform.position, playerTarget.position)) > minRange)
        {
            isNotInMinRange = true;
            anim.SetBool("isMoving", true);
        }
        else
        {
            isNotInMinRange = false;
            anim.SetBool("isMoving", false);
        }

        if (isStarted)
        {
            if (isNotInMinRange && doingSomething == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, 2.5f * Time.deltaTime);
            }

            if (!fireballOnCD)
            {
                StartCoroutine(ShootFireBall());
            }

            if (phase2 == false && (float)bossStats.currentHealth / (float)bossStats.maxHealth < phase2Start)
            {
                phase2 = true;
            }
            else if (phase3 == false && (float)bossStats.currentHealth / (float)bossStats.maxHealth < phase3Start)
            {
                phase3 = true;
            }

            if (fireBallSideOnCD == false)
            {
                StartCoroutine(FireSides());
            }

            if (phase2 && fireBeamOnCD == false)
            {
                StartCoroutine(FireBeam());
            }

            if (phase3 && fireDropOnCD == false)
            {
                StartCoroutine(DropFire());
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
        }
    }

    IEnumerator DropFire()
    {
        fireDropOnCD = true;
        GameObject FireFall = Instantiate(FireDrop, playerTarget.position, playerTarget.rotation);
        yield return new WaitForSeconds(fireDropCD);
        fireDropOnCD = false;
    }

    IEnumerator FireBeam()
    {
        fireBeamOnCD = true;
        int gap = Random.Range(1, 26);
        for (int i = -5; i < 34; i++)
        {
            if (i == gap || i == gap + 1 || i == gap + 2 || i == gap + 3)
            {
            }
            else
            {
                GameObject FireBeam = Instantiate(FireBeamPart, new Vector3(i, 85, 0f), transform.rotation);
                FireBeam.transform.parent = FireBallParent.transform;
                Rigidbody2D FBrb = FireBeam.GetComponent<Rigidbody2D>();
                FBrb.velocity = new Vector3(0, 1, 0) * 4f;
            }
        }
        yield return new WaitForSeconds(fireBeamCD);
        fireBeamOnCD = false;
    }

    IEnumerator FireSides()
    {
        fireBallSideOnCD = true;
        GameObject FireBallSideLeft = Instantiate(FireBallLeftPrefab, new Vector3(45f, Random.Range(93.5f, 115.5f), 0f), Quaternion.Euler(0f, 0f, -90f));
        FireBallSideLeft.transform.parent = FireBallParent.transform;
        Rigidbody2D FBrb = FireBallSideLeft.GetComponent<Rigidbody2D>();
        FBrb.velocity = new Vector3 (-1, 0, 0) * 3f;

        GameObject FireBallSideLeft2 = Instantiate(FireBallLeftPrefab, new Vector3(45f, Random.Range(93.5f, 115.5f), 0f), Quaternion.Euler(0f, 0f, -90f));
        FireBallSideLeft2.transform.parent = FireBallParent.transform;
        Rigidbody2D FBrb2 = FireBallSideLeft2.GetComponent<Rigidbody2D>();
        FBrb2.velocity = new Vector3(-1, 0, 0) * 3f;

        GameObject FireBallSideRight = Instantiate(FireBallRightPrefab, new Vector3(-19f, Random.Range(93.5f, 115.5f), 0f), Quaternion.Euler(0f, 0f, 90f));
        FireBallSideRight.transform.parent = FireBallParent.transform;
        Rigidbody2D FBrb3 = FireBallSideRight.GetComponent<Rigidbody2D>();
        FBrb3.velocity = new Vector3(1, 0, 0) * 3f;

        GameObject FireBallSideRight2 = Instantiate(FireBallRightPrefab, new Vector3(-19f, Random.Range(93.5f, 115.5f), 0f), Quaternion.Euler(0f, 0f, 90f));
        FireBallSideRight2.transform.parent = FireBallParent.transform;
        Rigidbody2D FBrb4 = FireBallSideRight2.GetComponent<Rigidbody2D>();
        FBrb4.velocity = new Vector3(1, 0, 0) * 3f;

        yield return new WaitForSeconds(fireBallSideCD);
        fireBallSideOnCD = false;
    }
    IEnumerator ShootFireBall()
    {
        fireballOnCD = true;
        GameObject FireBall = Instantiate(FireBallPrefab, transform.position, transform.rotation);
        FireBall.transform.parent = FireBallParent.transform;
        Rigidbody2D rb = FireBall.GetComponent<Rigidbody2D>();
        rb.velocity = (playerTarget.position - transform.position).normalized * 5f;
        yield return new WaitForSeconds(fireBallCD);
        fireballOnCD = false;

    }
}
