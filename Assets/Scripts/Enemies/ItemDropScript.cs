using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropScript : MonoBehaviour
{ 
    public GameObject[] listOfItems;
    public GameObject[] listOfRareItems;
    public GameObject[] listOfLegendaryItems;
    public GameObject[] listOfGems;
    public GameObject currencyObject;

    private int itemToDrop;
    private int rareItemToDrop;
    private int legendaryItemToDrop;
    //private int gemToDrop;
    private int dropChanceRange;
    private int rareDropChanceRange;
    private int legendaryDropChanceRange;
    private int currencyDropChanceRange;
    private int gemDropChanceRange;
    private int rareGemDropChanceRange;
    [Space]
    public float dropChance = 20;
    public float legendaryItemDropChance = 5;
    public float rareItemDropChance = 15;
    [Space]
    public float currencyDropChance = 40;
    [Space]
    public float gemDropChance = 10;
    public float rareGemDropChance = 5;
    [Space]
    public GameObject currency;
    public GameObject item;
    public GameObject gem;




    public void DropItem(bool dropItem)
    {
        if (dropItem)
        {
            // gem drop 
            gemDropChanceRange = Random.Range(0, 100);

            if (gemDropChanceRange <= gemDropChance)
            {
                GemDropRoll();
            }

            // currency drop
            currencyDropChanceRange = Random.Range(0, 100); 

            if (currencyDropChanceRange <= currencyDropChance)
            {
                currency = Instantiate(currencyObject, gameObject.transform.position + new Vector3(-0.5f,0.5f,0), gameObject.transform.rotation); 
            }
            
            // item drop
            dropChanceRange = Random.Range(0, 100);

            if (dropChanceRange <= (GameSavingInformation.dropChanceModifier + dropChance))
            {
                ItemDropRoll();
            }
        } 
    }

    public void ItemDropRoll()
    {
        legendaryDropChanceRange = Random.Range(1, 100);
        rareDropChanceRange = Random.Range(1, 100);
        itemToDrop = Random.Range(0, listOfItems.Length);
        rareItemToDrop = Random.Range(0, listOfRareItems.Length);
        legendaryItemToDrop = Random.Range(0, listOfLegendaryItems.Length);

        if (legendaryDropChanceRange <= legendaryItemDropChance)
        {
            item = Instantiate(listOfLegendaryItems[legendaryItemToDrop], gameObject.transform.position, gameObject.transform.rotation);
        }
        else if (rareDropChanceRange <= rareItemDropChance)
        {
            item = Instantiate(listOfRareItems[rareItemToDrop], gameObject.transform.position, gameObject.transform.rotation);
        }
        else
        {
            item = Instantiate(listOfItems[itemToDrop], gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    public void GemDropRoll()
    {
        rareGemDropChanceRange = Random.Range(0, 100);

        if (rareGemDropChanceRange <= rareGemDropChance)
        {
            gem = Instantiate(listOfGems[1], gameObject.transform.position + new Vector3(0.5f, -0.5f, 0), gameObject.transform.rotation);
        }
        else
        {
            gem = Instantiate(listOfGems[0], gameObject.transform.position + new Vector3(0.5f, -0.5f, 0), gameObject.transform.rotation);
        }

    }
}
