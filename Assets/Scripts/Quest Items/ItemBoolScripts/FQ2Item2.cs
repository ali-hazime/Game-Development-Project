using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FQ2Item2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            QuestTracker.fQ2_Item2 = false;
        }
    }
}