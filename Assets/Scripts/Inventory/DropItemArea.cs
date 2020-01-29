using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItemArea : MonoBehaviour, IDropHandler
{
    public event Action OnItemDropEvent;
    public void OnDrop(PointerEventData eventData)
    {
        if (OnItemDropEvent != null)
        {
            OnItemDropEvent();
        }
    }
}
