using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlots : BaseItemSlots, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
{
    public event Action<BaseItemSlots> OnBeginDragEvent;
    public event Action<BaseItemSlots> OnEndDragEvent;
    public event Action<BaseItemSlots> OnDragEvent;
    public event Action<BaseItemSlots> OnDropEvent;

    private Color dragColor = new Color(1, 1, 1, 0.5f);

    public override bool CanAddStack(Item item, int amount = 1)
    {
        return base.CanAddStack(item, amount) && Amount + amount <= item.MaxStacks;
    }

    public override bool CanReceiveItem(Item item)
    {
        return true;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Item != null)
        {
            image.color = dragColor;
        }

        if (OnBeginDragEvent != null)
        {
            OnBeginDragEvent(this);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragEvent != null)
        {
            OnDragEvent(this);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Item != null)
        {
            image.color = normalColor;
        }

        if (OnEndDragEvent != null)
        {
            OnEndDragEvent(this);
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null)
        {
            OnDropEvent(this);
        }
    }
}
