using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBossHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public GameObject healthBar;
    public float scale;
    public DesertBoss theBoss;

    // Start is called before the first frame update
    void Start()
    {
        theBoss = this.gameObject.GetComponent<DesertBoss>();
    }
    //enemy takes damage
    public void DamageEnemy(int playerDamage)
    {
        if (theBoss.started && theBoss.onceFirst == false)
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
