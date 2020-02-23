using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBossRockDropStuff : MonoBehaviour
{
    public int damage;
    
    private void OnCollisionEnter2D(Collision2D thing)
    {
        if (thing.collider.tag == "Player")
        {
            thing.gameObject.GetComponent<PlayerChar>().TakeDamage(damage);
        }
    }
}
