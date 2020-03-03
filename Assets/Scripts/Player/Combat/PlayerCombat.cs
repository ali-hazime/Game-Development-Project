using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private int playerDamage;

    // Start is called before the first frame update
    void Start()
    {
        playerDamage = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerChar>().playerDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy;
            enemy = other.gameObject.GetComponent<EnemyHealth>();
            enemy.damageEnemy(25);
            
        }
        else if (other.CompareTag("GLBoss"))
        {
            GrassLandsBoss glBoss;
            glBoss = other.gameObject.GetComponent<GrassLandsBoss>();

            glBoss.BossHits();
        }
        else if (other.tag == "DBoss")
        {
            DesertBossHealth DBoss;
            DBoss = other.gameObject.GetComponent<DesertBossHealth>();

            DBoss.DamageEnemy(playerDamage);
        }
        else if (other.tag == "FBoss")
        {
            ForestBossHealth FBoss;
            FBoss = other.gameObject.GetComponent<ForestBossHealth>();

            FBoss.DamageEnemy(playerDamage);
        }
    }
}
