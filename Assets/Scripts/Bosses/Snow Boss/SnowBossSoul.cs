using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBossSoul : MonoBehaviour
{
    public bool go = false;
    public SnowBossEnounter snowBossCont;
    // Start is called before the first frame update
    void Start()
    {
        if (snowBossCont == null)
        {
            snowBossCont = FindObjectOfType<SnowBossEnounter>();
        }
        StartCoroutine(SoulMovement());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (go == true) 
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(55.5f, 67.5f, 0), 1.5f * Time.fixedDeltaTime);
        }

        if (transform.position == new Vector3(55.5f, 67.5f, 0))
        {
            StartCoroutine(SoulDie());
        }
    }

    IEnumerator SoulMovement()
    {
        yield return new WaitForSeconds(2f);
        go = true;
    }

    IEnumerator SoulDie()
    {
        yield return new WaitForSeconds(2f);
        snowBossCont.soulGone = true;
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}
