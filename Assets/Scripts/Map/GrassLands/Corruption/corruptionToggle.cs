using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corruptionToggle : MonoBehaviour
{
    // Start is called before the first frame update

    public bool corruption = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (corruption == false)
        {
            gameObject.SetActive(false);
        }
        if (corruption == true)
        {
            gameObject.SetActive(true);
        }
    }
}
