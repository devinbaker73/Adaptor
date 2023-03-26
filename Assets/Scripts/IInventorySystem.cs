using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventorySystem
{
    void SyncInventories();

    void AddItem(InventoryItem anItem, SaveLocation aLocation);

    void RemoveItem(InventoryItem anItem, SaveLocation aLocation);

    List<InventoryItem> GetInventory(SaveLocation aLocation);
}
