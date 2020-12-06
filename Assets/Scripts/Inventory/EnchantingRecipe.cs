using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct ItemAmount
{
    public Item Item;
    [Range(1, 99)]
    public int Amount;
}

[CreateAssetMenu]
public class EnchantingRecipe : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Results;

    public bool CanEnchant(IItemContainer itemContainer)
    {
        return HasMaterials(itemContainer) && HasSpace(itemContainer);
    }

    private bool HasMaterials(IItemContainer itemContainer)
    {
        foreach (ItemAmount itemAmount in Materials)
        {
            if (itemContainer.ItemCount(itemAmount.Item.ID) < itemAmount.Amount)
            {
                Debug.Log("Insufficient materials to enchant.");
                return false;
            }
        }
        return true;
    }

    private bool HasSpace(IItemContainer itemContainer)
    {
        foreach (ItemAmount itemAmount in Results)
        {
            if (!itemContainer.CanAddItem(itemAmount.Item, itemAmount.Amount))
            {
                Debug.LogWarning("Insufficient inventory space.");
                return false;
            }
        }
        return true;
    }


    public void Enchant(IItemContainer itemContainer)
    {
        if (CanEnchant(itemContainer))
        {
            RemoveMaterials(itemContainer);
            AddResults(itemContainer);
        }
    }

    private void AddResults(IItemContainer itemContainer)
    {
        foreach (ItemAmount itemAmount in Results)
        {
            for (int i = 0; i < itemAmount.Amount; i++)
            {
                itemContainer.AddItem(itemAmount.Item.GetCopy());
            }
        }
    }

    private void RemoveMaterials(IItemContainer itemContainer)
    {
        foreach (ItemAmount itemAmount in Materials)
        {
            for (int i = 0; i < itemAmount.Amount; i++)
            {
                Item oldItem = itemContainer.RemoveItem(itemAmount.Item.ID);
                oldItem.Destroy();
            }
        }
    }
}
