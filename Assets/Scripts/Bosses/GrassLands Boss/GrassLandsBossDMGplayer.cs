using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassLandsBossDMGplayer : MonoBehaviour
{
    public GameObject player;

    public int damage = 0;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().TakeDamage(damage);
            
        }
    }
}
