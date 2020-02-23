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

    // Start is called before the first frame update
    void Start()
    {
        tooltipUI.SetActive(false);
        vendorPriceUI.SetActive(false);
        sellPriceUI.SetActive(false);
        equipmentAndStatsUI.SetActive(false);
        inventoryUI.SetActive(false);
        currencyUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
