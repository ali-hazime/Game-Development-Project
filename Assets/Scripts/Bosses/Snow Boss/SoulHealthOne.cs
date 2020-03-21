using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulHealthOne : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public GameObject healthBar;
    public float scale;
    public FrostKingSoulOne theBossOne;

    // Start is called before the first frame update
    void Start()
    {
        theBossOne = this.gameObject.GetComponent<FrostKingSoulOne>();

    }
    //enemy takes damage
    public void DamageEnemy(int playerDamage)
    {
        
        if (theBossOne.started && theBossOne.starting == false)
        {
            currentHealth -= playerDamage;
        }

        if (currentHealth <= 0)
        {
            //Destroy(gameObject);
            //QuestTracker.killCount++;
            //gameObject.GetComponent<ItemDropScript>().DropItem(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        scale = (float)currentHealth / (float)maxHealth;
        healthBar.transform.localScale = new Vector3(scale, 1, 1);
    }
}
