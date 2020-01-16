using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    Text flashingText;

    void Start()
    {
        
        flashingText = GetComponent<Text>();
        
        StartCoroutine(BlinkText());
    }

    //function to blink the text 
    public IEnumerator BlinkText()
    {
        
        while (true)
        {
            
            flashingText.text = "";
           
            yield return new WaitForSeconds(.5f);
            
            flashingText.text = "START GAME";
            yield return new WaitForSeconds(.5f);
        }
    }
}
