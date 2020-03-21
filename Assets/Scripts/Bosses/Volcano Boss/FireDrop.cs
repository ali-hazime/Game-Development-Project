using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrop : MonoBehaviour
{
    public int damage;
    public float fireTime;
    public int fireDOTdmg;
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
        if (thing.collider.tag == "Player")
        {
            player.TakeDamage(damage);
            player.BurnPlayer(true, fireTime, fireDOTdmg);
        }
    }
}
