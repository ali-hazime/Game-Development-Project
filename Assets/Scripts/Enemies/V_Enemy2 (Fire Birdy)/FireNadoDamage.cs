using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNadoDamage : MonoBehaviour
{
    public int projectileDamage;
    public float spinLength = 0.5f;
    public float burnLength;
    public int burnDamage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        else if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().TakeDamage(projectileDamage);
            other.gameObject.GetComponent<PlayerChar>().FireSpinPlayer(true, spinLength);
            other.gameObject.GetComponent<PlayerChar>().BurnPlayer(true, burnLength, burnDamage);
            Destroy(this.gameObject);
        }
    }
}




