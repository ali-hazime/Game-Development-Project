using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoDamage : MonoBehaviour
{
    public int projectileDamage;
    public float spinLength = 0.5f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        else if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().TakeDamage(projectileDamage);
            other.gameObject.GetComponent<PlayerChar>().SpinPlayer(true, spinLength);
            Destroy(this.gameObject);
        }
    }
}
