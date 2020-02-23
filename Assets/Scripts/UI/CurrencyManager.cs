using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    private GameObject PlayerChar;

    public int crystalsCount;
    public Text currencyCountText;

    private void Start()
    {
        PlayerChar = GameObject.FindWithTag("Player");
        crystalsCount = PlayerPrefs.GetInt("crystalsCount");
    }

    private void Update()
    {
        currencyCountText.text = "" + crystalsCount.ToString();
        PlayerPrefs.SetInt("crystalsCount", crystalsCount);
    }

    public void AddCurrency()
    {
        crystalsCount += 1000;
        currencyCountText.text = "" + crystalsCount.ToString();
    }
}

