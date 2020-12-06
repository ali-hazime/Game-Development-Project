using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTowerPuzzle : MonoBehaviour
{
    private PlayerChar player;
    [SerializeField] ItemSaveManager itemSaveManager;
    [SerializeField] InventoryManager inventoryManager;


    public void Start()
    {
        if (itemSaveManager == null)
        {
            itemSaveManager = FindObjectOfType<ItemSaveManager>();
        }

        if (inventoryManager == null)
        {
            inventoryManager = FindObjectOfType<InventoryManager>();
        }
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }
    private void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.CompareTag("Player"))
        {
            // if (QuestTracker.snowMountainQuestCount == 1)
            //{
                PuzzleController.overallCount = 0;
                GameSavingInformation.whereAmI = "The Great Tower Puzzle";
                GameSavingInformation.whereWasI = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("The Great Tower Puzzle");
                GameSavingInformation.playerX = 0f;
                GameSavingInformation.playerY = -7f;
                SaveSystem.SavePlayer(player);
                SaveSystem.SaveGameInfo();
                SaveSystem.SaveQuestInfo();
                itemSaveManager.SaveEquipment(inventoryManager);
                itemSaveManager.SaveInventory(inventoryManager);
            //}
           /* else
            {
                GameSavingInformation.whereAmI = "The Great Tower Boss";
                GameSavingInformation.whereWasI = SceneManager.GetActiveScene().name;
                //GameSavingInformation.whereWasI = "The Great Tower Boss";
                SceneManager.LoadScene("The Great Tower Boss");
                GameSavingInformation.maxCurrency = 75;
                GameSavingInformation.minCurrency = 60;
                GameSavingInformation.playerX = 0f;
                GameSavingInformation.playerY = -6.5f;
            }*/
        }
    }
}
