using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public string inventoryName;
    public List<Slot_UI> slots = new List<Slot_UI>();

    [SerializeField] private Canvas canvas;
    private bool dragSingle;
    private Inventory inventory;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }


    private void Start()
    {
        inventory = GameManager.instace.Player.inventory.GetInventoryByName(inventoryName);

        SetupSlots();
        Refresh();
    }

    private void SetupSlots()
    {
        int counter = 0;
        foreach (Slot_UI slot in slots)
        {
            slot.slotID = counter;
            counter++;
            slot.Inventory = inventory;
        }
    }

    public void Refresh()
    {
        if (slots.Count == inventory.Slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (inventory.Slots[i].itemName != "")
                {
                    slots[i].SetItem(inventory.Slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }
    
    public void SelectedSlotLessOne(int slotID)
    {
        slots[slotID].Inventory.Slots[slotID].RemoveItem();
        Refresh();
    } 
    
    public void Remove()
    {
        if (UI_Manager.draggedSlot != null)
        {
            Item itemToDrop =
                GameManager.instace.ItemManager.GetItemByName(inventory.Slots[UI_Manager.draggedSlot.slotID].itemName);

            if (itemToDrop != null)
            {
                if (UI_Manager.dragSingle)
                {
                    GameManager.instace.Player.DropItem(itemToDrop);
                    inventory.Remove(UI_Manager.draggedSlot.slotID);
                }
                else
                {
                    GameManager.instace.Player.DropItem(itemToDrop,
                        inventory.Slots[UI_Manager.draggedSlot.slotID].count);
                    inventory.Remove(UI_Manager.draggedSlot.slotID,
                        inventory.Slots[UI_Manager.draggedSlot.slotID].count);
                }

                Refresh();
            }

            UI_Manager.draggedSlot = null;
        }
    }

    public void SlotBeginDrag(Slot_UI slot)
    {
        UI_Manager.draggedSlot = slot;
        UI_Manager.draggedIcon = Instantiate(UI_Manager.draggedSlot.itemIcon);
        UI_Manager.draggedIcon.raycastTarget = false;
        UI_Manager.draggedIcon.rectTransform.sizeDelta = new Vector2(50, 50);
        UI_Manager.draggedIcon.transform.SetParent(canvas.transform);

        MoveToMousePosition(UI_Manager.draggedIcon.gameObject);
    }

    public void SlotDrag()
    {
        MoveToMousePosition(UI_Manager.draggedIcon.gameObject);
    }

    public void SlotEndDrag()
    {
        Destroy(UI_Manager.draggedIcon.gameObject);
        UI_Manager.draggedIcon = null;
    }

    public void SlotDrop(Slot_UI slot)
    {
        if (UI_Manager.dragSingle)
        {
            UI_Manager.draggedSlot.Inventory.MoveSlot(UI_Manager.draggedSlot.slotID, slot.slotID, slot.Inventory);
            GameManager.instace.UIManager.RefreshAll();
        }
        else
        {
            UI_Manager.draggedSlot.Inventory.MoveSlot(UI_Manager.draggedSlot.slotID, slot.slotID, slot.Inventory,
                UI_Manager.draggedSlot.Inventory.Slots[UI_Manager.draggedSlot.slotID].count);
        }

        GameManager.instace.UIManager.RefreshAll();
    }

    private void MoveToMousePosition(GameObject toMove)
    {
        if (canvas != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle
                (canvas.transform as RectTransform, Input.mousePosition, null, out position);

            toMove.transform.position = canvas.transform.TransformPoint(position);
        }
    }
}