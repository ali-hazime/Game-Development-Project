using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] ItemSaveManager itemSaveManager;
    [SerializeField] InventoryManager inventoryManager;
    private PlayerChar player;

    private void Start()
    {
        if (GameSavingInformation.isNewGame == true)
        {
            StartCoroutine(GetGone());
            player.playerCurrentHealth = 100;
            GameSavingInformation.crystalsCount = 0;
            GameSavingInformation.isNewGame = false;
        }
    }

    private void Awake()
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

        itemSaveManager.LoadEquipment(inventoryManager);
        itemSaveManager.LoadInventory(inventoryManager);

        PlayerGameData data = SaveSystem.LoadPlayer();

        player.playerCurrentHealth = data.healthS;

        QuestInfo questStuff = SaveSystem.LoadQuestInfo();

        QuestTracker.questInProgress = questStuff.questInProgressS;
        QuestTracker.bossKilled = questStuff.bossKilledS;
        QuestTracker.isKillQuest = questStuff.isKillQuestS;
        QuestTracker.isItemQuest = questStuff.isItemQuestS;
        QuestTracker.escortComplete = questStuff.escortCompleteS;
        QuestTracker.talkToComplete = questStuff.talkToCompleteS;
        QuestTracker.beginDesertQ3 = questStuff.beginDesertQ3S;
        QuestTracker.allTotemsCollected = questStuff.allTotemsCollectedS;
        QuestTracker.allObjCompleted = questStuff.allObjCompletedS;
        QuestTracker.fQ2_Item1 = questStuff.fQ2_Item1S;
        QuestTracker.fQ2_Item2 = questStuff.fQ2_Item2S;
        QuestTracker.fQ2_Item3 = questStuff.fQ2_Item3S;
        QuestTracker.killCount = questStuff.killCountS;
        QuestTracker.itemCount = questStuff.itemCountS;
        QuestTracker.mainQuestCount = questStuff.mainQuestCountS;
        QuestTracker.questType = questStuff.questTypeS;
        QuestTracker.grasslandsQuestCount = questStuff.grasslandsQuestCountS;
        QuestTracker.desertQuestCount = questStuff.desertQuestCountS;
        QuestTracker.forestQuestCount = questStuff.forestQuestCountS;
        QuestTracker.snowMountainQuestCount = questStuff.snowMountainQuestCountS;
        QuestTracker.volcanoQuestCount = questStuff.volcanoQuestCountS;

        InfoGameData GIdata = SaveSystem.LoadGameInfo();

        GameSavingInformation.playerX = GIdata.playerXS;
        GameSavingInformation.playerY = GIdata.playerYS;
        GameSavingInformation.whereAmI = GIdata.whereAmIS;
        GameSavingInformation.whereWasI = GIdata.whereWasIS;

        GameSavingInformation.dropChanceModifier = data.dropChanceModifierS;
        GameSavingInformation.crystalsCount = data.crystalsCountS;
        GameSavingInformation.minCurrency = data.minCurrencyS;
        GameSavingInformation.maxCurrency = data.maxCurrencyS;

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

    IEnumerator GetGone()
    {
        itemSaveManager.ClearInventory(inventoryManager);
        yield return new WaitForSeconds(0.1f);
        itemSaveManager.UnLoadEquipment(inventoryManager);
        yield return new WaitForSeconds(0.1f);
        itemSaveManager.ClearEquipment(inventoryManager);
        yield return new WaitForSeconds(0.1f);
        itemSaveManager.ClearInventory(inventoryManager);
        
        //itemSaveManager.UnLoadEquipment(inventoryManager);
       // yield return new WaitForSeconds(0.1f);
        //yield return new WaitForSeconds(0.1f);
        //itemSaveManager.ClearInventory(inventoryManager);
       // yield return new WaitForSeconds(0.1f);
       //itemSaveManager.UnLoadEquipment(inventoryManager);
       // yield return new WaitForSeconds(0.1f);
        //itemSaveManager.ClearInventory(inventoryManager);
    }

}
