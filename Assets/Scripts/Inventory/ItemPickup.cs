using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Inventory inventory;

    public bool inRange;
    public Inventory i;

    void Update()
    {
        if (inRange)
        {
            if (inventory.AddItem(item))
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }        
    }
}
