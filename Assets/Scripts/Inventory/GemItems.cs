using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GemItems : Item
{
    private void TooltipStat(string desc1)
    {
           sb.Append(desc1);
    }

    private void ItemDesc(string itemDesc)
    {
        sb.Append(itemDesc);
    }

    public override string GetItemType()
    {
        sb.Length = 0;

        ItemDesc("Gemstone");
        return sb.ToString();
    }

    public override string GetStats()
    {
        sb.Length = 0;

        TooltipStat("A rare gemstone\nthat appears to have\nsome magical properties.");

        return sb.ToString();
    }
}

