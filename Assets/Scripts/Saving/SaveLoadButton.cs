using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadButton : MonoBehaviour
{
    private PlayerChar player;
    private EnemyHealth eh;

    public void Start()
    {
        player = FindObjectOfType<PlayerChar>();
        eh = FindObjectOfType<EnemyHealth>();
       // ehO = FindObjectOfType<>
    }
    public void Save()
    {
        SaveSystem.SavePlayer(player);
        SaveSystem.SaveEnemy(eh);
    }

    public void Load()
    {
        GameData data = SaveSystem.LoadPlayer();

        player.playerCurrentHealth = data.health;
        
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;

        GameData Edata = SaveSystem.LoadEnemy();

        eh.currentHealth = Edata.ehealth;
        /*
        Vector3 eposition;
        eposition.x = Edata.position[0];
        eposition.y = Edata.position[1];
        eposition.z = Edata.position[2];
        eh.transform.position = eposition;
        */
    }
}
