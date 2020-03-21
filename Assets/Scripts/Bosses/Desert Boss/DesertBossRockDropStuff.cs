using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBossRockDropStuff : MonoBehaviour
{
    public int damage;
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
        if (thing.collider.CompareTag("Player"))
        {
            player.TakeDamage(damage);
        }
    }
}
