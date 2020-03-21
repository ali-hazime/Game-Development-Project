using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenkarsCrownPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            QuestTracker.allObjCompleted = true;
        }
    }
}