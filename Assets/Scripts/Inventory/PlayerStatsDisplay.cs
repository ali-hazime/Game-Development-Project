using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsDisplay : MonoBehaviour
{
    [SerializeField] PlayerChar p;

    [SerializeField] Text pAttackDamage;
    [SerializeField] Text pAbilityPower;
    [SerializeField] Text pAttackSpeed;
    [SerializeField] Text pMovementSpeed;
    [SerializeField] Text pHealth;
    [SerializeField] Text pArmour;

    void Update()
    {
        pAttackDamage.text = " " + p.playerAttackDamage;

        pAbilityPower.text = " " + p.playerAbilityPower;

        pAttackSpeed.text = " " + Mathf.Round(p.playerAttackSpeed * 100f) / 100f;

        pMovementSpeed.text = " " + Mathf.Round(p.playerMovementSpeed * 100f) / 100f;

        pHealth.text = " " + p.playerMaxHealth;

        pArmour.text = " " + p.playerArmour;
    }
}
