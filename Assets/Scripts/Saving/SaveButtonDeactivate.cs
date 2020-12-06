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

        if (GameSavingInformation.whereAmI == "ForestBoss" && GameSavingInformation.forestBossDefeated == false) //Add every boss room
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else if (GameSavingInformation.whereAmI == "ForestBoss" && GameSavingInformation.forestBossDefeated == true)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }

        if (GameSavingInformation.whereAmI == "The Great Tower Boss" && GameSavingInformation.snowBossDefeated == false) //Add every boss room
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else if (GameSavingInformation.whereAmI == "The Great Tower Boss" && GameSavingInformation.snowBossDefeated == true)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }

        if (GameSavingInformation.whereAmI == "Volcanic Caves 1" && QuestTracker.volcanoQuestCount == 1)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else if (GameSavingInformation.whereAmI == "Volcanic Caves 1" && QuestTracker.volcanoQuestCount > 1)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }

        if (GameSavingInformation.whereAmI == "Volcanic Boss Area" && GameSavingInformation.fireBossDefeated == false) //Add every boss room
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else if (GameSavingInformation.whereAmI == "Volcanic Boss Area" && GameSavingInformation.fireBossDefeated == true)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }

        if (GameSavingInformation.whereAmI == "Cereloth Grasslands" && GameSavingInformation.fireBossDefeated == true) //Add every boss room
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }

        if (GameSavingInformation.whereAmI == "Void Realm" && GameSavingInformation.finalBossDefeated == false) //Add every boss room
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else if (GameSavingInformation.whereAmI == "Void Realm" && GameSavingInformation.finalBossDefeated == true)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }

        if (GameSavingInformation.whereAmI == "The Great Tower Puzzle") //Add every boss room
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }

        if (GameSavingInformation.whereAmI == "Thillan Forest" && QuestTracker.forestQuestCount == 2)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else if (GameSavingInformation.whereAmI == "Thillan Forest" && QuestTracker.forestQuestCount != 2)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }

        if (GameSavingInformation.whereAmI == "Elder House" && QuestTracker.grasslandsQuestCount == 2)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else if (GameSavingInformation.whereAmI == "Elder House" && QuestTracker.grasslandsQuestCount != 2)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }

        if (GameSavingInformation.whereAmI == "Enchanter")
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }

        if (GameSavingInformation.whereAmI == "Desert Maze")
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        
    }
}
