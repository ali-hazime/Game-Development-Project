using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby4Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameSavingInformation.ruby4Collected = true;
        }
    }
}
