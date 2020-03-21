using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBossBAEast : MonoBehaviour
{
    public float hitForce = 5000f;
    public int hitDamage = 0;
    public float stunTimer = 0;
    private PlayerChar player;
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.TakeDamage(hitDamage);
            player.StunPlayer(true, stunTimer);
            if (player._isPinned == false)
            {
                player.GetComponent<Rigidbody2D>().AddForce(other.transform.right * hitForce);
            }
        }
    }
}
