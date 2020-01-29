using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public PlayerChar c;

    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentMenu equipmentMenu;
    [SerializeField] EnchantingWindow enchantingWindow;
    [SerializeField] ItemTooltips itemTooltips;
    [SerializeField] Image draggableItem;
    [SerializeField] Image draggableItemIcon;
    [SerializeField] DropItemArea dropItemArea;
    [SerializeField] PromptPopup promptPopup;

    private BaseItemSlots draggedSlot;

    private void OnValidate()
    {
        if (itemTooltips == null)
        {
            itemTooltips = FindObjectOfType<ItemTooltips>();
        }
    }
    private void Awake()
    {
        inventory.OnRightClickEvent += InventoryRightClick;
        equipmentMenu.OnRightClickEvent += EquipmentPanelRightClick;

        inventory.OnPointerEnterEvent += ShowToolTip;
        equipmentMenu.OnPointerEnterEvent += ShowToolTip;
        enchantingWindow.OnPointerEnterEvent += ShowToolTip;

        inventory.OnPointerExitEvent += HideToolTip;
        equipmentMenu.OnPointerExitEvent += HideToolTip;
        enchantingWindow.OnPointerExitEvent += HideToolTip;

        inventory.OnBeginDragEvent += BeginDrag;
        equipmentMenu.OnBeginDragEvent += BeginDrag;

        inventory.OnEndDragEvent += EndDrag;
        equipmentMenu.OnEndDragEvent += EndDrag;

        inventory.OnDragEvent += Drag;
        equipmentMenu.OnDragEvent += Drag;

        inventory.OnDropEvent += Drop;
        equipmentMenu.OnDropEvent += Drop;

        dropItemArea.OnItemDropEvent += DropItem;
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

        promptPopup.Show();
        BaseItemSlots baseItemSlots = draggedSlot;
        promptPopup.OnOption1Event += () => DestroyItem(baseItemSlots);

        
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
            if (dragItem != null) dragItem.Equip(c);
            if (dropItem != null) dropItem.Unequip(c);
        }

        if (draggedSlot is EquipmentSlots)
        {
            if (dragItem != null) dragItem.Unequip(c);
            if (dropItem != null) dropItem.Equip(c);
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
}
