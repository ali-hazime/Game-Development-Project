using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceProjectile : MonoBehaviour
{
    public int projectileDamage;
    public float slowTime;
    public float slowFactor;
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
            player.SlowPlayer(true, slowTime, slowFactor);
            Destroy(this.gameObject);
        }
    }
}
