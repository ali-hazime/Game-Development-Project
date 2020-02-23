using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonAoE : MonoBehaviour
{
    public float poisonDmg = 10.0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerChar>().PoisonPlayer(poisonDmg);
        }
    }
}
