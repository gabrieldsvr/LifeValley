using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{

    public GameObject inventoryPanel;
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();

    // Update is called once per frame
    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void ToggleInventory()
    {
        Debug.Log("reload");
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        Refresh();
    }

    void Refresh()
    {
        if (slots.Count == player.inventory.Slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.Slots[i].itemName != "")
                {
                    slots[i].SetItem(player.inventory.Slots[i]);
                    
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove(int slotID)
    {
        
        Debug.Log("removeu " + slotID);
        
        Item itemToDrop = GameManager.instace.ItemManager.GetItemByName(player.inventory.Slots[slotID].itemName);
        
        if (itemToDrop != null)
        {
            player.DropItem(itemToDrop);
            player.inventory.Remove(slotID);
            Refresh();
        }
    
    }
}
