using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSellPrice : MonoBehaviour
{
    [SerializeField] Text ItemSellPriceText;

    public void ShowPrice(Item item)
    {
        ItemSellPriceText.text = item.SellItemPrice.ToString();
        gameObject.SetActive(true);
    }

    public void HidePrice()
    {
        gameObject.SetActive(false);
    }
}
