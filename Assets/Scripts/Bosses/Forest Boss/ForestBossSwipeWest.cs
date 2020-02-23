using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBossSwipeWest : MonoBehaviour
{
    public float swipePoisonTime = 0;
    public int swipeDamage = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().TakeDamage(swipeDamage);
            other.gameObject.GetComponent<PlayerChar>().PoisonPlayer(swipePoisonTime);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(other.transform.right * -5000f);
        }
    }
}
