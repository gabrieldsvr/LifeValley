using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
public class Player : MonoBehaviour
{
    public InventoryManager inventory;

    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
    }
    

    public void DropItem(Item item)
    {
        Vector3 spawnLocation = transform.position;

        float randX = Random.Range(-1f, 1f);
        float randY = Random.Range(-1f, 1f);

        Vector3 spawnOffeset = new Vector3(randX, randY, 0f).normalized;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffeset, Quaternion.identity);

        droppedItem.rb2d.AddForce(spawnOffeset * 2f, ForceMode2D.Impulse);
    }
    
    public void DropItem(Item item, int numToDrop)
    {
        for (int i = 0; i < numToDrop; i++)
        {
            DropItem(item);
            
        }
    }
}