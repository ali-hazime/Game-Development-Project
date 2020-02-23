using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Enemy1_Behaviour : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    public GameObject thorns;
    public Transform firePoint;
    [Space]
    public float aggroMaxRange = 10;
    public float aggroMinRange = 4;
    public float countingTime = 0;
    public float direction = 1.0f;
    public float moveSpeed = 2f;
    public float thornsCD = 3f;
    public float thornsVelocity = 5f;
    public float poisonTime = 5f;
    [Space]
    public bool isAggro;
    public bool isAttackAggro;
    public bool shootOnCD = false;
    public bool isColliding = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        anim.SetBool("moveVert", false);
    }

    void FixedUpdate()
    {
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

        if (isAggro)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, moveSpeed * Time.fixedDeltaTime);
            anim.SetBool("isMoving", true);
            anim.SetFloat("speed", direction);
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

            if (shootOnCD == false)
            {
                StartCoroutine(ShootProjectile());
            }
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

    IEnumerator ShootProjectile()
    {
        GameObject thornsProjectile = Instantiate(thorns, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = thornsProjectile.GetComponent<Rigidbody2D>();
        rb.velocity = (playerTarget.transform.position - transform.position).normalized * thornsVelocity;
        shootOnCD = true;
        yield return new WaitForSeconds(thornsCD);
        shootOnCD = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            anim.SetBool("isMoving", false);
            other.gameObject.GetComponent<PlayerChar>().PoisonPlayer(poisonTime);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("isMoving", true);
    }
}
