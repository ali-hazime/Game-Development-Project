using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staffPlayerCombatLeft : MonoBehaviour
{
    public GameObject staffProjectilePrefab;
    public Transform firePointLeft;

    public float projectileForce = 10f;

    void OnEnable()
    {
        shootProjectile();
    }

    void shootProjectile()
    {
        GameObject projectile = Instantiate(staffProjectilePrefab, firePointLeft.position, firePointLeft.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(-firePointLeft.right * projectileForce, ForceMode2D.Impulse);
    }
}
