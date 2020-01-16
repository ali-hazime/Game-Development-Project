using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggle : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject equipmentAndStatsUI;
    public GameObject tooltipUI;

    // Start is called before the first frame update
    void Start()
    {
        tooltipUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            tooltipUI.SetActive(false);
        }

        if (inventoryUI.activeSelf && equipmentAndStatsUI.activeSelf)
        {
            if (Input.GetButtonDown("Equipment & Stats"))
            {
                equipmentAndStatsUI.SetActive(false);
                inventoryUI.SetActive(false);
                tooltipUI.SetActive(false);
            }
        }

        else if (inventoryUI.activeSelf && !equipmentAndStatsUI.activeSelf)
        {
            if (Input.GetButtonDown("Equipment & Stats"))
            {
                equipmentAndStatsUI.SetActive(true);
                tooltipUI.SetActive(false);
            }
        }

        else if (!inventoryUI.activeSelf && !equipmentAndStatsUI.activeSelf)
        {
            if (Input.GetButtonDown("Equipment & Stats"))
            {
                equipmentAndStatsUI.SetActive(true);
                inventoryUI.SetActive(true);
                tooltipUI.SetActive(false);
            }
        }

        else if (!inventoryUI.activeSelf && equipmentAndStatsUI.activeSelf)
        {
            if (Input.GetButtonDown("Equipment & Stats"))
            {
                equipmentAndStatsUI.SetActive(false);
                tooltipUI.SetActive(false);
            }
        }
    } 
}
