using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBossPoisonBAProjectile : MonoBehaviour
{
    public int poisonDamage;
    public float poisonTime;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D thing)
    {
        if (thing.collider.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        else if (thing.collider.tag == "Player")
        {
            thing.gameObject.GetComponent<PlayerChar>().TakeDamage(poisonDamage);
            thing.gameObject.GetComponent<PlayerChar>().PoisonPlayer(poisonTime);
            Destroy(this.gameObject);
        }
    }
}
