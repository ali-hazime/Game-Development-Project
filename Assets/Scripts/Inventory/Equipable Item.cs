using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Helmet,
    BodyArmour,
    Boots,
    Weapon, 
    Shield
}

[CreateAssetMenu]
public class EquipableItem : Item
{
    public int bonusAttackDamage;
    public int bonusAbilityPower;
    public float bonusAttackSpeed;
    public float bonusMovementSpeed;
    public int bonusHealth;
    public int bonusArmour;
    [Space]
    public ItemType ItemType;
    public bool isSword;
    public bool isStaff;

    public void Equip(PlayerChar p)
    {
        if (bonusAttackDamage != 0)
        {
            p.playerAttackDamage += bonusAttackDamage;
        }

        if (bonusAbilityPower != 0)
        {
            p.playerAbilityPower += bonusAbilityPower;
        }

        if (bonusAttackSpeed != 0)
        {
            p.playerAttackSpeed += bonusAttackSpeed;
        }

        if (bonusMovementSpeed != 0)
        {
            p.playerMovementSpeed += bonusMovementSpeed;
        }

        if (bonusHealth != 0)
        {
            p.playerMaxHealth += bonusHealth;
        }

        if (bonusArmour != 0)
        {
            p.playerArmour += bonusArmour;
        }

        if (isSword)
        {
            p.swordEquipped = true;
            p.staffEquipped = false;
        }

        if (isStaff)
        {
            p.swordEquipped = false;
            p.staffEquipped = true;
        }
    }

    public void Unequip(PlayerChar p)
    {
        p.playerAttackDamage -= bonusAttackDamage;
        p.playerAbilityPower -= bonusAbilityPower;
        p.playerAttackSpeed -= bonusAttackSpeed;
        p.playerMovementSpeed -= bonusMovementSpeed;
        p.playerMaxHealth -= bonusHealth;
        p.playerArmour -= bonusArmour;

        if (isSword)
        {
            p.swordEquipped = false;
        }

        if (isStaff)
        {
            p.staffEquipped = false;
        }
        
    }
}