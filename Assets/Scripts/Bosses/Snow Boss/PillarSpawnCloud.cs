using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarSpawnCloud : MonoBehaviour
{
    public GameObject slowCloud;
    public float timeBeforeCloudSpawns;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnSlowCloud());
    }

    IEnumerator spawnSlowCloud()
    {
        yield return new WaitForSeconds(timeBeforeCloudSpawns);
        GameObject up = Instantiate(slowCloud, new Vector3(transform.position.x, transform.position.y + 1, 0f), Quaternion.identity);
        GameObject down = Instantiate(slowCloud, new Vector3(transform.position.x, transform.position.y - 1, 0f), Quaternion.identity);
        GameObject right = Instantiate(slowCloud, new Vector3(transform.position.x + 1, transform.position.y, 0f), Quaternion.identity);
        GameObject left = Instantiate(slowCloud, new Vector3(transform.position.x - 1, transform.position.y, 0f), Quaternion.identity);
        up.transform.parent = this.transform;
        down.transform.parent = this.transform;
        right.transform.parent = this.transform;
        left.transform.parent = this.transform;
        yield return new WaitForSeconds(9 - timeBeforeCloudSpawns);
        Destroy(up);
        Destroy(down);
        Destroy(right);
        Destroy(left);
    }
}
