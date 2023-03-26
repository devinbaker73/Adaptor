using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using UnityEngine;

public class InventorySystemAdapter : InventorySystem, IInventorySystem
{
    private string fileName = "SaveData.txt";
    private List<InventoryItem> localItems = new List<InventoryItem>();
    public void AddItem(InventoryItem anItem, SaveLocation aLocation)
    {
        if(aLocation == SaveLocation.Cloud)
        {
            AddItem(anItem);
        }
        else if(aLocation == SaveLocation.Local)
        {
            Load();
            localItems.Add(anItem);
            Save();
        }
        else if (aLocation == SaveLocation.Both)
        {
            AddItem(anItem);
            Load();
            localItems.Add(anItem);
            Save();
        }
    }

    public List<InventoryItem> GetInventory(SaveLocation aLocation)
    {
        if (aLocation == SaveLocation.Cloud)
        {
            return GetInventory();
        }
        else if (aLocation == SaveLocation.Local)
        {
            //save csv or json
            Debug.Log("We need code here to get items from the local drive");
        }
        else if (aLocation == SaveLocation.Both)
        {
            GetInventory();
            //save csv or json
            Debug.Log("We need code here to get items from the local drive");
        }
        //fake return statement
        //fix for assignment
        return new List<InventoryItem>();
    }

    public void RemoveItem(InventoryItem anItem, SaveLocation aLocation)
    {
        if (aLocation == SaveLocation.Cloud)
        {
            RemoveItem(anItem);
        }
        else if (aLocation == SaveLocation.Local)
        {
            Debug.Log("We need code here to remove from the local drive");
        }
        else if (aLocation == SaveLocation.Both)
        {
            RemoveItem(anItem);
            Debug.Log("We need code here to remove from the local drive");
        }
    }

    public void SyncInventories()
    {
        var cloudInventory = GetInventory();
        Debug.Log("Downloading the cloud inventory");
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(GetInventory());
    }

    private void Load()
    {
        string path = Application.persistentDataPath + "/" + fileName;
        if(File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                JsonUtility.FromJsonOverwrite(json, localItems);
            }
        }
    }
}
