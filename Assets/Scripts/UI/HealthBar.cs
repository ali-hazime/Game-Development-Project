using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private PlayerChar pc;
    public GameObject healthBar;
    public Text healthNumber;

    public Slider slider;
    public Gradient gradient;
    public Image healthFill;

    void Start()
    {
        pc = FindObjectOfType<PlayerChar>();
        gradient.Evaluate(pc.playerCurrentHealth);
    }

    void Update()
    {
        slider.maxValue = pc.playerMaxHealth;
        slider.value = pc.playerCurrentHealth;
        healthFill.color = gradient.Evaluate(slider.normalizedValue);

        //For Health Numbers
        healthNumber.text = pc.playerCurrentHealth + "/" + pc.playerMaxHealth;
        if (pc.playerCurrentHealth <= 0)
        {
            healthNumber.text = "0";
        }  
    }
}
