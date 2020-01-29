using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemContainer : MonoBehaviour, IItemContainer
{
    [SerializeField] protected ItemSlots[] itemSlots;
    public virtual bool CanAddItem(Item item, int amount = 1)
    {
        int freeSlots = 0;

        foreach (ItemSlots itemSlots in itemSlots)
        {
            if (itemSlots.Item == null || itemSlots.Item.ID == item.ID)
            {
                freeSlots += item.MaxStacks - itemSlots.Amount;
            }
        }

        return freeSlots >= amount;
    }

    //Loops through item slots, if we find an item slot that does not have an item in it returns true, if no slots empty returns false
    public virtual bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].CanAddStack(item))
            {
                itemSlots[i].Item = item;
                itemSlots[i].Amount++;
                return true;
            }
        }

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                itemSlots[i].Item = item;
                itemSlots[i].Amount++;
                return true;
            }
        }
        return false;
    }

    //Same as AddItem but checking if item slot has item that will be removed, returns true if successful in removing item, false if not. 
    public virtual bool RemoveItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                itemSlots[i].Amount--;
                return true;
            }
        }
        return false;
    }

    public virtual Item RemoveItem(string itemID)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            Item item = itemSlots[i].Item;
            if (item != null && item.ID == itemID)
            {
                itemSlots[i].Amount--;
                return item;
            }
        }
        return null;
    }

    /*public virtual bool ContainsItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                itemSlots[i].Amount--;
                if (itemSlots[i].Amount == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }*/

    public virtual int ItemCount(string itemID)
    {
        int number = 0;

        for (int i = 0; i < itemSlots.Length; i++)
        {
            Item item = itemSlots[i].Item;
  
                if (item != null && item.ID == itemID)
                {
                    number += itemSlots[i].Amount;
                }
        }
        return number;
    }

    public virtual void Clear()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
            itemSlots[i].Amount = 0;
        }
    }
}