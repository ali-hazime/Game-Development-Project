using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staffProjectiles : MonoBehaviour

{
    public GameObject me;
    private int playerDamage;
    public PlayerChar player;
    // Start is called before the first frame update
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }

    void OnEnable()
    {
        playerDamage = player.playerDamage;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(me, 5.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy;
            enemy = other.gameObject.GetComponent<EnemyHealth>();
            enemy.damageEnemy(playerDamage);

        }
        else if (other.CompareTag("GLBoss"))
        {

            GrassLandsBoss glBoss;
            glBoss = other.gameObject.GetComponent<GrassLandsBoss>();
            glBoss.BossHits();

        }
        else if (other.CompareTag("DBoss"))
        {
            DesertBossHealth DBoss;
            DBoss = other.gameObject.GetComponent<DesertBossHealth>();

            DBoss.DamageEnemy(playerDamage);
        }
        else if (other.CompareTag("FBoss"))
        {
            ForestBossHealth FBoss;
            FBoss = other.gameObject.GetComponent<ForestBossHealth>();

            FBoss.DamageEnemy(playerDamage);
        }
        else if (other.CompareTag("S1Boss"))
        {
            SoulHealthOne enemy;
            enemy = other.gameObject.GetComponent<SoulHealthOne>();
            enemy.DamageEnemy(playerDamage);
        }
        else if (other.CompareTag("S2Boss"))
        {
            SoulHealthTwo enemy;
            enemy = other.gameObject.GetComponent<SoulHealthTwo>();
            enemy.DamageEnemy(playerDamage);
        }
        else if (other.CompareTag("VBoss"))
        {
            VolcanoBossHealth enemy;
            enemy = other.gameObject.GetComponent<VolcanoBossHealth>();
            enemy.DamageEnemy(playerDamage);
        }

        Destroy(me);
    }
         
}

