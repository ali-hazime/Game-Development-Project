using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBossHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public GameObject healthBar;
    public float scale;
    public ForestBoss theBoss;

    private void Start()
    {
        theBoss = this.gameObject.GetComponent<ForestBoss>();
    }
    //enemy takes damage
    public void DamageEnemy(int playerDamage)
    {
        if(theBoss.started)
        {
            currentHealth -= playerDamage;
        }

        if (currentHealth <= 0)
        {
            //Destroy(gameObject);
            gameObject.GetComponent<ItemDropScript>().DropItem(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        scale = (float)currentHealth / (float)maxHealth;
        healthBar.transform.localScale = new Vector3(scale, 1, 1);
    }
}
