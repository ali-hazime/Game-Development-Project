using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCanvas : MonoBehaviour
{
    void Awake()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().interactable = false;
        DontDestroyOnLoad(this.gameObject); 
    }

    void Update()
    {
        if (this.gameObject.GetComponent<Canvas>().worldCamera == null)
        {
            this.gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
        }
    }
}
