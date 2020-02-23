using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPlant : MonoBehaviour
{
    public int plantDamage;
    public float poisonTime;

    void Start()
    {
        StartCoroutine(DespawnPlant());
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().TakeDamage(plantDamage);
            other.gameObject.GetComponent<PlayerChar>().PoisonPlayer(poisonTime);
            Destroy(this.gameObject);
        }
    }

    IEnumerator DespawnPlant()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
