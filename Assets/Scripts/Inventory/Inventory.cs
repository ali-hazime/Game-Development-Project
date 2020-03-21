using System;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : ItemContainer
{
    [SerializeField] protected Item[] startingItems;
    [SerializeField] protected Transform itemsParent;

    public event Action<BaseItemSlots> OnBeginDragEvent;
    public event Action<BaseItemSlots> OnEndDragEvent;
    public event Action<BaseItemSlots> OnDragEvent;
    public event Action<BaseItemSlots> OnDropEvent;
    public event Action<BaseItemSlots> OnPointerEnterEvent;
    public event Action<BaseItemSlots> OnPointerExitEvent;
    public event Action<BaseItemSlots> OnRightClickEvent;
    

    private void Awake()
    {
        for (int i=0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
            itemSlots[i].OnEndDragEvent += slot => OnEndDragEvent(slot);
            itemSlots[i].OnDragEvent += slot => OnDragEvent(slot);
            itemSlots[i].OnDropEvent += slot => OnDropEvent(slot);
            itemSlots[i].OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
            itemSlots[i].OnPointerExitEvent += slot => OnPointerExitEvent(slot);
            itemSlots[i].OnRightClickEvent += slot => OnRightClickEvent(slot);
            
        }

        //SetStartingItems();
    }
    private void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlots>();

        Clear();
        //SetStartingItems();
    }

    /*
    private void SetStartingItems()
    {
        Clear();
        foreach (Item item in startingItems)
        {
            AddItem(item.GetCopy());
        }
    }*/


}
