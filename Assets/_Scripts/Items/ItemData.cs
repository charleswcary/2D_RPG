using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {

    public Item item;
    public int stackAmount = 1;
    public int slot;

    private Inventory inventory;
    private ItemToolTip toolTip;

    private void Start()
    {
        inventory = GameObject.Find("DungeonMaster").GetComponent<Inventory>();
        toolTip = inventory.GetComponent<ItemToolTip>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            transform.SetParent(GameObject.Find("Slot_Panel").transform);
            transform.position = eventData.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(inventory.slots[slot].transform);
        transform.position = inventory.slots[slot].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.Activate(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.Deactivate();
    }
}
