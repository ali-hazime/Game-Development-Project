using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunIndicator : MonoBehaviour
{
    public float stunLength;
    void Start()
    {
        StartCoroutine(StunTimer());
    }
    IEnumerator StunTimer()
    {
        stunLength = (GameObject.FindWithTag("Player").GetComponent<PlayerChar>().stunTime - 0.1f);
        yield return new WaitForSeconds(stunLength);
        Destroy(this.gameObject);
    }
}
