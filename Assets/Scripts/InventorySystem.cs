using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem
{
    private List<InventoryItem> cloudInventory = new List<InventoryItem>();
    public void AddItem(InventoryItem anItem)
    {
        cloudInventory.Add(anItem);
    }

    public void RemoveItem(InventoryItem anItem)
    {
        cloudInventory.Remove(anItem);
    }

    public List<InventoryItem> GetInventory()
    {

        return cloudInventory;
    }
}
