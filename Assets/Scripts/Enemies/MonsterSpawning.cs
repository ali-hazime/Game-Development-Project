using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawning : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesList;
    private GameObject enemy;
    [Space]
    private int enemyToSpawn;
    private int spawnChance;

    private float spawnLocationX;
    private float spawnLocationY;
    private float chance;
    public float maxX;
    public float maxY;

    private void Awake()
    {
        enemyToSpawn = Random.Range(0, enemiesList.Length);
        spawnChance = Random.Range(0, 100);
        chance = Random.Range(0, 100);
        spawnLocationX = Random.Range(0, maxX);
        spawnLocationY = Random.Range(0, maxY);
    }

    private void OnEnable()
    {
       
        if (chance <= 25)
        {
            spawnLocationX = (-spawnLocationX);
        }

        if (chance > 25 && chance <= 50)
        {
            spawnLocationY = (-spawnLocationY);
        }
    }

    private void Start()
    {
        if (spawnChance > 24)
        {
            enemy = Instantiate(enemiesList[enemyToSpawn], new Vector3(transform.position.x + spawnLocationX, transform.position.y + spawnLocationY, 0), transform.rotation);
        }
    }
}
