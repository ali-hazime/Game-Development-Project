using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonAoE : MonoBehaviour
{
    public float poisonDmg = 10.0f;
    public PlayerChar player;

    void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.PoisonPlayer(poisonDmg);
        }
    }
}
