using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossVoidRealmHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public GameObject healthBar;
    public float scale;
    public FinalBossVoidRealm theBoss;

    private void Start()
    {
        theBoss = this.gameObject.GetComponent<FinalBossVoidRealm>();
    }
    //enemy takes damage
    public void DamageEnemy(int playerDamage)
    {
        if (theBoss.isStarted)
        {
            currentHealth -= playerDamage;
        }
    }


    // Update is called once per frame
    void Update()
    {
        scale = (float)currentHealth / (float)maxHealth;
        healthBar.transform.localScale = new Vector3(scale, 1, 1);
    }
}
