using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public float[] position;
    public int health;

    public float[] eposition;
    public int ehealth;

    public GameData(PlayerChar player)
    {
        health = player.playerCurrentHealth;

        
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

    public GameData(EnemyHealth eH)
    {
        ehealth = eH.currentHealth;
        /*
        eposition = new float[3];
        eposition[0] = eH.transform.position.x;
        eposition[1] = eH.transform.position.y;
        eposition[2] = eH.transform.position.z;*/
    }
}
