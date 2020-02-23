using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnIndicator : MonoBehaviour
{
    public float burnLength;
    void Start()
    {
        StartCoroutine(BurnTimer());
    }
    IEnumerator BurnTimer()
    {
        burnLength = (GameObject.FindWithTag("Player").GetComponent<PlayerChar>().burnTime - 0.1f);
        yield return new WaitForSeconds(burnLength);
    }
}