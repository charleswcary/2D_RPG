using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemToolTip : MonoBehaviour {

    private Item item;
    private string data;
    private GameObject toolTip;

    private void Start()
    {
        toolTip = GameObject.Find("Tool_Tip");
        toolTip.SetActive(false);
    }
    private void Update()
    {
        if (toolTip.activeSelf)
        {
            toolTip.transform.position = Input.mousePosition;
        }
    }


    public void Activate(Item _item)
    {
        item = _item;
        ConstructString();
        toolTip.SetActive(true);
    }
    public void Deactivate()
    {
        toolTip.SetActive(false);
    }
    public void ConstructString()
    {
        data = "<color=#5EE3F6><b>" + item.Name + "</b></color>\n\n" + item.Description + "";
        toolTip.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data;
    }
}
