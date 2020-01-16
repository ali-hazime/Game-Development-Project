using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlots : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image image;
    [SerializeField] ItemTooltips tooltip;

    private Item itemImg;
    public Item Item
    {
        get
        {
            return itemImg;
        }

        set
        {
            itemImg = value;

            if (itemImg == null)
            {
                image.enabled = false;
            } else
            {
                image.sprite = itemImg.Icon;
                image.enabled = true;
            }
        }
    }

    public event Action<Item> OnRightClickEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (Item != null && OnRightClickEvent != null)
            {
                OnRightClickEvent(Item);
            }

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Item is EquipableItem)
        {
            tooltip.ShowToolTip((EquipableItem)Item);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideToolTip();
    }

    protected virtual void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
            

        if (tooltip == null)
        {
            tooltip = FindObjectOfType<ItemTooltips>();
        }
    }
}
