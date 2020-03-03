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
    public bool isPaused = false;
    public bool questLogOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
        tooltipUI.SetActive(false);
        vendorPriceUI.SetActive(false);
        sellPriceUI.SetActive(false);
        equipmentAndStatsUI.SetActive(false);
        inventoryUI.SetActive(false);
        currencyUI.SetActive(false);
        pauseMenu.SetActive(false);
        questUI.GetComponent<CanvasGroup>().alpha = 0;
        questUI.GetComponent<CanvasGroup>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
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
                }
            }
        }
        
    } 
}
