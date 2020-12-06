using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidOrb : MonoBehaviour
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

            //Warp Player
            player.transform.position = new Vector3(Random.Range(10, 30), Random.Range(-32.5f, -17.5f), 0f);

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
