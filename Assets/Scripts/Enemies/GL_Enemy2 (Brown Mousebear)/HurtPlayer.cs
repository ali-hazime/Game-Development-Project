using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public int damage = 2;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().TakeDamage(damage);
            playerRB = other.gameObject.GetComponent<Rigidbody2D>();
            playerRB.AddForce(other.transform.right * 3000f);
        }
    }
}
