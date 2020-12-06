using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDifficulty : MonoBehaviour
{
    public int statBoost;
    [SerializeField] Dropdown dropdown;

    private void Awake()
    {
        if (dropdown == null)
        {
            dropdown = FindObjectOfType<Dropdown>();
        }

        statBoost = 4;
    }
    public void ChooseDifficulty()
    {
        if (dropdown.value == 0)
        {
            statBoost = 4;
        }

        if (dropdown.value == 1)
        {
            statBoost = 2;
        }

        if (dropdown.value == 2)
        {
            statBoost = 1;
        }

        if (dropdown.value == 3)
        {
            statBoost = 0;
        }
    }
}
