using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBossPoisonCloud : MonoBehaviour
{
    private PlayerChar player;
    private ForestBoss fBoss;
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }

        if (fBoss == null)
        {
            fBoss = FindObjectOfType<ForestBoss>();
        }
    }


    public void OnTriggerStay2D(Collider2D thing)
    {
        if (thing.CompareTag("Player"))
        {
            player.PoisonPlayer(3.0f);
        }
        else if(thing.CompareTag("FBoss"))
        {
           fBoss.makeCloud = false;
        }
    }
}
