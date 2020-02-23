using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : ItemContainer
{
    [SerializeField] protected Item[] startingItems;
    [SerializeField] protected Transform itemsParent;

    public event Action<BaseItemSlots> OnPointerEnterEvent;
    public event Action<BaseItemSlots> OnPointerExitEvent;
    public event Action<BaseItemSlots> OnRightClickEvent;
    public event Action<BaseItemSlots> OnLeftClickEvent;



    private void Awake()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
            itemSlots[i].OnPointerExitEvent += slot => OnPointerExitEvent(slot);
            itemSlots[i].OnRightClickEvent += slot => OnRightClickEvent(slot);
            itemSlots[i].OnLeftClickEvent += slot => OnLeftClickEvent(slot);
        }

        SetStartingItems();
    }
    private void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlots>();

        SetStartingItems();
    }

    private void SetStartingItems()
    {
        Clear();
        foreach (Item item in startingItems)
        {
            AddItem(item.GetCopy());
        }
    }
}
