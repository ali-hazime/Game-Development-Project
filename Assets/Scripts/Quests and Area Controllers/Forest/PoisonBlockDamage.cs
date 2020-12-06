using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBlockDamage : MonoBehaviour

{
    [SerializeField] PlayerChar player;
    void Awake()
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
            player.PoisonPlayer(5f);
            player.TakeDamage(5);
        }
    }
}
