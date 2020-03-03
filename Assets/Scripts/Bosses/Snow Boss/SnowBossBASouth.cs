using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBossBASouth : MonoBehaviour
{
    public float hitForce = -5000f;
    public int hitDamage = 0;
    public float stunTimer = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerChar>().TakeDamage(hitDamage);
            GameObject.FindWithTag("Player").GetComponent<PlayerChar>().StunPlayer(true, stunTimer);
            if (GameObject.FindWithTag("Player").GetComponent<PlayerChar>()._isPinned == false)
            {
                GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().AddForce(other.transform.up * hitForce);
            }
        }
    }
}
