using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPlant : MonoBehaviour
{
    public int plantDamage;
    public float poisonTime;
    private PlayerChar player;
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }
    void Start()
    {
        StartCoroutine(DespawnPlant());
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            player.TakeDamage(plantDamage);
            player.PoisonPlayer(poisonTime);
            Destroy(this.gameObject);
        }
    }

    IEnumerator DespawnPlant()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
