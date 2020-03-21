using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNadoDamage : MonoBehaviour
{
    public int projectileDamage;
    public float spinLength = 0.5f;
    public float burnLength;
    public int burnDamage;
    private PlayerChar player;
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        else if (other.collider.CompareTag("Player"))
        {
            player.TakeDamage(projectileDamage);
            player.FireSpinPlayer(true, spinLength);
            player.BurnPlayer(true, burnLength, burnDamage);
            Destroy(this.gameObject);
        }
    }
}




