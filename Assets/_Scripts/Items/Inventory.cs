using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour {

    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    int slotAmount = 16;

    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    private void Start()
    {
        database = GetComponent<ItemDatabase>();
        inventoryPanel = GameObject.Find("Inventory_Panel");
        slotPanel = GameObject.Find("Slot_Panel");

        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot, slotPanel.transform));
            slots[i].GetComponent<ItemSlot>().id = i;
        }

        AddItem(0);
        AddItem(1); AddItem(1); AddItem(1); AddItem(1); AddItem(1); AddItem(1); AddItem(1); AddItem(1); AddItem(1);
        AddItem(2);
        AddItem(0);
    }

    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);
        if(itemToAdd.Stackable && CheckInventory(itemToAdd))
        {
            AddToStack(itemToAdd);
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem, slots[i].transform);
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().slot = i;
                    itemObj.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = itemToAdd.Name;
                    data.transform.Find("Stack_Amount").GetComponent<TextMeshProUGUI>().text = data.stackAmount.ToString();
                    itemObj.name = itemToAdd.Name;
                    break;
                }
            }
        }
        
    }
    bool CheckInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
            {
                return true;
            }
        }
        return false;
    }
    void AddToStack(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
            {
                ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                data.stackAmount++;
                data.transform.Find("Stack_Amount").GetComponent<TextMeshProUGUI>().text = data.stackAmount.ToString();
            }
        }
    }
}
