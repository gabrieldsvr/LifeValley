using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{

    public int slotID;
    public Inventory Inventory;
    
    public Image itemIcon;
    public TextMeshProUGUI quatityText;
    public Sprite defaultIcon;

    [SerializeField] private GameObject highlight;


    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1,1);

            quatityText.text = slot.count.ToString();
        }
    }


    public void SetEmpty()
    {
        itemIcon.sprite = defaultIcon;
        quatityText.text = "";
    }

    public void SetHighLight(bool isOn)
    {
        highlight.SetActive(isOn);
    }
    
  
   

}
