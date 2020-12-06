using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public PlayerChar c;
    public CurrencyManager cm;
    public GameObject sellItem;

    public Inventory inventory;
    public EquipmentMenu equipmentMenu;
    [SerializeField] EnchantingWindow enchantingWindow;
    [SerializeField] Vendor vendorWindow;    
    [SerializeField] ItemTooltips itemTooltips;
    [SerializeField] VendorPrice vendorPrice;
    [SerializeField] ItemSellPrice sellPrice;
    [SerializeField] Image draggableItem;
    [SerializeField] Image draggableItemIcon;
    [SerializeField] DropItemArea dropItemArea;
    [SerializeField] SellItemArea sellItemArea;
    [SerializeField] PromptPopup promptPopup;
    [SerializeField] PromptPopup sellPrompt;
    [SerializeField] PromptPopup buyPrompt;
    [SerializeField] ItemSaveManager itemSaveManager;

    private BaseItemSlots draggedSlot;

    private void OnValidate()
    {
        if (itemTooltips == null)
        {
            itemTooltips = FindObjectOfType<ItemTooltips>();
        }

        if (vendorPrice == null)
        {
            vendorPrice = FindObjectOfType<VendorPrice>();
        }

        if (sellPrice == null)
        {
            sellPrice = FindObjectOfType<ItemSellPrice>();
        }

        if (c == null)
        {
            c = FindObjectOfType<PlayerChar>();
        }

        if (itemSaveManager == null)
        {
            itemSaveManager = FindObjectOfType<ItemSaveManager>();
        }
        
    }
    private void Awake()
    {
        inventory.OnRightClickEvent += InventoryRightClick;
        equipmentMenu.OnRightClickEvent += EquipmentPanelRightClick;
        vendorWindow.OnRightClickEvent += VendorWindowRightClick;

        vendorWindow.OnLeftClickEvent += VendorWindowLeftClick;

        inventory.OnPointerEnterEvent += ShowToolTip;
        equipmentMenu.OnPointerEnterEvent += ShowToolTip;
        enchantingWindow.OnPointerEnterEvent += ShowToolTip;
        vendorWindow.OnPointerEnterEvent += ShowToolTip;

        inventory.OnPointerExitEvent += HideToolTip;
        equipmentMenu.OnPointerExitEvent += HideToolTip;
        enchantingWindow.OnPointerExitEvent += HideToolTip;
        vendorWindow.OnPointerExitEvent += HideToolTip;

        vendorWindow.OnPointerEnterEvent += ShowPrice;
        vendorWindow.OnPointerExitEvent += HidePrice;

        inventory.OnPointerEnterEvent += ShowSalePrice;
        inventory.OnPointerExitEvent += HideSalePrice;

        inventory.OnBeginDragEvent += BeginDrag;
        equipmentMenu.OnBeginDragEvent += BeginDrag;

        inventory.OnEndDragEvent += EndDrag;
        equipmentMenu.OnEndDragEvent += EndDrag;

        inventory.OnDragEvent += Drag;
        equipmentMenu.OnDragEvent += Drag;

        inventory.OnDropEvent += Drop;
        equipmentMenu.OnDropEvent += Drop;

        dropItemArea.OnItemDropEvent += DropItem;
        sellItemArea.OnItemDropEvent += SellItem;

        //itemSaveManager.LoadEquipment(this);
        //itemSaveManager.LoadInventory(this);
    }
    /*
    private void OnDestroy()
    {
        itemSaveManager.SaveEquipment(this);
        itemSaveManager.SaveInventory(this);
    }
    */
    private void VendorWindowLeftClick(BaseItemSlots itemSlots)
    {
        buyPrompt.Show();
        buyPrompt.OnOption1Event += () => BuyItem(itemSlots);
    }

    private void VendorWindowRightClick(BaseItemSlots itemSlots)
    {
        BuyItem(itemSlots);
    }

    private void BuyItem(BaseItemSlots itemSlots)
    {

        if (itemSlots.Item is ConsumableItem)
        {
           
            ConsumableItem consumableItem = (ConsumableItem)itemSlots.Item;
            
            if (GameSavingInformation.crystalsCount >= consumableItem.ItemPrice)
            {

                if (inventory.AddItem(consumableItem))
                {
                    GameSavingInformation.crystalsCount -= consumableItem.ItemPrice;
                }

                else
                {
                    Debug.Log("Inventory is Full");
                }

            }
            else
            {
                Debug.Log("Insufficient Crystals");
            }

        }

        else
        {
            Item item = (Item)itemSlots.Item;

            if (GameSavingInformation.crystalsCount >= item.ItemPrice)
            {
                if (inventory.AddItem(item))
                {
                    vendorWindow.RemoveItem(item);
                    GameSavingInformation.crystalsCount -= item.ItemPrice;
                }
                else
                {
                    Debug.Log("Inventory is Full");
                }
            }

            else
            {
                Debug.Log("Insufficient Crystals");
            }
        }
    }

    private void InventoryRightClick(BaseItemSlots itemSlots)
    {
        if (itemSlots.Item is EquipableItem)
        {
            Equip((EquipableItem)itemSlots.Item);
        }

        else if (itemSlots.Item is ConsumableItem && c.playerCurrentHealth != c.playerMaxHealth)
        {
            ConsumableItem consumableItem = (ConsumableItem)itemSlots.Item;
            consumableItem.Use(c);

            inventory.RemoveItem(consumableItem);
            consumableItem.Destroy();
        }
    }

    private void EquipmentPanelRightClick(BaseItemSlots itemSlots)
    {
        if (itemSlots.Item is EquipableItem)
        {
            Unequip((EquipableItem)itemSlots.Item);
        }
    }

    private void ShowToolTip(BaseItemSlots itemSlots)
    {
        if (itemSlots.Item != null)
        {
            itemTooltips.ShowToolTip(itemSlots.Item);
        }
    }

    private void HideToolTip(BaseItemSlots itemSlots)
    {
        itemTooltips.HideToolTip();
    }

    private void ShowPrice(BaseItemSlots itemSlots)
    {
        if (itemSlots.Item != null)
        {
            vendorPrice.ShowPrice(itemSlots.Item);
        }
    }

    private void HidePrice(BaseItemSlots itemSlots)
    {
        vendorPrice.HidePrice();
    }
    private void ShowSalePrice(BaseItemSlots itemSlots)
    {
        if (itemSlots.Item != null)
        {
            if (vendorWindow.isActiveAndEnabled)
            {
                sellPrice.ShowPrice(itemSlots.Item);
            }  
        }
    }

    private void HideSalePrice(BaseItemSlots itemSlots)
    {
        if (vendorWindow.isActiveAndEnabled)
        {
            sellPrice.HidePrice();
        } 
    }


    private void BeginDrag(BaseItemSlots itemSlots)
    {
        Vector3 mP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mP.z = 0;

        if (itemSlots.Item != null)
        {
            draggedSlot = itemSlots;
            draggableItem.enabled = true;
            draggableItemIcon.sprite = itemSlots.Item.Icon;
            draggableItemIcon.transform.position = mP;
            draggableItemIcon.enabled = true;
        }
    }

    private void EndDrag(BaseItemSlots itemSlots)
    {
        draggedSlot = null;
        draggableItem.enabled = false;
        draggableItemIcon.enabled = false;
        sellItem.SetActive(false);
    }

    private void Drag(BaseItemSlots itemSlots)
    {
       Vector3 mP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       mP.z = 0;
        
        if (draggableItem.enabled)
        {
            draggableItem.transform.position = Input.mousePosition;
            draggableItemIcon.transform.position = mP;
        }
        sellItem.SetActive(true);
    }
    private void Drop(BaseItemSlots dropItemSlots)
    {
        if (draggedSlot == null) return;

        if (dropItemSlots.CanAddStack(draggedSlot.Item))
        {
            AddStacks(dropItemSlots);
        }

        else if (dropItemSlots.CanReceiveItem(draggedSlot.Item) && draggedSlot.CanReceiveItem(dropItemSlots.Item))
        {
            SwapItems(dropItemSlots);
        }
    }

    private void DropItem()
    {
        if (draggedSlot == null) return;

        if (draggedSlot is EquipmentSlots) return;

        if (draggedSlot.Item.isQuestItem) return;

        promptPopup.Show();
        BaseItemSlots baseItemSlots = draggedSlot;
        promptPopup.OnOption1Event += () => DestroyItem(baseItemSlots);
    }

    private void SellItem()
    {

        int crystalCount = GameSavingInformation.crystalsCount;
        if (draggedSlot == null) return;

        if (draggedSlot is EquipmentSlots) return;

        if (draggedSlot.Item.isQuestItem) return;

        sellPrompt.Show();
        sellItem.SetActive(false);
        BaseItemSlots baseItemSlots = draggedSlot;
        crystalCount += baseItemSlots.Item.SellItemPrice;
        sellPrompt.OnOption1Event += () => DestroyItem(baseItemSlots);
        sellPrompt.OnOption1Event += () => GameSavingInformation.crystalsCount = crystalCount;

    }

    private void DestroyItem(BaseItemSlots baseItemSlots)
    {
        baseItemSlots.Item.Destroy();
        baseItemSlots.Item = null;
    }
    private void SwapItems(BaseItemSlots dropItemSlots)
    {
        EquipableItem dragItem = draggedSlot.Item as EquipableItem;
        EquipableItem dropItem = dropItemSlots.Item as EquipableItem;

        if (dropItemSlots is EquipmentSlots)
        {
            if (dragItem != null)
            {
                equipmentMenu.EnableEmptyIcon(dragItem.ItemType);
                dragItem.Equip(c);
            }
            if (dropItem != null)
            {
                dropItem.Unequip(c);
                equipmentMenu.EnableEmptyIcon(dropItem.ItemType);
            }
        }

        if (draggedSlot is EquipmentSlots)
        {
            if (dragItem != null)
            {
                dragItem.Unequip(c);
                equipmentMenu.DisableEmptyIcon(dragItem.ItemType);
            }

            if (dropItem != null)
            {
                dropItem.Equip(c);
                equipmentMenu.EnableEmptyIcon(dropItem.ItemType);
            }
        }

        Item draggedItem = draggedSlot.Item;
        int draggedItemAmount = draggedSlot.Amount;

        draggedSlot.Item = dropItemSlots.Item;
        draggedSlot.Amount = dropItemSlots.Amount;

        dropItemSlots.Item = draggedItem;
        dropItemSlots.Amount = draggedItemAmount;
    }

    private void AddStacks(BaseItemSlots dropItemSlots)
    {
        int addableStacks = dropItemSlots.Item.MaxStacks - dropItemSlots.Amount;
        int stacksToAdd = Mathf.Min(addableStacks, draggedSlot.Amount);

        dropItemSlots.Amount += stacksToAdd;
        draggedSlot.Amount -= stacksToAdd;
    }

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
        if (inventory.CanAddItem(item) && equipmentMenu.RemoveItem(item))
        {
            inventory.AddItem(item);
            item.Unequip(c); 
        }
    }

    public void Clear(EquipableItem item)
    {
        item.Unequip(c);
        equipmentMenu.RemoveItem(item);
        
        
        
    }
}
