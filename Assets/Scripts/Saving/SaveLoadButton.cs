using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadButton : MonoBehaviour
{
    private PlayerChar player;
    [SerializeField] ItemSaveManager itemSaveManager;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] UIToggle uiToggle;
    //private EnemyHealth eh;

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

        if (uiToggle == null)
        {
            uiToggle = FindObjectOfType<UIToggle>();
        }
        player = FindObjectOfType<PlayerChar>();
       // eh = FindObjectOfType<EnemyHealth>();
       // ehO = FindObjectOfType<>
    }
    public void Save()
    {
        SaveSystem.SavePlayer(player);
        //SaveSystem.SaveGameInfo();
        itemSaveManager.SaveEquipment(inventoryManager);
        itemSaveManager.SaveInventory(inventoryManager);
    }

    public void Load()
    {
        pauseMenu.SetActive(false);
        uiToggle.isPaused = false;

        itemSaveManager.LoadEquipment(inventoryManager);
        itemSaveManager.LoadInventory(inventoryManager);
        PlayerGameData data = SaveSystem.LoadPlayer();

        player.playerCurrentHealth = data.healthS;
        GameSavingInformation.dropChanceModifier = data.dropChanceModifierS;
        GameSavingInformation.crystalsCount = data.crystalsCountS;
        GameSavingInformation.minCurrency = data.minCurrencyS;
        GameSavingInformation.maxCurrency = data.maxCurrencyS;

        Vector3 position;
        position.x = data.positionS[0];
        position.y = data.positionS[1];
        position.z = data.positionS[2];
        player.transform.position = position;

        //InfoGameData GIdata = SaveSystem.LoadGameInfo();
        
        /*
        GameSavingInformation.grassBossDefeated = GIdata.grassBossDefeatedS;
        GameSavingInformation.forestBossDefeated = GIdata.forestBossDefeatedS;
        GameSavingInformation.desertBossDefeated = GIdata.desertBossDefeatedS;
        GameSavingInformation.snowBossDefeated = GIdata.snowBossDefeatedS;
        GameSavingInformation.fireBossDefeated = GIdata.fireBossDefeatedS;
        GameSavingInformation.finalBossDefeated = GIdata.finalBossDefeatedS;

        //Grasslands Quests
        GameSavingInformation.cropsInspected = GIdata.cropsInspectedS;
        GameSavingInformation.grassQuest1Complete = GIdata.grassQuest1CompleteS;
        GameSavingInformation.townsFolkTalkedTo = GIdata.townsFolkTalkedToS;
        GameSavingInformation.grassQuest2Complete = GIdata.grassQuest2CompleteS;
        GameSavingInformation.grassQuest3Complete = GIdata.grassQuest3CompleteS;
        GameSavingInformation.grassQuest4Complete = GIdata.grassQuest4CompleteS;
        GameSavingInformation.grassQuest5AComplete = GIdata.grassQuest5ACompleteS;
        GameSavingInformation.grassQuest5BComplete = GIdata.grassQuest5BCompleteS;

        //Forest Quests
        GameSavingInformation.forestQuest1Complete = GIdata.forestQuest1CompleteS;
        GameSavingInformation.forestQuest2AComplete = GIdata.forestQuest2ACompleteS;
        GameSavingInformation.forestQuest2BComplete = GIdata.forestQuest2BCompleteS;
        GameSavingInformation.forestQuest2CComplete = GIdata.forestQuest2CCompleteS;
        GameSavingInformation.forestQuest2Complete = GIdata.forestQuest2CompleteS;
        GameSavingInformation.forestQuest3Complete = GIdata.forestQuest3CompleteS;
        GameSavingInformation.forestQuest4Complete = GIdata.forestQuest4CompleteS;
        GameSavingInformation.forestQuest5Complete = GIdata.forestQuest5CompleteS;

        //Desert Quests
        GameSavingInformation.desertQuest1Complete = GIdata.desertQuest1CompleteS;
        GameSavingInformation.desertQuest2Complete = GIdata.desertQuest2CompleteS;
        GameSavingInformation.desertQuest3Complete = GIdata.desertQuest3CompleteS;
        GameSavingInformation.desertQuest4AComplete = GIdata.desertQuest4ACompleteS;
        GameSavingInformation.desertQuest4BComplete = GIdata.desertQuest4BCompleteS;
        GameSavingInformation.desertQuest5Complete = GIdata.desertQuest5CompleteS;

        //Snow Mountain Quests
        GameSavingInformation.snowQuest1Complete = GIdata.snowQuest1CompleteS;
        GameSavingInformation.snowQuest2Complete = GIdata.snowQuest2CompleteS;
        GameSavingInformation.snowQuest3Complete = GIdata.snowQuest3CompleteS;
        GameSavingInformation.snowQuest4Complete = GIdata.snowQuest4CompleteS;
        GameSavingInformation.snowQuest5Complete = GIdata.snowQuest5CompleteS;

        //Volcano Quests
        GameSavingInformation.volcanoQuest1Complete = GIdata.volcanoQuest1CompleteS;
        GameSavingInformation.minersSpokenTo = GIdata.minersSpokenToS;
        GameSavingInformation.volcanoQuest2Complete = GIdata.volcanoQuest2CompleteS;
        GameSavingInformation.volcanoQuest3Complete = GIdata.volcanoQuest3CompleteS;
        GameSavingInformation.volcanoQuest4Complete = GIdata.volcanoQuest4CompleteS;
        GameSavingInformation.volcanoQuest5Complete = GIdata.volcanoQuest5CompleteS;

        //Final Quest
        GameSavingInformation.finalQuest1Complete = GIdata.finalQuest1CompleteS;
        GameSavingInformation.finalQuest2Complete = GIdata.finalQuest2CompleteS;
        */

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        uiToggle.isPaused = false;
    }
}
