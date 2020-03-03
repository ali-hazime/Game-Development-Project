using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBossEnounter : MonoBehaviour
{
    private GameObject player;
   // public GameObject block;
    //public FrostKingSoulOne bossScriptSoulOne;
   // public FrostKingSoulTwo bossScriptSoulTwo;
    public GameObject theBossSoulOne;
    public GameObject theBossSoulTwo;
    public bool sStart = false;
    public bool sEnd = false;
    public bool sSoulTwoStart = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (sStart == false && sEnd == false)
        {
            if (player.transform.position.y > 62)
            {
                StartSBossFight();
            }
        }
        else if (theBossSoulOne.GetComponent<FrostKingSoulOne>().dead == true && sSoulTwoStart == false)
        {
            EndSBossSoulOne();
            StartSBossTwo();

        } else if (theBossSoulTwo.GetComponent<FrostKingSoulTwo>().dead == true)
        {
            EndSBossFight();
        }
    }

    void StartSBossFight()
    {
        sStart = true;
        //rocks.SetActive(true);
        theBossSoulOne.GetComponent<FrostKingSoulOne>().started = true;
    }

    void StartSBossTwo()
    {
        theBossSoulTwo.GetComponent<FrostKingSoulTwo>().started = true;
        sSoulTwoStart = true;

    }

    void EndSBossSoulOne()
    {
        Destroy(theBossSoulOne);
    }

    void EndSBossFight()
    {
       // rocks.SetActive(false);

        Destroy(theBossSoulTwo);
        GameSavingInformation.snowBossDefeated = true;
    }
}
