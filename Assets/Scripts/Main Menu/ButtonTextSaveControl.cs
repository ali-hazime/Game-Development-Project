using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextSaveControl : MonoBehaviour
{
    Text textInfo;
    // Start is called before the first frame update
    void Start()
    {
        textInfo = GetComponent<Text>();

        //Check if new game or not
        checkNew();
    }

    void checkNew()
    {
        //Will be uncommented when save is completed
        /*
        if (SAVED is TRUE)
        {
            textInfo.text = "CONTINUE";
        }
        else
        {
            textInfo.text = "NEW GAME";
        }
        */
    }

    
}
