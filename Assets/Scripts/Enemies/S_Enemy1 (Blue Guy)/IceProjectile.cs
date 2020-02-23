using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceProjectile : MonoBehaviour
{
    public int projectileDamage;
    public float slowTime;
    public float slowFactor;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        else if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().TakeDamage(projectileDamage);
            other.gameObject.GetComponent<PlayerChar>().SlowPlayer(true, slowTime, slowFactor);
            Destroy(this.gameObject);
        }
    }
}
