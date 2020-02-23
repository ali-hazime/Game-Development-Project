using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeE : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public int chargeDamage = 0;
    public float stunLength = 1f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().TakeDamage(chargeDamage);
            playerRB = other.gameObject.GetComponent<Rigidbody2D>();
            playerRB.AddForce(other.transform.right * 5000f);
            other.gameObject.GetComponent<PlayerChar>().StunPlayer(true, stunLength);
        }
    }
}
