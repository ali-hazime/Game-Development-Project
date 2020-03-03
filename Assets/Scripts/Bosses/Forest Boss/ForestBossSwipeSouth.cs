using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBossSwipeSouth : MonoBehaviour
{
    public float swipePoisonTime = 0;

    public int swipeDamage = 0;
    public float swipeForce = -5000f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerChar>().TakeDamage(swipeDamage);
            GameObject.FindWithTag("Player").GetComponent<PlayerChar>().PoisonPlayer(swipePoisonTime);
            if (GameObject.FindWithTag("Player").GetComponent<PlayerChar>()._isPinned == false)
            {
                GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().AddForce(other.transform.up * swipeForce);
            }
        }
    }
}
