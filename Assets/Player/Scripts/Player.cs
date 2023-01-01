using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(25);
    }

    public void DropItem(Collectable item)
    {
        Vector3 spawnLocation = transform.position;

        float randX = Random.Range(-1f, 1f);
        float randY = Random.Range(-1f, 1f);

        Vector3 spawnOffeset = new Vector3(randX, randY, 0f).normalized;

        Collectable droppedItem = Instantiate(item, spawnLocation + spawnOffeset, Quaternion.identity);

        droppedItem.rb2d.AddForce(spawnOffeset * 2f, ForceMode2D.Impulse);
    }
}