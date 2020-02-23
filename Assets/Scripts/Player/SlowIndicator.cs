using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowIndicator : MonoBehaviour
{
    public float slowLength;
    void Start()
    {
        StartCoroutine(SlowTimer());
    }
    IEnumerator SlowTimer()
    {
        slowLength = (GameObject.FindWithTag("Player").GetComponent<PlayerChar>().slowTime - 0.1f);
        yield return new WaitForSeconds(slowLength);
        Destroy(this.gameObject);
    }
}