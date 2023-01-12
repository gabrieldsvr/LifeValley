using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Collectable;

public class ItemManager : MonoBehaviour
{
    public Item[] items;

    public Dictionary<string, Item> nameToItemDict =
        new Dictionary<string, Item>();

    private void Awake()
    {
        foreach (Item item in items)
        {
            AddItem(item);
        }
    }

    private void AddItem(Item item)
    {
        if (!nameToItemDict.ContainsKey(item.GetName()))
        {
            nameToItemDict.Add(item.GetName(),item);
        }
    }

    public Item GetItemByName(string key)
    {
        if (nameToItemDict.ContainsKey(key))
        {
            return nameToItemDict[key];
        }

        return null;
    }
    public  Dictionary<string,Item> GetAllItems()
    {
        return nameToItemDict;
    }
}