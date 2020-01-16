using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public PlayerChar c;

    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentMenu equipmentMenu;

    public void Equip(EquipableItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquipableItem previousItem;
            if (equipmentMenu.AddItem(item, out previousItem))
            {
                if (previousItem !=  null)
                {
                    inventory.AddItem(previousItem);
                    previousItem.Unequip(c);
                }
                item.Equip(c);
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquipableItem item)
    {
        if (!inventory.isFull() && equipmentMenu.RemoveItem(item))
        {
            inventory.AddItem(item);
            item.Unequip(c);
        }
    }

    private void Awake()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentMenu.OnItemRightClickedEvent += UnequipFromEquipPanel;
    }

    private void EquipFromInventory(Item item)
    {
        if (item is EquipableItem)
        {
            Equip((EquipableItem)item);
        }
    }

    private void UnequipFromEquipPanel(Item item) 
    {
        if (item is EquipableItem)
        {
            Unequip((EquipableItem)item);
        }
    }
}
