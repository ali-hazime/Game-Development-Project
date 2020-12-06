using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapphire4Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameSavingInformation.sapphire4Collected = true;
        }
    }
}
