using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Inventory inventory;
    [SerializeField] CurrencyManager currencyManagerScript;
    public bool isQuestOnlyItem = false;
    public bool isCurrency = false;
    public bool isCollectEquipItem = false;
    public ItemDropScript itemDropScript;
    public CollectObjective collectObjective;
    public bool inRange;


    public int currencyDrop;


    public void Start()
    {
        if (inventory == null && !isQuestOnlyItem && !isCurrency)
        {
            inventory = FindObjectOfType<Inventory>();
        }

        if (currencyManagerScript == null)
        {
            currencyManagerScript = FindObjectOfType<CurrencyManager>();
        }

    }
    void Update()
    {

        if (inRange && !isQuestOnlyItem && !isCurrency)
        {
            if (inventory.AddItem(item.GetCopy()))
            {
                CheckItem();
                Destroy(this.gameObject);
            }
        }
    }

    void CheckItem()
    {
        if (item.ItemName == ("Health Potion"))
        {
            // use this for picking up ice crown bool that will allow player to enter volcano
            Debug.Log("You picked up a Health potion!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
        
        if (isQuestOnlyItem)
        {
            if (other.CompareTag("Player"))
            {
                collectObjective.UpdateItemCount();
                Destroy(this.gameObject);
            }
        }

        if (isCurrency)
        {
            if (other.CompareTag("Player"))
            {
                currencyDrop = Random.Range(GameSavingInformation.minCurrency, GameSavingInformation.maxCurrency);
                currencyManagerScript.AddCurrency(currencyDrop);
                Destroy(this.gameObject);
            }
        }

        if (isCollectEquipItem)
        {
            if (other.CompareTag("Player"))
            {
                collectObjective.UpdateItemCount();
            }
        }
    }
}
