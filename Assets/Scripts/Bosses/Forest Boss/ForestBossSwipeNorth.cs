using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBossSwipeNorth : MonoBehaviour
{
    public float swipePoisonTime = 5;
    public int swipeDamage = 20;
    public float swipeForce = 5000f;
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
            player.TakeDamage(swipeDamage);
            player.PoisonPlayer(swipePoisonTime);
            if (player._isPinned == false)
            {
                player.GetComponent<Rigidbody2D>().AddForce(other.transform.up * swipeForce);
            }
        }
    }
}
