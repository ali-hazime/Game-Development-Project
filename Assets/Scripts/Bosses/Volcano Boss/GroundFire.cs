using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFire : MonoBehaviour
{
    //public int damage;
    public float fireTime;
    public int fireDOTdmg;
    private PlayerChar player;
    public bool timer = true;
    public int time;
    // Start is called before the first frame update

    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }

        StartCoroutine(DestroyAfterTime());
    }
    public void OnTriggerStay2D(Collider2D thing)
    {
        if (thing.CompareTag("Player"))
        {
            if (timer == true)
            {
                player.BurnPlayer(true, fireTime, fireDOTdmg);
                StartCoroutine(resetTimer());
            }
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(time - 1);
        Destroy(this.gameObject);

    }

    IEnumerator resetTimer()
    {
        timer = false;
        yield return new WaitForSeconds(0.5f);
        timer = true;
    }
}
