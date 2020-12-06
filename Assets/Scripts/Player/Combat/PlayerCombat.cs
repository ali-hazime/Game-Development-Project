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
            
            GrassLandsBossHealth glBoss;
            glBoss = other.gameObject.GetComponent<GrassLandsBossHealth>();
            glBoss.DamageEnemy(playerDamage);

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
        else if (other.CompareTag("FinalBoss"))
        {
            FinalBossHealth enemy;
            enemy = other.gameObject.GetComponent<FinalBossHealth>();
            enemy.DamageEnemy(playerDamage);
        }
        else if (other.CompareTag("FinalBossVoidRealm"))
        {
            FinalBossVoidRealmHealth enemy;
            enemy = other.gameObject.GetComponent<FinalBossVoidRealmHealth>();
            enemy.DamageEnemy(playerDamage);
        }
        else if (other.CompareTag("FinalBossMinion"))
        {
            MinionHealth enemy;
            enemy = other.gameObject.GetComponent<MinionHealth>();
            enemy.DamageEnemy(playerDamage);
        }
        else if (other.CompareTag("FinalBossClone"))
        {
            CloneHealth enemy;
            enemy = other.gameObject.GetComponent<CloneHealth>();
            enemy.DamageEnemy(playerDamage);
        }
    }
}
