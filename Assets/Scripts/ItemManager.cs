using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static Collectable;

public class ItemManager : MonoBehaviour
{
    public Collectable[] CollectablesItems;

    public Dictionary<CollectableType, Collectable> CollectableItemsDict =
        new Dictionary<CollectableType, Collectable>();

    private void Awake()
    {
        foreach (Collectable item in CollectablesItems)
        {
            AddItem(item);
        }
    }

    private void AddItem(Collectable item)
    {
        if (!CollectableItemsDict.ContainsKey(item.type))
        {
            CollectableItemsDict.Add(item.type,item);
        }
    }

    public Collectable GetItemByType(CollectableType type)
    {
        if (CollectableItemsDict.ContainsKey(type))
        {
            return CollectableItemsDict[type];
        }

        return null;
    }
}