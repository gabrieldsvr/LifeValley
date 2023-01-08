using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(25);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x, (int) transform.position.y,0);
            if (GameManager.instace.TileManager.IsInteractable(position))
            {
                GameManager.instace.TileManager.SetInteracted(position);
            }
        }
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
}