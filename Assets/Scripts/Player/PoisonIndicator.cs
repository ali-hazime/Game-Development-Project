using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonIndicator : MonoBehaviour
{
    public float poisonLength;
    void Start()
    {
        StartCoroutine(PoisonTimer());
    }
    IEnumerator PoisonTimer()
    {
        poisonLength = (GameObject.FindWithTag("Player").GetComponent<PlayerChar>().poisonTimer);
        yield return new WaitForSeconds(poisonLength);
        Destroy(this.gameObject);
    }
}
