using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class Collectable : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float pickUpDistance = 1.5f;
    [SerializeField] private float ttl = 10f;
    private void Update()
    {
        // float distance = Vector3.Distance(transform.position, player.position);
        //
        // if (distance>pickUpDistance)
        // {
        //     return;
        // }
        //
        // transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            Item item = GetComponent<Item>();
            if (item != null)
            {
                player.inventory.Add(item);
                Destroy(this.gameObject);
            }
           
        }
    }
}
