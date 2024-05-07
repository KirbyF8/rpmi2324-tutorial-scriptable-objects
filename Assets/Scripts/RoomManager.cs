using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
   
    public static RoomManager Instance { get; private set; }

    public RoomSO currentRoom;

    private Dictionary<string, RoomSO> exitsDictionary = new Dictionary<string, RoomSO>();
    
    private Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    private Dictionary<string, string> takeDictionary = new Dictionary<string, string>();

    private List<ItemSO> itemsInRoom = new List<ItemSO>();
    List<string> itemDescriptionsInRoom = new List<string>();

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one instance");
        }

        Instance = this;
    }

    public List<string> GetExitDescriptionsListInRoom()
    {
        List<string> exitDescriptionList = new List<string>();

        foreach (Exit exit in currentRoom.exits)
        {
            exitDescriptionList.Add(exit.description);
            exitsDictionary.Add(exit.direction, exit.room);
        }

        return exitDescriptionList;
    }

    private void SetItemsRooms()
    {

        foreach (ItemSO item in currentRoom.items)
        {
            if (!Inventory.Instance.IsItemInInventory(item.name))
            {
                itemsInRoom.Add(item);
                itemDescriptionsInRoom.Add(item.description);
            }
            foreach (Interaction interaction in item.interactions)
            {
                if (interaction.inputAction.keyWord.Equals("examine"))
                {
                    examineDictionary.Add(item.itemName, interaction.responseDescription);
                }
                else if (interaction.inputAction.keyWord.Equals("take"))
                {
                    takeDictionary.Add(item.itemName, interaction.responseDescription);
                }
            }

        }
    }

    public List<string> GetItemDescriptionsInRoom()
    {
        SetItemsRooms();
        return itemDescriptionsInRoom;
    }
    public void TryToChangeRoom(string direction)
    {
        if (exitsDictionary.ContainsKey(direction))
        {
            currentRoom = exitsDictionary[direction];
            GameManager.Instance.UpdateLogList($"Vas hacia el {direction}");
            GameManager.Instance.DisplayRoomText();
        }
        else
        {
            GameManager.Instance.UpdateLogList($"Te chocaste con la pared, dolio, has perdido 1 punto de vida");
        }
    }

    public string TryToExamineItem(string itemName)
    {
        if (examineDictionary.ContainsKey(itemName))
        {
            RemoveItemFromRoom(GetItemInRoomFromName(itemName));
            Inventory.Instance.AddItemToInventory(itemName);
            return examineDictionary[itemName];
        }
        return $"No puesdes coger {itemName}, has perdido 1 punto de vida";
    }

    public string TryToTakeItem(string itemName)
    {
        if (takeDictionary.ContainsKey(itemName))
        {
            return examineDictionary[itemName];
        }
        return $"No puesdes examinar {itemName}, has perdido 1 punto de vida";
    }

    public void ClearExits()
    {
        exitsDictionary.Clear();
    }

   public void ClearItems()
    {
        itemsInRoom.Clear();
        examineDictionary.Clear();
        itemDescriptionsInRoom.Clear();
        takeDictionary.Clear();
    }


    private ItemSO GetItemInRoomFromName(string itemName)
    {
        foreach (ItemSO item in currentRoom.items)
        {
            if (itemName.Equals(item.itemName))
            {
                return item;
            }
        }
        return null;
    }

    private void RemoveItemFromRoom(ItemSO item)
    {
        itemsInRoom.Remove(item);
    }
}
