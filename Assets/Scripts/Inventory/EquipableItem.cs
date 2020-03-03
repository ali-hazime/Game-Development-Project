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
    [Space]
    public float bonusMagicFind;

    public override Item GetCopy()
    {
        return Instantiate(this);
    }

    public override void Destroy()
    {
        Destroy(this);
    }
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
            p.playerMovementSpeed *= (1 + bonusMovementSpeed);
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

        if (bonusMagicFind != 0)
        {
            p.playerMagicFind += bonusMagicFind;
            GameSavingInformation.dropChanceModifier += bonusMagicFind;
        }
    }

    public void Unequip(PlayerChar p)
    {
        p.playerAttackDamage -= bonusAttackDamage;
        p.playerAbilityPower -= bonusAbilityPower;
        p.playerAttackSpeed -= bonusAttackSpeed;
        p.playerMovementSpeed /= (1 + bonusMovementSpeed);
        p.playerMaxHealth -= bonusHealth;
        p.playerArmour -= bonusArmour;
        p.playerMagicFind -= bonusMagicFind;
        GameSavingInformation.dropChanceModifier -= bonusMagicFind;

        if (isSword)
        {
            p.swordEquipped = false;
        }

        if (isStaff)
        {
            p.staffEquipped = false;
        }
        
    }
    private void TooltipStat(float statValue, string statName)
    {
        if (statValue != 0)
        {
            if (sb.Length > 0)
            {
                sb.AppendLine();
            }

            if (statValue < 1)
            {
                sb.Append("+");
                sb.Append(Mathf.Round(statValue * 100));
                sb.Append("% ");
                sb.Append(statName);
            }
            else
            {
                sb.Append("+");
                sb.Append(statValue);
                sb.Append(" ");
                sb.Append(statName);
            }
        }
    }

    public override string GetItemType()
    {
        return ItemType.ToString();
    }

    public override string GetStats()
    {
        sb.Length = 0;

        TooltipStat(bonusAttackDamage, "Attack Damage");
        TooltipStat(bonusAbilityPower, "Ability Power");
        TooltipStat(bonusAttackSpeed, "Attack Speed");
        TooltipStat(bonusMovementSpeed, "Movement Speed");
        TooltipStat(bonusHealth, "Health");
        TooltipStat(bonusArmour, "Armour");
        TooltipStat(bonusMagicFind, "Magic Find");

        return sb.ToString();
    }

}