using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorWest : MonoBehaviour
{
    public int doorNumber;
    private PlayerChar player;
    [SerializeField] ItemSaveManager itemSaveManager;
    [SerializeField] InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
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
            if (doorNumber == 0 && PuzzleController.overallCount < 6)
            {
                PuzzleController.overallCount++;
                GameSavingInformation.whereAmI = "The Great Tower Puzzle";
                GameSavingInformation.whereWasI = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("The Great Tower Puzzle");
                GameSavingInformation.playerX = 7.5f;
                GameSavingInformation.playerY = 0.5f;
            }
            else if (doorNumber == 0 && PuzzleController.overallCount == 6)
            {
                PuzzleController.overallCount++;
                GameSavingInformation.whereAmI = "The Great Tower Boss";
                GameSavingInformation.whereWasI = "The Great Tower Boss";
                SceneManager.LoadScene("The Great Tower Boss");
                GameSavingInformation.playerX = 0f;
                GameSavingInformation.playerY = -6.5f;
            }
            else if (doorNumber == 1 && PuzzleController.overallCount > 1)
            {
                PuzzleController.overallCount--;
                GameSavingInformation.whereAmI = "The Great Tower Puzzle";
                GameSavingInformation.whereWasI = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("The Great Tower Puzzle");
                GameSavingInformation.playerX = 7.5f;
                GameSavingInformation.playerY = 0.5f;
            }
            else if (doorNumber == 1 && PuzzleController.overallCount < 2)
            {
                PuzzleController.overallCount--;
                GameSavingInformation.whereAmI = "Mount Herraweth";
                GameSavingInformation.whereWasI = "Mount Herraweth";
                SceneManager.LoadScene("Mount Herraweth");
                GameSavingInformation.playerX = 194.5f;
                GameSavingInformation.playerY = 91.5f;
            }
            else if (doorNumber == 2)
            {
                GameSavingInformation.whereAmI = "The Great Tower Puzzle";
                GameSavingInformation.whereWasI = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("The Great Tower Puzzle");
                GameSavingInformation.playerX = 7.5f;
                GameSavingInformation.playerY = 0.5f;
            }

            SaveSystem.SavePlayer(player);
            SaveSystem.SaveGameInfo();
            SaveSystem.SaveQuestInfo();
            itemSaveManager.SaveEquipment(inventoryManager);
            itemSaveManager.SaveInventory(inventoryManager);
        }
    }
}
