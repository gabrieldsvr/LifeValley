using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Tilemaps;


public class ToolsPlayerController : MonoBehaviour
{
    private PlayerMovement player;
    private InventoryManager inventoryPlayer;
    private Player pla;
    private Rigidbody2D rgb;

    public Item selectedItem;


    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    Animator animator;

    private void Awake()
    {
        player = GetComponent<PlayerMovement>();
        inventoryPlayer = GetComponent<InventoryManager>();
        pla = GetComponent<Player>();
        animator = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }
    

    // ReSharper disable Unity.PerformanceAnalysis
    public void UseTool()
    {
        selectedItem = SetSelectedTool();

        if (selectedItem)
        {
            
            
            Vector3Int pos = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);
            SetupToolAnimator();
            switch (selectedItem.GetName())
            {
                case "AXE":
                    Vector2 position = rgb.position + player.lastMotionVector * offsetDistance;
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
                    foreach (Collider2D c in colliders)
                    {
                        ToolHit hit = c.GetComponent<ToolHit>();
                        if (hit != null)
                        {
                            hit.Hit();
                            break;
                        }
                    }
                    break;

                case "WATER":
                    Debug.Log("acoes agua");
                    break;

                case "HOE":

                    if (GameManager.instace.TileManager.IsInteractable(pos))
                    {
                        GameManager.instace.CropsManager.Plow(pos);
                    }
                    if (GameManager.instace.CropsManager.VerifyIsLastStage(pos))
                    {
                        GameManager.instace.CropsManager.pick(pos);
                    }
                    break;
                
                default:
                    // Ação com semente na mão
                    if (selectedItem.GetType() == ItemData.ItemTypes.Seed)
                    {
                        if (GameManager.instace.TileManager.IsPlow(pos))
                        {
                            GameManager.instace.UIManager.InventoryUIByName["Toolbar"].SelectedSlotLessOne( GameManager.instace.ToolbarUI.GetSelectedSlot().slotID);
                            Seed seed = GameManager.instace.SeedManager.GetSeedByName(Seed.RemoveSeedAndIdentifyType(selectedItem.GetName() ));
                            seed.Sow(pos);
                        }
                        
                    }
                    if (Seed.HasSeed(selectedItem.GetName()))
                    {
                        if (GameManager.instace.TileManager.IsPlow(pos))
                        {
                            GameManager.instace.UIManager.InventoryUIByName["Toolbar"].SelectedSlotLessOne( GameManager.instace.ToolbarUI.GetSelectedSlot().slotID);
                            Seed seed = GameManager.instace.SeedManager.GetSeedByName(Seed.RemoveSeedAndIdentifyType(selectedItem.GetName()  ));
                            seed.Sow(pos);
                        }
                        
                    }


                    if (selectedItem.GetType() == ItemData.ItemTypes.Food)
                    {
                        pla.RecoverHunger(10);
                    }
                    
                    break;
            }

            

            animator.SetBool("acting", player.acting);
        }
        else
        {
            ResetActionsAnimator();
        }
    }


    private Item SetSelectedTool()
    {
        var slotSelected = GameManager.instace.ToolbarUI.GetSelectedSlot();
        name  = inventoryPlayer.GetInventoryByName("Toolbar").Slots[slotSelected.slotID].itemName;
        selectedItem = GameManager.instace.ItemManager.GetItemByName(name);
        
        if (selectedItem != null)
        {
            return selectedItem;
        }

        return null;
    }

    private void ResetActionsAnimator()
    {
        animator.SetBool("AxeSelected", false);
        animator.SetBool("WaterSelected", false);
        animator.SetBool("HoeSelected", false);
    }
    private void SetupToolAnimator()
    {
      ResetActionsAnimator();

        switch (selectedItem.GetName())
        {
            case "AXE":
                animator.SetBool("AxeSelected", true);
                break;
            case "WATER":
                animator.SetBool("WaterSelected", true);
                break;
            case "HOE":
                animator.SetBool("HoeSelected", true);
                break;
        }
    }
}