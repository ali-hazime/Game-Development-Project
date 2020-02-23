using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Inventory inventory;

    public bool inRange;
    //public Inventory i;

    public void Awake()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
        }

    }
    void Update()
    {
        if (inRange)
        {
            if (inventory.AddItem(item.GetCopy()))
            {
                Destroy(this.gameObject);
            }
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
    }
}
