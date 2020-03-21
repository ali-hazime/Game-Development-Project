using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowIndicator : MonoBehaviour
{
    public float slowLength;
    public PlayerChar player;
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }
    void Start()
    {
        StartCoroutine(SlowTimer());
    }
    IEnumerator SlowTimer()
    {
        slowLength = (player.slowTime - 0.1f);
        yield return new WaitForSeconds(slowLength);
        Destroy(this.gameObject);
    }
}