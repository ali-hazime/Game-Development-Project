using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int projectileDamage;
    public float poisonTime;
    public float stunTime;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        else if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().TakeDamage(projectileDamage);
            other.gameObject.GetComponent<PlayerChar>().PoisonPlayer(poisonTime);
            other.gameObject.GetComponent<PlayerChar>().StunPlayer(true, stunTime);
            Destroy(this.gameObject);
        }
    }
}
