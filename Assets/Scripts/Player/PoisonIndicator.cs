using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonIndicator : MonoBehaviour
{
    public float poisonLength;
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
        StartCoroutine(PoisonTimer());
    }
    IEnumerator PoisonTimer()
    {
        poisonLength = (player.poisonTimer);
        yield return new WaitForSeconds(poisonLength);
        Destroy(this.gameObject);
    }
}
