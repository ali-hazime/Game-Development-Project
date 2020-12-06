using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMainMenu : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
