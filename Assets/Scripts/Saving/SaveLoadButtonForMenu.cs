using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadButtonForMenu : MonoBehaviour
{
    private PlayerChar player;
    [SerializeField] ItemSaveManager itemSaveManager;
    [SerializeField] InventoryManager inventoryManager;
    // [SerializeField] GameObject pauseMenu;
    // [SerializeField] UIToggle uiToggle;
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

        // if (uiToggle == null)
        // {
        //     uiToggle = FindObjectOfType<UIToggle>();
        //  }
        player = FindObjectOfType<PlayerChar>();
        // eh = FindObjectOfType<EnemyHealth>();
        // ehO = FindObjectOfType<>
    }
   /* public void Save()
    {
        SaveSystem.SavePlayer(player);
        SaveSystem.SaveGameInfo();
        itemSaveManager.SaveEquipment(inventoryManager);
        itemSaveManager.SaveInventory(inventoryManager);
    }*/

    public void Load()
    {

        itemSaveManager.LoadEquipment(inventoryManager);
        itemSaveManager.LoadInventory(inventoryManager);
        PlayerGameData data = SaveSystem.LoadPlayer();

        player.playerCurrentHealth = data.healthS;

        Vector3 position;
        position.x = data.positionS[0];
        position.y = data.positionS[1];
        position.z = data.positionS[2];
        player.transform.position = position;

        InfoGameData GIdata = SaveSystem.LoadGameInfo();

        GameSavingInformation.dropChanceModifier = data.dropChanceModifierS;
        GameSavingInformation.crystalsCount = data.crystalsCountS;
        GameSavingInformation.minCurrency = data.minCurrencyS;
        GameSavingInformation.maxCurrency = data.maxCurrencyS;
        GameSavingInformation.bonusHealth = GIdata.bonusHealthS;

        GameSavingInformation.grassBossDefeated = GIdata.grassBossDefeatedS;
        GameSavingInformation.forestBossDefeated = GIdata.forestBossDefeatedS;
        GameSavingInformation.desertBossDefeated = GIdata.desertBossDefeatedS;
        GameSavingInformation.snowBossDefeated = GIdata.snowBossDefeatedS;
        GameSavingInformation.fireBossDefeated = GIdata.fireBossDefeatedS;
        GameSavingInformation.finalBossDefeated = GIdata.finalBossDefeatedS;

        //Grasslands Quests
        GameSavingInformation.grassQuest1Complete = GIdata.grassQuest1CompleteS;
        GameSavingInformation.grassQuest2Complete = GIdata.grassQuest2CompleteS;
        GameSavingInformation.grassQuest3Complete = GIdata.grassQuest3CompleteS;
        GameSavingInformation.grassQuest4Complete = GIdata.grassQuest4CompleteS;
        GameSavingInformation.grassQuest5Complete = GIdata.grassQuest5CompleteS;
        GameSavingInformation.grassQuest6Complete = GIdata.grassQuest6CompleteS;
        GameSavingInformation.grassQuest7Complete = GIdata.grassQuest7CompleteS;

        //Forest Quests
        GameSavingInformation.forestQuest1Complete = GIdata.forestQuest1CompleteS;
        GameSavingInformation.forestQuest2Complete = GIdata.forestQuest2CompleteS;
        GameSavingInformation.forestQuest3Complete = GIdata.forestQuest3CompleteS;
        GameSavingInformation.forestQuest4Complete = GIdata.forestQuest4CompleteS;
        GameSavingInformation.forestQuest5Complete = GIdata.forestQuest5CompleteS;

        //Desert Quests
        GameSavingInformation.desertMazeComplete = GIdata.desertMazeCompleteS;
        GameSavingInformation.desertQuest1Complete = GIdata.desertQuest1CompleteS;
        GameSavingInformation.desertQuest2Complete = GIdata.desertQuest2CompleteS;
        GameSavingInformation.desertQuest3Complete = GIdata.desertQuest3CompleteS;
        GameSavingInformation.desertQuest4Complete = GIdata.desertQuest4CompleteS;
        GameSavingInformation.desertQuest5Complete = GIdata.desertQuest5CompleteS;
        GameSavingInformation.desertQuest6Complete = GIdata.desertQuest6CompleteS;

        //Snow Mountain Quests
        GameSavingInformation.snowQuest1Complete = GIdata.snowQuest1CompleteS;
        GameSavingInformation.snowQuest2Complete = GIdata.snowQuest2CompleteS;
        GameSavingInformation.snowQuest3Complete = GIdata.snowQuest3CompleteS;

        //Volcano Quests
        GameSavingInformation.volcanoQuest1Complete = GIdata.volcanoQuest1CompleteS;
        GameSavingInformation.volcanoQuest2Complete = GIdata.volcanoQuest2CompleteS;
        GameSavingInformation.volcanoQuest3Complete = GIdata.volcanoQuest3CompleteS;
        GameSavingInformation.volcanoQuest4Complete = GIdata.volcanoQuest4CompleteS;
        GameSavingInformation.volcanoQuest5Complete = GIdata.volcanoQuest5CompleteS;

    }
}
