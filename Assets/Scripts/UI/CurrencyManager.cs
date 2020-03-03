using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public Text currencyCountText;

    private void Update()
    {
        currencyCountText.text = "" + GameSavingInformation.crystalsCount.ToString();
    }

    public void AddCurrency(int crystals)
    {
        GameSavingInformation.crystalsCount += crystals;
        currencyCountText.text = "" + GameSavingInformation.crystalsCount.ToString();
    }
}

