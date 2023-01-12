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
    private Rigidbody2D rgb;

    public string selectedItemName;


    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    Animator animator;

    private void Awake()
    {
        player = GetComponent<PlayerMovement>();
        inventoryPlayer = GetComponent<InventoryManager>();
        animator = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }
    

    // ReSharper disable Unity.PerformanceAnalysis
    public void UseTool()
    {
        selectedItemName = SetSelectedTool();

        if (selectedItemName is { Length: > 0 })
        {
            
            SetupToolAnimator();
            Vector3Int pos = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

            switch (selectedItemName)
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
                    if (Seed.HasSeed(selectedItemName))
                    {
                        if (GameManager.instace.TileManager.IsPlow(pos))
                        {
                            Seed seed = GameManager.instace.SeedManager.GetSeedByName(Seed.RemoveSeedAndIdentifyType(selectedItemName ));
                            seed.Sow(pos);
                        }
                    }
                    break;
            }

            

            animator.SetBool("acting", player.acting);
        }
    }


    private string SetSelectedTool()
    {
        var slotSelected = GameManager.instace.ToolbarUI.GetSelectedSlot();
        selectedItemName  = inventoryPlayer.GetInventoryByName("Toolbar").Slots[slotSelected.slotID].itemName;
        
        if (name != "")
        {
            return selectedItemName.ToUpper();
        }

        return null;
    }

    private void SetupToolAnimator()
    {
        animator.SetBool("AxeSelected", false);
        animator.SetBool("WaterSelected", false);
        animator.SetBool("HoeSelected", false);

        switch (selectedItemName)
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