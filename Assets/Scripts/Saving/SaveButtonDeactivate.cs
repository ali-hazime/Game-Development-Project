using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButtonDeactivate : MonoBehaviour
{
    public void Update()
    {
        if (GameSavingInformation.whereAmI == "GrasslandsBoss" && GameSavingInformation.grassBossDefeated == false) //Add every boss room
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else if (GameSavingInformation.whereAmI == "GrasslandsBoss" && GameSavingInformation.grassBossDefeated == true)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }

        if (GameSavingInformation.whereAmI == "DesertBoss" && GameSavingInformation.desertBossDefeated == false) //Add every boss room
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else if (GameSavingInformation.whereAmI == "DesertBoss" && GameSavingInformation.desertBossDefeated == true)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }

        if (GameSavingInformation.whereAmI == "The Great Tower Puzzle") //Add every boss room
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
