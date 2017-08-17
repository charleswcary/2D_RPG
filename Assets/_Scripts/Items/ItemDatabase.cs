using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour {

    List<Item> database = new List<Item>();
    JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();
        Debug.Log(database.Count);
        Debug.Log(database[2].Class);
        Debug.Log(FetchItemByID(1).Class);
    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if(database[i].ID == id)
            {
                return database[i];
            }
        }
        return null;
    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["name"].ToString(), (int)itemData[i]["value"], itemData[i]["class"].ToString(), 
                (bool)itemData[i]["stackable"], itemData[i]["slug"].ToString(),itemData[i]["description"].ToString(), itemData[i]["rarity"].ToString()));
        }
    }
}

public class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Class { get; set; }
    public int Value { get; set; }
    public bool Stackable { get; set; }
    public int Physical { get; set; }
    public int Magic { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string Rarity { get; set; }

    public Item(int id, string name, int value, string _class, bool stackable, string slug, string description, string rarity)
    {
        ID = id;
        Name = name;
        Value = value;
        Class = _class;
        Stackable = stackable;
        Slug = slug;
        Description = description;
        Rarity = rarity;
    }

    public Item()
    {
        ID = -1;
    }
}
