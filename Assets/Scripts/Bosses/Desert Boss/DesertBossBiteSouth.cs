using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBossBiteSouth : MonoBehaviour
{

    public int biteDamage = 0;
    public float biteForce = -10000f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerChar>().TakeDamage(biteDamage);
            if (GameObject.FindWithTag("Player").GetComponent<PlayerChar>()._isPinned == false)
            {
                GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().AddForce(other.transform.up * biteForce);
            }
        }
    }
}
