using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptPopup : MonoBehaviour
{
    public event Action OnOption1Event;
    public event Action OnOption2Event;
    
    public void Show()
    {
        gameObject.SetActive(true);
        OnOption1Event = null;
        OnOption2Event = null;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void OnOption1ButtonClick()
    {
        if (OnOption1Event != null)
        {
            OnOption1Event();
        }

        Hide();
    }

    public void OnOption2ButtonClick()
    {
        if (OnOption2Event != null)
        {
            OnOption2Event();
        }

        Hide();
    }
}
