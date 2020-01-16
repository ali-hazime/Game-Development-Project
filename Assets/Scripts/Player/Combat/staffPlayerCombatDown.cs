using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staffPlayerCombatDown : MonoBehaviour
{
    public GameObject staffProjectilePrefab;
    public Transform firePointDown;

    public float projectileForce = 10f;

    void OnEnable()
    {
        shootProjectile();
    }

    void Update()
    {

    }

   
   void shootProjectile()
    {
         GameObject projectile = Instantiate(staffProjectilePrefab, firePointDown.position, firePointDown.rotation);
         Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
         rb.AddForce(-firePointDown.up * projectileForce, ForceMode2D.Impulse);
    }
}
