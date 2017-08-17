using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public int id;
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.Find("DungeonMaster").GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemData dropItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (inventory.items[id].ID == -1)
        {
            inventory.items[dropItem.slot] = new Item();
            inventory.items[id] = dropItem.item;
            dropItem.slot = id;
        }
        else if(dropItem.slot != id)
        {
            Transform item = transform.GetChild(0);
            item.GetComponent<ItemData>().slot = dropItem.slot;
            item.SetParent(inventory.slots[dropItem.slot].transform);
            item.position = inventory.slots[dropItem.slot].transform.position;

            dropItem.slot = id;
            dropItem.transform.SetParent(transform);
            dropItem.transform.position = transform.position;

            inventory.items[dropItem.slot] = item.GetComponent<ItemData>().item;
            inventory.items[id] = dropItem.item;
        }
    }
}
