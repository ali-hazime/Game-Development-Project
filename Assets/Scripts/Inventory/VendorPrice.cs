using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorPrice : MonoBehaviour
{
    [SerializeField] Text ItemPriceText;

    public void ShowPrice(Item item)
    {
        ItemPriceText.text = item.ItemPrice.ToString();
        gameObject.SetActive(true);
    }

    public void HidePrice()
    {
        gameObject.SetActive(false);
    }
}
