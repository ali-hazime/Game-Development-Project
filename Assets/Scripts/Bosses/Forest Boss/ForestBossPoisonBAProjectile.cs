using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBossPoisonBAProjectile : MonoBehaviour
{
    public int poisonDamage;
    public float poisonTime;
    private PlayerChar player;
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }


    private void OnCollisionEnter2D(Collision2D thing)
    {
        if (thing.collider.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        else if (thing.collider.CompareTag("Player"))
        {
            player.TakeDamage(poisonDamage);
            player.PoisonPlayer(poisonTime);
            Destroy(this.gameObject);
        }
    }
}
