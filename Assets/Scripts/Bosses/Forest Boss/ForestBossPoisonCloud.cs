using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBossPoisonCloud : MonoBehaviour
{

    public void OnTriggerStay2D(Collider2D thing)
    {
        if (thing.CompareTag("Player"))
        {

            GameObject.FindWithTag("Player").GetComponent<PlayerChar>().PoisonPlayer(3.0f);
        }
        else if(thing.CompareTag("FBoss"))
        {
            thing.gameObject.GetComponent<ForestBoss>().makeCloud = false;
        }
    }
}
