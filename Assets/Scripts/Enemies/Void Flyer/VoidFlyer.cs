using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidFlyer : MonoBehaviour
{
    
    private Transform playerTarget;
    private Animator anim;
    public float aggroMaxRange;
    public float aggroMinRange;
    public float speed;
    //private int maxHealth = 100;
    public int attackDamage = 25;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerTarget = FindObjectOfType<PlayerChar>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //This vector 3 is essentially aggro range
        if (Vector3.Distance(playerTarget.position, transform.position) <= aggroMaxRange && Vector3.Distance(playerTarget.position, transform.position) >= aggroMinRange)
        {
            FollowPlayer();
        }
        
    }

    public void FollowPlayer()
    {
        //transform to follow player
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);
        anim.SetBool("isAggro", true);
        //allows the enemy to turn and face player
        anim.SetFloat("moveX",(playerTarget.position.x - transform.position.x));
        anim.SetFloat("moveY", (playerTarget.position.y - transform.position.y));
    }

}
