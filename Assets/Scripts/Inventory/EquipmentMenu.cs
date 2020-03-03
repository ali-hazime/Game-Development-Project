using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentMenu : MonoBehaviour
{
    public EquipmentSlots[] equipmentSlots;
    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] Image helmImage;
    [SerializeField] Image wepImage;
    [SerializeField] Image shieldImage;
    [SerializeField] Image bootsImage;
    [SerializeField] Image bodyImage;

    public event Action<BaseItemSlots> OnBeginDragEvent;
    public event Action<BaseItemSlots> OnEndDragEvent;
    public event Action<BaseItemSlots> OnDragEvent;
    public event Action<BaseItemSlots> OnDropEvent;
    public event Action<BaseItemSlots> OnPointerEnterEvent;
    public event Action<BaseItemSlots> OnPointerExitEvent;
    public event Action<BaseItemSlots> OnRightClickEvent;
   

    private void Awake()
    {
        for (int i=0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
            equipmentSlots[i].OnEndDragEvent += slot => OnEndDragEvent(slot);
            equipmentSlots[i].OnDragEvent += slot => OnDragEvent(slot);
            equipmentSlots[i].OnDropEvent += slot => OnDropEvent(slot);
            equipmentSlots[i].OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
            equipmentSlots[i].OnPointerExitEvent += slot => OnPointerExitEvent(slot);
            equipmentSlots[i].OnRightClickEvent += slot => OnRightClickEvent(slot);
        }
    }
    private void OnValidate()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlots>();
    }

    public bool AddItem(EquipableItem item, out EquipableItem previousItem)
    {
        for (int i=0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].EquipmentType == item.ItemType)
            {
                previousItem = (EquipableItem)equipmentSlots[i].Item;
                equipmentSlots[i].Item = item;
                equipmentSlots[i].Amount = 1;
                EnableEmptyIcon(equipmentSlots[i].EquipmentType);
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquipableItem item)
    {
        int i = 0;
        for (; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == item)
            {
                equipmentSlots[i].Item = null;
                equipmentSlots[i].Amount = 0;
                DisableEmptyIcon(equipmentSlots[i].EquipmentType);
                return true;
            }
        }
        return false;
    }

    public void EnableEmptyIcon(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Helmet:
                helmImage.enabled = true;
                break;
            case ItemType.BodyArmour:
                bodyImage.enabled = true;
                break;
            case ItemType.Boots:
                bootsImage.enabled = true;
                break;
            case ItemType.Shield:
                shieldImage.enabled = true;
                break;
            case ItemType.Weapon:
                wepImage.enabled = true;
                break;
        }
    }

    public void DisableEmptyIcon(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Helmet:
                helmImage.enabled = false;
                break;
            case ItemType.BodyArmour:
                bodyImage.enabled = false;
                break;
            case ItemType.Boots:
                bootsImage.enabled = false;
                break;
            case ItemType.Shield:
                shieldImage.enabled = false;
                break;
            case ItemType.Weapon:
                wepImage.enabled = false;
                break;
        }
    }
}
