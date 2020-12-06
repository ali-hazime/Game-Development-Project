using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int projectileDamage;
    public float poisonTime;
    public float stunTime;
    private PlayerChar player;
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        else if (other.collider.CompareTag("Player"))
        {
            player.TakeDamage(projectileDamage);

            if (poisonTime > 0)
            {
                player.PoisonPlayer(poisonTime);  
            }

            if (stunTime > 0)
            { 
                player.StunPlayer(true, stunTime);
            }
            Destroy(this.gameObject);
        }
    }
}
