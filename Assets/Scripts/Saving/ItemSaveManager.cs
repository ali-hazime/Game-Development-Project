using System.Collections.Generic;
using UnityEngine;

public class ItemSaveManager : MonoBehaviour
{
    [SerializeField] ItemDatabase itemDatabase;

    private const string InventoryFileName = "Inventory";
    private const string EquipmentFileName = "Equipment";

    public void LoadInventory(InventoryManager inventoryManager)
    {
        ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(InventoryFileName);
        if (savedSlots == null) return;
        inventoryManager.inventory.Clear();

        for (int i = 0; i < savedSlots.SavedSlots.Length; i++)
        {
            ItemSlots itemSlot = inventoryManager.inventory.itemSlots[i];
            ItemSlotSaveData savedSlot = savedSlots.SavedSlots[i];

            if (savedSlot == null)
            {
                itemSlot.Item = null;
                itemSlot.Amount = 0;
            }
            else
            {
                itemSlot.Item = itemDatabase.GetItemCopy(savedSlot.ItemID);
                itemSlot.Amount = savedSlot.Amount;
            }
        }
    }

    public void LoadEquipment(InventoryManager inventoryManager)
    {
        ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(EquipmentFileName);
        if (savedSlots == null) return;

        foreach (ItemSlotSaveData savedSlot in savedSlots.SavedSlots)
        {
            if (savedSlot == null)
            {
                continue;
            }

            Item item = itemDatabase.GetItemCopy(savedSlot.ItemID);
            inventoryManager.inventory.AddItem(item);
            inventoryManager.Equip((EquipableItem)item);
        }
    }

    public void SaveInventory(InventoryManager inventoryManager)
    {
        SaveItems(inventoryManager.inventory.itemSlots, InventoryFileName);
    }

    public void SaveEquipment(InventoryManager inventoryManager)
    {
        SaveItems(inventoryManager.equipmentMenu.equipmentSlots, EquipmentFileName);
    }

    private void SaveItems(IList<ItemSlots> itemSlots, string fileName)
    {
        var saveData = new ItemContainerSaveData(itemSlots.Count);

        for (int i = 0; i < saveData.SavedSlots.Length; i++)
        {
            ItemSlots itemSlot = itemSlots[i];

            if (itemSlot.Item == null)
            {
                saveData.SavedSlots[i] = null;
            }
            else
            {
                saveData.SavedSlots[i] = new ItemSlotSaveData(itemSlot.Item.ID, itemSlot.Amount);
            }
        }

        ItemSaveIO.SaveItems(saveData, fileName);
    }
}
