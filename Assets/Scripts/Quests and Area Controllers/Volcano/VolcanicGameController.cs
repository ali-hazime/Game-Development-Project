using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanicGameController : MonoBehaviour
{
    [SerializeField] GameObject Sapphire5;
    // Start is called before the first frame update
    void Start()
    {
        if (GameSavingInformation.sapphire5Collected)
        {
            Sapphire5.SetActive(false);
        }
        else
        {
            Sapphire5.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
