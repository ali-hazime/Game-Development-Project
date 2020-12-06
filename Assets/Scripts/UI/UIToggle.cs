using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggle : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject equipmentAndStatsUI;
    public GameObject tooltipUI;
    public GameObject vendorPriceUI;
    public GameObject sellPriceUI;
    public GameObject currencyUI;
    public GameObject pauseMenu;
    public GameObject questUI;
    public GameObject TextboxUI;
    public GameObject controlsUI;
    public GameObject mapUI;
    public bool isPaused = false;
    public bool questLogOpen = false;
    [SerializeField] GameObject PlayerIconGL;
    [SerializeField] GameObject PlayerIconD;
    [SerializeField] GameObject PlayerIconF;
    [SerializeField] GameObject PlayerIconS;
    [SerializeField] GameObject PlayerIconV;

    private void Awake()
    {
        if (TextboxUI == null)
        {
            TextboxUI = FindObjectOfType<NPC_Dialogue>().gameObject;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
        TextboxUI.SetActive(false);
        tooltipUI.SetActive(false);
        vendorPriceUI.SetActive(false);
        sellPriceUI.SetActive(false);
        equipmentAndStatsUI.SetActive(false);
        inventoryUI.SetActive(false);
        currencyUI.SetActive(false);
        pauseMenu.SetActive(false);
        mapUI.SetActive(false);
        //questUI.GetComponent<CanvasGroup>().alpha = 0;
        //questUI.GetComponent<CanvasGroup>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (questUI == null)
        {
          questUI =  FindObjectOfType<QuestCanvas>().gameObject;
        }
        if (!pauseMenu.activeSelf)
        {
            if (Input.GetButtonDown("Pause"))
            {
                pauseMenu.SetActive(true);
                isPaused = true;
                tooltipUI.SetActive(false);
                vendorPriceUI.SetActive(false);
                sellPriceUI.SetActive(false);
                equipmentAndStatsUI.SetActive(false);
                inventoryUI.SetActive(false);
                currencyUI.SetActive(false);
                mapUI.SetActive(false);
                questUI.GetComponent<CanvasGroup>().alpha = 0;
                questUI.GetComponent<CanvasGroup>().interactable = false;
                questLogOpen = false;
            }
        }
        
        else if (pauseMenu.activeSelf)
        {
            if (Input.GetButtonDown("Pause"))
            {
                pauseMenu.SetActive(false);
                isPaused = false;
                if (controlsUI.activeSelf)
                {
                    controlsUI.SetActive(false);
                } 
            }   
        }

        if (isPaused == false)
        {
            if (Input.GetButtonDown("Quest Log") && questLogOpen == false)
            {
                questUI.GetComponent<CanvasGroup>().alpha = 1;
                questUI.GetComponent<CanvasGroup>().interactable = true;
                questLogOpen = true;
            }

            else if (Input.GetButtonDown("Quest Log") && questLogOpen == true)
            {
                questUI.GetComponent<CanvasGroup>().alpha = 0;
                questUI.GetComponent<CanvasGroup>().interactable = false;
                questLogOpen = false;
            }

            if (Input.GetButtonDown("Inventory"))
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
                currencyUI.SetActive(!currencyUI.activeSelf);
                tooltipUI.SetActive(false);
                sellPriceUI.SetActive(false);
                vendorPriceUI.SetActive(false);
                mapUI.SetActive(false);
            }

            if (Input.GetButtonDown("Map"))
            {
                PlayerIcon();
                mapUI.SetActive(!mapUI.activeSelf);
                equipmentAndStatsUI.SetActive(false);
                inventoryUI.SetActive(false);
                currencyUI.SetActive(false);
                tooltipUI.SetActive(false);
                sellPriceUI.SetActive(false);
                vendorPriceUI.SetActive(false);
            }

            if (inventoryUI.activeSelf && equipmentAndStatsUI.activeSelf)
            {
                if (Input.GetButtonDown("Equipment & Stats"))
                {
                    equipmentAndStatsUI.SetActive(false);
                    inventoryUI.SetActive(false);
                    currencyUI.SetActive(false);
                    tooltipUI.SetActive(false);
                    sellPriceUI.SetActive(false);
                    vendorPriceUI.SetActive(false);
                    mapUI.SetActive(false);
                }
            }

            else if (inventoryUI.activeSelf && !equipmentAndStatsUI.activeSelf)
            {
                if (Input.GetButtonDown("Equipment & Stats"))
                {
                    equipmentAndStatsUI.SetActive(true);
                    tooltipUI.SetActive(false);
                    sellPriceUI.SetActive(false);
                    vendorPriceUI.SetActive(false);
                    mapUI.SetActive(false);
                }
            }

            else if (!inventoryUI.activeSelf && !equipmentAndStatsUI.activeSelf)
            {
                if (Input.GetButtonDown("Equipment & Stats"))
                {
                    equipmentAndStatsUI.SetActive(true);
                    inventoryUI.SetActive(true);
                    currencyUI.SetActive(true);
                    tooltipUI.SetActive(false);
                    sellPriceUI.SetActive(false);
                    vendorPriceUI.SetActive(false);
                    mapUI.SetActive(false);
                }
            }

            else if (!inventoryUI.activeSelf && equipmentAndStatsUI.activeSelf)
            {
                if (Input.GetButtonDown("Equipment & Stats"))
                {
                    equipmentAndStatsUI.SetActive(false);
                    tooltipUI.SetActive(false);
                    sellPriceUI.SetActive(false);
                    vendorPriceUI.SetActive(false);
                    mapUI.SetActive(false);
                }
            }
        }
        
    }

    public void PlayerIcon()
    {
        if (GameSavingInformation.whereAmI == "Cereloth Grasslands" || GameSavingInformation.whereAmI == "Elder House" || GameSavingInformation.whereAmI == "GrasslandsBoss" || GameSavingInformation.whereAmI == "Inside Castle" || GameSavingInformation.whereAmI == "Player House" || GameSavingInformation.whereAmI == "Vendor House")
        {
            PlayerIconGL.SetActive(true);
            PlayerIconD.SetActive(false);
            PlayerIconF.SetActive(false);
            PlayerIconS.SetActive(false);
            PlayerIconV.SetActive(false);
        }
        else if (GameSavingInformation.whereAmI == "Jeralehar Desert" || GameSavingInformation.whereAmI == "Desert Vendor House" || GameSavingInformation.whereAmI == "DesertBoss")
        {
            PlayerIconGL.SetActive(false);
            PlayerIconD.SetActive(true);
            PlayerIconF.SetActive(false);
            PlayerIconS.SetActive(false);
            PlayerIconV.SetActive(false);
        }
        else if (GameSavingInformation.whereAmI == "Thillan Forest" || GameSavingInformation.whereAmI == "ForestBoss" || GameSavingInformation.whereAmI == "ForestVendor")
        {
            PlayerIconGL.SetActive(false);
            PlayerIconD.SetActive(false);
            PlayerIconF.SetActive(true);
            PlayerIconS.SetActive(false);
            PlayerIconV.SetActive(false);
        }
        else if (GameSavingInformation.whereAmI == "Mount Herraweth" || GameSavingInformation.whereAmI == "Snow Vendor" || GameSavingInformation.whereAmI == "SnowCave" || GameSavingInformation.whereAmI == "The Great Tower Boss" || GameSavingInformation.whereAmI == "The Great Tower Puzzle")
        {
            PlayerIconGL.SetActive(false);
            PlayerIconD.SetActive(false);
            PlayerIconF.SetActive(false);
            PlayerIconS.SetActive(true);
            PlayerIconV.SetActive(false);
        }
        else if (GameSavingInformation.whereAmI == "Mount Mortae" || GameSavingInformation.whereAmI == "Volcanic Boss Area" || GameSavingInformation.whereAmI == "Volcanic Caves 1")
        {
            PlayerIconGL.SetActive(false);
            PlayerIconD.SetActive(false);
            PlayerIconF.SetActive(false);
            PlayerIconS.SetActive(false);
            PlayerIconV.SetActive(true);
        }
    }

    public void ToggleQuestLog()
    {
        questUI.GetComponent<CanvasGroup>().alpha = 1;
        questUI.GetComponent<CanvasGroup>().interactable = true;
        questLogOpen = true;
    }

    public void ToggleQuestLogOff()
    {
        questUI.GetComponent<CanvasGroup>().alpha = 0;
        questUI.GetComponent<CanvasGroup>().interactable = false;
        questLogOpen = false;
    }

    public void ToggleControls()
    {
        controlsUI.SetActive(true);
    }
}
