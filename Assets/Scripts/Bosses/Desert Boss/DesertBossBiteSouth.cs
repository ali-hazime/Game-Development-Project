using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBossBiteSouth : MonoBehaviour
{

    public int biteDamage = 0;
    public float biteForce = -10000f;
    public PlayerChar player;

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
            player.TakeDamage(biteDamage);
            if (player._isPinned == false)
            {
                player.GetComponent<Rigidbody2D>().AddForce(other.transform.up * biteForce);
            }
        }
    }
}
