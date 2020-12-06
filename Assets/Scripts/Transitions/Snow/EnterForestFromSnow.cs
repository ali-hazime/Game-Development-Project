using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterForestFromSnow : MonoBehaviour
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
        if (QuestTracker.snowMountainQuestCount == 3)
        {
            QuestTracker.snowMountainQuestCount = 4;
        }
        if (thing.CompareTag("Player"))
        {
            QuestTracker.talkToComplete = false;
            GameSavingInformation.whereAmI = "Thillan Forest";
            GameSavingInformation.whereWasI = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Thillan Forest");
            GameSavingInformation.maxCurrency = 12;
            GameSavingInformation.minCurrency = 7;
            GameSavingInformation.playerX = 137f;
            GameSavingInformation.playerY = 84.5f;
            SaveSystem.SavePlayer(player);
            SaveSystem.SaveGameInfo();
            SaveSystem.SaveQuestInfo();
            itemSaveManager.SaveEquipment(inventoryManager);
            itemSaveManager.SaveInventory(inventoryManager);
        }
    }
}
