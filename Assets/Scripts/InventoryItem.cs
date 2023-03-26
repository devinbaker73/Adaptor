using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "new Item", menuName = "Inventory")]
[System.Serializable]
public class InventoryItem : ScriptableObject
{
    //placeholder class to flesh out for assignment
    //can change to monster, npc or anything in game
    [SerializeField]
    public string itemName;
}
