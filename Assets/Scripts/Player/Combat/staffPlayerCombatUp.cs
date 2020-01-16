using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staffPlayerCombatUp : MonoBehaviour
{
    public GameObject staffProjectilePrefab;
    public Transform firePointUp;

    public float projectileForce = 10f;

    void OnEnable()
    {
        shootProjectile();
    }

    void shootProjectile()
    {
        GameObject projectile = Instantiate(staffProjectilePrefab, firePointUp.position, firePointUp.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointUp.up * projectileForce, ForceMode2D.Impulse);
    }
}

