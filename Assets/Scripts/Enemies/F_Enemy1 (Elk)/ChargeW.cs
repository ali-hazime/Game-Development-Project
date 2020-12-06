using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeW : MonoBehaviour
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
            player.GetComponent<Rigidbody2D>().AddForce(other.transform.right * -2500f);
            player.StunPlayer(true, stunLength);
        }
    }
}
