using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby6Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameSavingInformation.ruby6Collected = true;
        }
    }
}
