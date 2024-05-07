using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set;}
    private List<string> inventory = new List<string>();

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Theres more than wan Inventory Instace");
        }
        Instance = this;
    }
   
    public List<string> GetInventory()
    {
        return inventory;
    }

    public bool IsItemInInventory(string item)
    {
        return inventory.Contains(item);
    }

    public void AddItemToInventory(string item)
    {
        inventory.Add(item);
    }
}
