using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfContinue : MonoBehaviour
{
    public Button contButton;
    // Start is called before the first frame update
    void Start()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/playerData.game"))
        {
            contButton.interactable = true;
        }
        else
        {
            contButton.interactable = false;
        }
    }
}
