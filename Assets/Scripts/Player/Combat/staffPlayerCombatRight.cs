using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staffPlayerCombatRight : MonoBehaviour
{
    public GameObject staffProjectilePrefab;
    public Transform firePointRight;

    public float projectileForce = 10f;

    void OnEnable()
    {
        shootProjectile();
    }

    void shootProjectile()
    {
        GameObject projectile = Instantiate(staffProjectilePrefab, firePointRight.position, firePointRight.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointRight.right * projectileForce, ForceMode2D.Impulse);
    }
}

