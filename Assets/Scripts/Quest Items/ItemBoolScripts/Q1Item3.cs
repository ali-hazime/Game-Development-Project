using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q1Item3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            QuestTracker.q1_Item3 = false;
        }
    }
}
