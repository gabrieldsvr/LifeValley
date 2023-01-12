using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

  public Dictionary<string, Inventory_UI> InventoryUIByName = new Dictionary<string, Inventory_UI>();
  public List<Inventory_UI> InventoryUIs;

  public GameObject inventoryPanel;

  public static Slot_UI draggedSlot;
  public static Image draggedIcon;
  public static bool dragSingle;

  private void Awake()
  {
    
    Initialize();
    inventoryPanel.SetActive(false);
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.B))
    {
      ToggleInventoryUI();
    }
    
    if (Input.GetKey(KeyCode.LeftControl))
    {
      dragSingle = true;
    }
    else
    {
      dragSingle = false;
    }
  }

  private void Initialize()
  {
    foreach (Inventory_UI ui in InventoryUIs)
    {
      if (!InventoryUIByName.ContainsKey(ui.inventoryName))
      {
        InventoryUIByName.Add(ui.inventoryName, ui);
      } 
    }
  }

  public Inventory_UI GetInventoryUI(string inventoryName)
  {
    if (InventoryUIByName.ContainsKey(inventoryName))
    {
      return InventoryUIByName[inventoryName];
    }

    return null;
  }
  
  // ReSharper disable Unity.PerformanceAnalysis
  public void ToggleInventoryUI()
  {
    if (inventoryPanel != null)
    {
      inventoryPanel.SetActive(!inventoryPanel.activeSelf);
      RefreshInvetoryUI("Backpack");
    }
  }

  public void RefreshInvetoryUI(string inventoryName)
  {
    if (InventoryUIByName.ContainsKey(inventoryName))
    {
      InventoryUIByName[inventoryName].Refresh();
    }
  }
  
  public void RefreshAll()
  {
    foreach (KeyValuePair<string,Inventory_UI> keyValuePair in InventoryUIByName)
    {
      keyValuePair.Value.Refresh();
    }
  }
  
}
