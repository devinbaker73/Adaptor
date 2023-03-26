using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientAdaptor : MonoBehaviour
{
    public InventoryItem item;
    public InventoryItem[] items;

    private InventorySystem inventorySystem;
    private IInventorySystem inventorySystemAdaptor;

    private void Start()
    {
        inventorySystem = new InventorySystem();
        inventorySystemAdaptor = new InventorySystemAdapter();
        items = Resources.LoadAll<InventoryItem>("");
        GetRandomItem();
    }

    private InventoryItem GetRandomItem()
    {
        return items[Random.Range(0, 3)];
    }

    private void OnGUI()
    {
        if(GUILayout.Button("Add item (no adaptor)"))
        {
            inventorySystem.AddItem(item);
            item = GetRandomItem();
        }
        if (GUILayout.Button("Add item (with adaptor)"))
        {
            inventorySystemAdaptor.AddItem(item, SaveLocation.Both);
            item = GetRandomItem();
        }
    }
}
