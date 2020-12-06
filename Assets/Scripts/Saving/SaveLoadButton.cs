using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadButton : MonoBehaviour
{
    [SerializeField] PlayerChar player;
    [SerializeField] ItemSaveManager itemSaveManager;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] UIToggle uiToggle;
    //private EnemyHealth eh;
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }
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

        if (pauseMenu == null)
        {
            pauseMenu = FindObjectOfType<PauseGame>().gameObject;
        }
        // eh = FindObjectOfType<EnemyHealth>();
        // ehO = FindObjectOfType<>
    }
    /*
    private void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }*/

    public void Save()
    {
        StartCoroutine(SaveTheGame());
    }

    IEnumerator SaveTheGame()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("SAVED");
        GameSavingInformation.playerX = player.gameObject.transform.position.x;
        GameSavingInformation.playerY = player.gameObject.transform.position.y;
        SaveSystem.SavePlayer(player);
        SaveSystem.SaveGameInfo();
        SaveSystem.SaveQuestInfo();
        itemSaveManager.SaveEquipment(inventoryManager);
        itemSaveManager.SaveInventory(inventoryManager);
    }

    public void Load()
    {

        if (GameSavingInformation.whereAmI == "The Great Tower Puzzle")
        {
            GameSavingInformation.whereAmI = "Mount Herraweth";
            GameSavingInformation.whereWasI = "Mount Herraweth";
            GameSavingInformation.playerX = 0f;
            GameSavingInformation.playerY = 1.5f;
            SaveSystem.SavePlayer(player);
            SaveSystem.SaveGameInfo();
            SaveSystem.SaveQuestInfo();
            itemSaveManager.SaveEquipment(inventoryManager);
            itemSaveManager.SaveInventory(inventoryManager);
            SceneManager.LoadScene("Mount Herraweth");
        }
        else
        {
            InfoGameData GIdata = SaveSystem.LoadGameInfo();
            Vector3 position;
            position.x = GIdata.playerXS;
            position.y = GIdata.playerYS;
            position.z = 0;
            player.transform.position = position;

            itemSaveManager.LoadEquipment(inventoryManager);
            itemSaveManager.LoadInventory(inventoryManager);
            PlayerGameData data = SaveSystem.LoadPlayer();

            player.playerCurrentHealth = data.healthS;
            GameSavingInformation.dropChanceModifier = data.dropChanceModifierS;
            GameSavingInformation.crystalsCount = data.crystalsCountS;
            GameSavingInformation.minCurrency = data.minCurrencyS;
            GameSavingInformation.maxCurrency = data.maxCurrencyS;
            GameSavingInformation.bonusHealth = GIdata.bonusHealthS;

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
            QuestTracker.triggerOnce = questStuff.triggerOnceS;
            QuestTracker.triggerOnce2 = questStuff.triggerOnce2S;
            QuestTracker.fQ2_Item1 = questStuff.fQ2_Item1S;
            QuestTracker.fQ2_Item2 = questStuff.fQ2_Item2S;
            QuestTracker.fQ2_Item3 = questStuff.fQ2_Item3S;
            QuestTracker.killCount = questStuff.killCountS;
            QuestTracker.itemCount = questStuff.itemCountS;
            QuestTracker.grasslandsQuestCount = questStuff.grasslandsQuestCountS;
            QuestTracker.desertQuestCount = questStuff.desertQuestCountS;
            QuestTracker.forestQuestCount = questStuff.forestQuestCountS;
            QuestTracker.snowMountainQuestCount = questStuff.snowMountainQuestCountS;
            QuestTracker.volcanoQuestCount = questStuff.volcanoQuestCountS;

            GameSavingInformation.isNewGame = GIdata.isNewGameS;

            GameSavingInformation.differenceNumber = GIdata.differenceNumberS;
            GameSavingInformation.ruby1Collected = GIdata.ruby1CollectedS;
            GameSavingInformation.ruby1Collected = GIdata.ruby2CollectedS;
            GameSavingInformation.ruby3Collected = GIdata.ruby3CollectedS;
            GameSavingInformation.ruby4Collected = GIdata.ruby4CollectedS;
            GameSavingInformation.ruby5Collected = GIdata.ruby5CollectedS;
            GameSavingInformation.ruby6Collected = GIdata.ruby6CollectedS;
            GameSavingInformation.ruby7Collected = GIdata.ruby7CollectedS;
            GameSavingInformation.ruby8Collected = GIdata.ruby8CollectedS;
            GameSavingInformation.ruby9Collected = GIdata.ruby9CollectedS;
            GameSavingInformation.ruby10Collected = GIdata.ruby10CollectedS;

            GameSavingInformation.sapphire1Collected = GIdata.sapphire1CollectedS;
            GameSavingInformation.sapphire2Collected = GIdata.sapphire2CollectedS;
            GameSavingInformation.sapphire3Collected = GIdata.sapphire3CollectedS;
            GameSavingInformation.sapphire4Collected = GIdata.sapphire4CollectedS;
            GameSavingInformation.sapphire5Collected = GIdata.sapphire5CollectedS;

            GameSavingInformation.playerX = GIdata.playerXS;
            GameSavingInformation.playerY = GIdata.playerYS;
            GameSavingInformation.whereAmI = GIdata.whereAmIS;
            GameSavingInformation.whereWasI = GIdata.whereWasIS;

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

        pauseMenu.SetActive(false);
        uiToggle.isPaused = false;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        uiToggle.isPaused = false;
    }
}
