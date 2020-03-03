using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassLandsBossEncounter : MonoBehaviour
{
    public GameObject player;
    public GameObject normalLadder;
    public GameObject brokenLadder;
    public GrassLandsBoss bossScript;
    public bool GLStart = false;
    public bool GLEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (GLStart == false && GLEnd == false)
        {
            WallCheck();
        } else if (bossScript.hitsTaken == 8)
        {
            EndGLBossFight();
        }
    }

    void WallCheck()
    {
        if (player.transform.position.y > 0)
        {
            GLStart = true;
            StartGLBossFight();
        }
    }

    //Notes - Make boss start sitting at y = 4 location

    void StartGLBossFight()
    {
        MakeBarrier();
    }

    void MakeBarrier()
    {
        normalLadder.SetActive(false);
        brokenLadder.SetActive(true);

        //Add rock falling sounds
    }

    void EndGLBossFight()
    {
        GLEnd = true;
        GLStart = false;
        GameSavingInformation.grassBossDefeated = true;
        BreakBarrier();
    }

   void BreakBarrier()
    {
        normalLadder.SetActive(true);
        brokenLadder.SetActive(false);

        //Add rock breaking sounds
    }
}
