using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnIndicator : MonoBehaviour
{
    public float burnLength;
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
        StartCoroutine(BurnTimer());
    }
    IEnumerator BurnTimer()
    {
        burnLength = (player.burnTime - 0.1f);
        yield return new WaitForSeconds(burnLength);
    }
}