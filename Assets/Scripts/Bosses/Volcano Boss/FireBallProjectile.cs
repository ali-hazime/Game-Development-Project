using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : MonoBehaviour
{
    public int damage;
    public float fireTime;
    public int fireDOTdmg;
    private PlayerChar player;
    // Start is called before the first frame update

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
            player.BurnPlayer(true, fireTime, fireDOTdmg);
            Destroy(this.gameObject);
        }
    }
}
