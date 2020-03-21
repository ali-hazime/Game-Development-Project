using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostCloud : MonoBehaviour
{
    public float slowAmount = 2f;
    private PlayerChar player;
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }

    public void OnTriggerStay2D(Collider2D thing)
    {
        if (thing.CompareTag("Player"))
        {
            if (player.isSlowed == false)
            {
                player.isSlowed = true;
                player.SlowPlayer(true, 1f, slowAmount);
            }
        }
        
    }
}
