using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NadoSpin : MonoBehaviour
{
    public float spinLength;
    void Start()
    {
        StartCoroutine(SpinTimer());
    }
    IEnumerator SpinTimer()
    {
        spinLength = (GameObject.FindWithTag("Player").GetComponent<PlayerChar>().spinTime - 0.1f);
        yield return new WaitForSeconds(spinLength);
        Destroy(this.gameObject);
    }
}
