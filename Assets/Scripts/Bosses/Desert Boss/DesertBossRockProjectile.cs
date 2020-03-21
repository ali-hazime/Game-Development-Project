using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBossRockProjectile : MonoBehaviour
{
    public int rockDamage;
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
            player.TakeDamage(rockDamage);
            Destroy(this.gameObject);
        }
    }
}
