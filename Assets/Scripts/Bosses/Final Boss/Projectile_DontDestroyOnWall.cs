using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_DontDestroyOnWall : MonoBehaviour
{
    public int projectileDamage;
    public float poisonTime;
    public float stunTime;
    public float howLongUntilDestroy;
    private PlayerChar player;
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }

    private void Start()
    {
        StartCoroutine(DestroyMe());
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
        if (other.collider.CompareTag("Player"))
        {
            player.TakeDamage(projectileDamage);

            if (poisonTime > 0)
            {
                player.PoisonPlayer(poisonTime);
            }

            if (stunTime > 0)
            {
                player.StunPlayer(true, stunTime);
            }
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(howLongUntilDestroy);
        Destroy(this.gameObject);
    }
}
