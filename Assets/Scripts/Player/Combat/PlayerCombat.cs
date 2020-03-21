using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private int playerDamage;
    public PlayerChar player;

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
    }
}
