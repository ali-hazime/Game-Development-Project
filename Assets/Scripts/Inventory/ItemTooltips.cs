using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ItemTooltips : MonoBehaviour
{
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ItemTypeText;
    [SerializeField] Text ItemStatsText;

    private StringBuilder sb = new StringBuilder();
    public void ShowToolTip(EquipableItem item)
    {
        ItemNameText.text = item.ItemName;
        ItemTypeText.text = item.ItemType.ToString();

        sb.Length = 0;

        TooltipStat(item.bonusAttackDamage, "Attack Damage");
        TooltipStat(item.bonusAbilityPower, "Ability Power");
        TooltipStat(item.bonusAttackSpeed, "Attack Speed");
        TooltipStat(item.bonusMovementSpeed, "Movement Speed");
        TooltipStat(item.bonusHealth, "Health");
        TooltipStat(item.bonusArmour, "Armour");

        ItemStatsText.text = sb.ToString();

        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
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
}
