using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootNado : MonoBehaviour
{
    private Transform playerTarget;
    public float velocity = 10f;

    void Start()
    {
        playerTarget = FindObjectOfType<PlayerChar>().transform;
        StartCoroutine(ShootTornado());
    }

    IEnumerator ShootTornado()
    {
        yield return new WaitForSeconds(2.5f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = (playerTarget.transform.position - transform.position).normalized * velocity;
    }
}
