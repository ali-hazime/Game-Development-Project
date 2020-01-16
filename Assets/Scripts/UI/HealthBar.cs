using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public PlayerChar pc;
    public GameObject healthBar;
    public Text healthNumber;

    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scale = (float)pc.playerCurrentHealth / (float)pc.playerMaxHealth;
        transform.localScale = new Vector3(scale, 1, 1);
        healthNumber.text = Mathf.Round(scale*100)  + "%";
    }
}
