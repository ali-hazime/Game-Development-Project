using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBossEncounter : MonoBehaviour
{

    private GameObject player;
    public GameObject treeBeforeBlock;
    public GameObject treeBlock;
    public GameObject cloudParent;
    public GameObject boltsParent;
    public ForestBoss bossScript;
    public GameObject theBoss;

    public bool fStart = false;
    public bool fEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (fStart == false && fEnd == false)
        {
            if (player.transform.position.y > 18)
            {
                startFBossFight();
            }
        }
        else if (bossScript.dead == true)
        {
            EndFBossFight();
        }
    }

    void startFBossFight()
    {
        fStart = true;
        treeBlock.SetActive(true);
        treeBeforeBlock.SetActive(false);
        bossScript.started = true;
    }

    void EndFBossFight()
    {
        Destroy(cloudParent);
        Destroy(boltsParent);
        treeBlock.SetActive(false);
        GameSavingInformation.forestBossDefeated = true;
        Destroy(theBoss);
    }
}

