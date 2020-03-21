using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeN : MonoBehaviour
{
    public int chargeDamage = 0;
    public float stunLength = 1f;
    public PlayerChar player;

    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            player.TakeDamage(chargeDamage);
            player.GetComponent<Rigidbody2D>().AddForce(other.transform.up * 5000f);
            player.StunPlayer(true, stunLength);
        }
    }
}
