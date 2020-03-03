using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropScript : MonoBehaviour
{ 
    public GameObject[] listOfItems;
    public GameObject[] listOfRareItems;
    public int itemToDrop;
    public int rareItemToDrop;
    private int dropChanceRange;
    private int rareDropChanceRange;
    private int currencyDropChanceRange;
    public GameObject item;
    [Space]
    public float dropChance = 20;
    public float rareItemDropChance = 5;
    public float currencyDropChance = 40;
    [Space]
    public GameObject currency;
    public GameObject currencyObject;
    

    public void DropItem(bool dropItem)
    {
        if (dropItem)
        {
            

            currencyDropChanceRange = Random.Range(0, 100); 

            if (currencyDropChanceRange <= currencyDropChance)
            {
                currency = Instantiate(currencyObject, gameObject.transform.position * 1, gameObject.transform.rotation); 
            }

            dropChanceRange = Random.Range(0, 100);

            if (dropChanceRange <= (GameSavingInformation.dropChanceModifier + dropChance))
            {
                ItemDropRoll();
            }

        } 
    }

    public void ItemDropRoll()
    {
        rareDropChanceRange = Random.Range(0, 100);
        itemToDrop = Random.Range(0, listOfItems.Length);
        rareItemToDrop = Random.Range(0, listOfRareItems.Length);

        if (rareDropChanceRange <= rareItemDropChance)
        {
            item = Instantiate(listOfRareItems[rareItemToDrop], gameObject.transform.position, gameObject.transform.rotation);
        }
        else
        {
            item = Instantiate(listOfItems[itemToDrop], gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
