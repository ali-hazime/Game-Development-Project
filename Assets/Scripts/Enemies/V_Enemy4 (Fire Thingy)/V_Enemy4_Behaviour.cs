using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_Enemy4_Behaviour : MonoBehaviour
{
    private Transform playerTarget;
    private Animator anim;
    [Space]
    public GameObject explosion;
    public int burnDamage;
    public float burnLength;
    public int damage = 50;
    public float aggroMaxRange = 7;
    public float aggroMinRange = 0;
    public float countingTime = 0;
    public float speed = 1.0f;
    public float direction = 1.0f;
    public bool moveVert = false;
    public bool isMoving = true;
    public bool touchingPlayer = false;
    public bool isAggroed = false;
    [Space]
    public bool isColliding = false;


    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        anim.SetBool("moveVert", false);
        anim.SetBool("isMoving", true);
    }

    private void FixedUpdate()
    {

        //Linecast to check for wall/other enemies between monster and player
        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTarget.position, 1 << 15 | 1 << 9);

        if (hit.collider != null)
        {
            isColliding = true;
            //Debug.DrawLine(transform.position, playerTarget.position, Color.red);
        }
        else
        {
            isColliding = false;
            //Debug.DrawLine(transform.position, playerTarget.position, Color.green);
        }

        if (Vector3.Distance(playerTarget.position, transform.position) <= aggroMaxRange)
        {
            isAggroed = true;
        }
        else
        {
            isAggroed = false;
        }

        if (isAggroed == false)
        {


        }
        else if (isColliding == false)
        {
            anim.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, speed * Time.fixedDeltaTime);
        }

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

        anim.SetFloat("speed", direction);
        if (isColliding)
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().TakeDamage(damage);
            other.gameObject.GetComponent<PlayerChar>().BurnPlayer(true, burnLength, burnDamage);
            GameObject deathAnimation = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

}
