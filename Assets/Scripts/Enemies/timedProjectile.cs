using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedProjectile : MonoBehaviour
{
    public int projectileDamage;
    public float poisonTime;
    public float stunTime;
    public float timeBeforeDestroy;
    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeBeforeDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().TakeDamage(projectileDamage);
            other.gameObject.GetComponent<PlayerChar>().PoisonPlayer(poisonTime);
            other.gameObject.GetComponent<PlayerChar>().StunPlayer(true, stunTime);
            Destroy(this.gameObject);
        }
    }
}
