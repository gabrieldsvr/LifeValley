using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
   [System.Serializable]
   public class Slot
   {
      public string itemName;
      public int count;
      public int maxAllowed;

      public Sprite icon;

      public Slot()
      {
         itemName = "";
         count = 0;
         maxAllowed = 99;
      }

      public bool IsEmpty
      {
         get
         {
            if (itemName == "" && count == 0)
            {
               return true;
            }

            return false;
         }
      }
      public bool CanAddItem(string itemName)
      {
         if (this.itemName == itemName && count < maxAllowed)
         {
            return true;
         }
         return false;
      }

      public void AddItem(Item item)
      {
         this.itemName = item.GetName();
         this.icon = item.GetIcon();
         count++;
      }
      public void AddItem(string itemName, Sprite icon, int maxAllowed)
      {
         this.itemName = itemName;
         this.icon = icon;
         count++;
         this.maxAllowed = maxAllowed;
      }
      public void RemoveItem()
      {
         if (count>0)
         {
            count--;

            if (count==0)
            {
               icon = null;
               itemName = "";
            }
         }
      }
   }

   public List<Slot> Slots = new List<Slot>();

   public Inventory(int numSlots)
   {
      for (int i = 0; i < numSlots; i++)
      {
         Slot slot = new Slot();
         Slots.Add(slot);
         
      }
   }

   public void Add(Item item)
   {
      foreach (Slot slot in Slots)
      {
         if (slot.itemName == item.GetName() && slot.CanAddItem(item.GetName()))
         {
            slot.AddItem(item);
            return;
         }
      }

      foreach (Slot slot in Slots)
      {
         if (slot.itemName == "")
         {
            slot.AddItem(item);
            return;
         }
      }
   }

   public void Remove(int index)
   {
      Slots[index].RemoveItem();
   }

   public void Remove(int index, int numToRemove)
   {
      if (Slots[index].count >= numToRemove)
      {
         for (int i = 0; i < numToRemove; i++)
         {
            Remove(index);
         }
      }
   }

   public void MoveSlot(int fromIndex, int toIndex, Inventory toInventory, int numToMove = 1)
   {
      Slot fromSlot = Slots[fromIndex];
      Slot toSlot = toInventory.Slots[toIndex];

      if (toSlot.IsEmpty || toSlot.CanAddItem(fromSlot.itemName))
      {
         for (int i = 0; i < numToMove; i++)
         {
            toSlot.AddItem(fromSlot.itemName, fromSlot.icon, fromSlot.maxAllowed);
            fromSlot.RemoveItem();
         }
      }
   }
}
