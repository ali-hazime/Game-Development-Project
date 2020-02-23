using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_Enemy1_Behaviour : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    public Transform firePoint;
    public GameObject projectile;
    [Space]
    public float aggroMaxRange = 10.5f;
    public float aggroMinRange = 6.5f;
    public float countingTime = 0;
    public float moveSpeed = 1.0f;
    public float direction = 1.0f;
    [Space]
    public bool isAggro = false;
    public bool isAttackAggro = false;
    [Space]
    public float shootCD = 3.5f;
    public float shootTimer = 0;
    public bool shootOnCD = false;
    public bool isColliding = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        anim.SetBool("moveVert", false);
        anim.SetBool("isMoving", true);
    }
    void FixedUpdate()
    {
        shootTimer += Time.fixedDeltaTime;
        if (Vector3.Distance(playerTarget.position, transform.position) <= aggroMaxRange && Vector3.Distance(playerTarget.position, transform.position) >= aggroMinRange)
        {
            isAggro = true;
        }
        else
        {
            isAggro = false;
            anim.SetBool("isMoving", false);
        }
        if (Vector3.Distance(playerTarget.position, transform.position) <= aggroMaxRange)
        {
            isAttackAggro = true;
        }

        else
        {
            isAttackAggro = false;
        }

        if (isAttackAggro)
        {
            if (Mathf.Abs(playerTarget.position.y - transform.position.y) > Mathf.Abs(playerTarget.position.x - transform.position.x))
            {
                anim.SetFloat("moveX", 0f);
                anim.SetFloat("moveY", (playerTarget.position.y - transform.position.y));
                anim.SetBool("moveVert", true);
                direction = playerTarget.position.y - transform.position.y;
            }
            else
            {
                anim.SetFloat("moveX", (playerTarget.position.x - transform.position.x));
                anim.SetFloat("moveY", 0f);
                anim.SetBool("moveVert", false);
                direction = playerTarget.position.x - transform.position.x;
            }
        }

        if (isAggro && isColliding == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, moveSpeed * Time.fixedDeltaTime);
            anim.SetBool("isMoving", true);
            anim.SetFloat("speed", direction);
        }

        if (isAttackAggro && shootOnCD == false)
        {
            ShootProjectile();
            shootOnCD = true;
            shootTimer = 0;
        }

        if (shootTimer > shootCD && shootOnCD == true)
        {
            shootOnCD = false;
        }

        if (isColliding)
        {
            anim.SetBool("isMoving", false);
        }

        //Linecast to check for wall/other enemies between monster and player
        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTarget.position, 1 << 15 | 1 << 9);

        if (hit.collider != null)
        {
            isColliding = true;
            //Debug.Log(hit.collider);
            Debug.DrawLine(transform.position, playerTarget.position, Color.red);
        }
        else
        {
            isColliding = false;
            Debug.DrawLine(transform.position, playerTarget.position, Color.green);
        }
    }
    void ShootProjectile()
    {
        GameObject greenProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = greenProjectile.GetComponent<Rigidbody2D>();
        rb.velocity = (playerTarget.transform.position - transform.position).normalized * 7f;
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