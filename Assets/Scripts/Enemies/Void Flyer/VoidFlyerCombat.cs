using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidFlyerCombat : MonoBehaviour
{
    private PlayerChar playerChar;
    private float attackCD = 2f;
    public bool isAttacking;
    private int attackDamage;
    // Start is called before the first frame update
    void Start()
    {
        playerChar = FindObjectOfType<PlayerChar>();
        attackDamage = gameObject.GetComponent<VoidFlyer>().attackDamage;
    }

    // Update is called once per frame
    void Update()
    {
        /*attack cooldown for animation purposes and if enemy collides with player
        damage won't be constant*/
        if (isAttacking)
        {
            attackCD -= Time.deltaTime;

            if (attackCD <= 0)
            {
                playerChar.takeDamage(attackDamage);
                attackCD = 2f;
            }
            else
            {
                isAttacking = false;
            }
        }
    }
    //Deals damage to the player
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerChar>().takeDamage(attackDamage);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isAttacking = true;
        }
        
    }   
}
