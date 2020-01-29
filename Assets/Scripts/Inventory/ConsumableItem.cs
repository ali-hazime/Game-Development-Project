using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ConsumableItem : Item
{
    public int restoreHealth;

    public void Use(PlayerChar p)
    {
        p.playerCurrentHealth += restoreHealth;
    }

    private void TooltipStat(float statValue, string desc1, string desc2)
    {
        if (statValue != 0)
        {
            sb.Append(desc1);
            sb.Append(" ");
            sb.Append(statValue);
            sb.Append(" ");
            sb.Append(desc2);
        }
    }

    private void ItemDesc(string itemDesc)
    {
        sb.Append(itemDesc);
    }

    public override string GetItemType()
    {
        sb.Length = 0;

        ItemDesc("Healing Potion");
        return sb.ToString();
    }

    public override string GetStats()
    {
        sb.Length = 0;

        TooltipStat(restoreHealth, "Restore", "Health");

        return sb.ToString();
    }
}
