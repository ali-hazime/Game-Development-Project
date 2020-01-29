using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltips : MonoBehaviour
{
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ItemTypeText;
    [SerializeField] Text ItemStatsText;

    
    public void ShowToolTip(Item item)
    {
        ItemNameText.text = item.ItemName;
        ItemTypeText.text = item.GetItemType();
        ItemStatsText.text = item.GetStats();

        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }
}
