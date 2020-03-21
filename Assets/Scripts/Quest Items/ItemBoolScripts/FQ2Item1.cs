using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FQ2Item1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            QuestTracker.fQ2_Item1 = false;
        }
    }
}
