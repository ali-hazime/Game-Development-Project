using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staffProjectiles : MonoBehaviour

{
    public GameObject me;
    private int playerDamage;
    // Start is called before the first frame update
    void Start()
    {
        playerDamage = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerChar>().playerDamage;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(me, 5.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealth enemy;
            enemy = other.gameObject.GetComponent<EnemyHealth>();
            enemy.damageEnemy(playerDamage);
            //Destroy(me);

        }
        else if (other.CompareTag("GLBoss"))
        {
            GrassLandsBoss glBoss;
            glBoss = other.gameObject.GetComponent<GrassLandsBoss>();
            glBoss.BossHits();
            //Destroy(me);
        }
        else if (other.tag == "DBoss")
        {
            DesertBossHealth DBoss;
            DBoss = other.gameObject.GetComponent<DesertBossHealth>();

            DBoss.damageEnemy(playerDamage);
        }
        else if (other.tag == "FBoss")
        {
            ForestBossHealth FBoss;
            FBoss = other.gameObject.GetComponent<ForestBossHealth>();

            FBoss.damageEnemy(playerDamage);
        }

        Destroy(me);
    }
         
}

