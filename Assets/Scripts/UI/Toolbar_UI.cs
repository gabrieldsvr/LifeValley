using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar_UI : MonoBehaviour
{
    [SerializeField] private List<Slot_UI> toolbarSlots = new List<Slot_UI>();

    private Slot_UI selectedSlot;

    [SerializeField]private PlayerMovement playerMoviment;

   


    private void Start()
    {
        playerMoviment = GameManager.instace.Player.GetComponent<PlayerMovement>();
        SelectSlot(0);
    }

    private void Update()
    {
        CheckAlphaNumericKeys();
    }

    public void SelectSlot(int index)
    {
        if (toolbarSlots.Count == 9)
        {
            if (selectedSlot != null)
            {
                selectedSlot.SetHighLight(false);
            }

            selectedSlot = toolbarSlots[index];
            selectedSlot.SetHighLight(true);
        }
    }

    private void CheckAlphaNumericKeys()
    {

        if (!playerMoviment.acting)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectSlot(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectSlot(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectSlot(2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SelectSlot(3);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                SelectSlot(4);
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                SelectSlot(5);
            }

            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                SelectSlot(6);
            }

            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                SelectSlot(7);
            }

            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                SelectSlot(8);
            }
        }
    }
    
    public Slot_UI GetSelectedSlot()
    {
        return selectedSlot;
    }
    
}