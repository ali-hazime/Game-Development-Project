using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRockTimeout : MonoBehaviour
{
    public float poof = 0;
    void Update()
    {
        poof += Time.deltaTime;

        if (poof > 1.55)
        {
            Destroy(this.gameObject);
        }
    }
}
