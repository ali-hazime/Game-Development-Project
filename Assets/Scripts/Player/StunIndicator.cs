using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunIndicator : MonoBehaviour
{
    public float stunLength;
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
        StartCoroutine(StunTimer());
    }
    IEnumerator StunTimer()
    {
        stunLength = (player.stunTime - 0.1f);
        yield return new WaitForSeconds(stunLength);
        Destroy(this.gameObject);
    }
}
