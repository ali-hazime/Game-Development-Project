using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentMenu : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotsParent;
    public EquipmentSlots[] equipmentSlots;

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
                return true;
            }
        }
        return false;
    }
}
