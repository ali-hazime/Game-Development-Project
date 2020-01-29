using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BaseItemSlots : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected Image image;
    [SerializeField] protected Text stackAmountText;

    public event Action<BaseItemSlots> OnPointerEnterEvent;
    public event Action<BaseItemSlots> OnPointerExitEvent;
    public event Action<BaseItemSlots> OnRightClickEvent;

    protected Color normalColor = Color.white;
    protected Color disabledColor = new Color(1, 1, 1, 0);

    protected bool isPointerOver;

    protected Item itemImg;

    public Item Item
    {
        get
        {
            return itemImg;
        }

        set
        {
            itemImg = value;

            if (itemImg == null && Amount != 0) Amount = 0;

            if (itemImg == null)
            {
                image.color = disabledColor;
            }
            else
            {
                image.sprite = itemImg.Icon;
                image.color = normalColor;
            }

            if (isPointerOver)
            {
                OnPointerExit(null);
                OnPointerEnter(null);
            }
        }
    }

    private int amnt;
    public int Amount
    {
        get { return amnt; }
        set
        {
            amnt = value;
            if (amnt < 0) amnt = 0;
            if (amnt == 0 && Item != null) Item = null;

            if (stackAmountText != null)
            {
                stackAmountText.enabled = itemImg != null && amnt > 1;
                if (stackAmountText.enabled)
                {
                    stackAmountText.text = amnt.ToString();
                }
            }
        }
    }

    protected virtual void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }

        if (stackAmountText == null)
        {
            stackAmountText = GetComponentInChildren<Text>();
        }
    }

    public virtual bool CanAddStack(Item item, int amount = 1)
    {
        return Item != null && Item.ID ==  item.ID;
    }
    public virtual bool CanReceiveItem(Item item)
    {
        return false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (OnRightClickEvent != null)
            {
                OnRightClickEvent(this);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;
        if(OnPointerEnterEvent != null)
        {
            OnPointerEnterEvent(this);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
        if (OnPointerExitEvent != null)
        {
            OnPointerExitEvent(this);
        }
    }
}
