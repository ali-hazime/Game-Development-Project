using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedProjectile : MonoBehaviour
{
    public int projectileDamage;
    public float poisonTime;
    public float stunTime;
    public float timeBeforeDestroy;
    private float timer = 0;
    private PlayerChar player;
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeBeforeDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
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
