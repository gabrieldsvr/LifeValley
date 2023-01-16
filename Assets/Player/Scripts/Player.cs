using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public InventoryManager inventory;
    
    [SerializeField] private string name;

    [SerializeField] private float life;

    [SerializeField] private float stamina;

    [SerializeField] private float thirst;

    [SerializeField] private float hunger;


    private const float MaxLife = 100f;
    private const float MaxStamina = 100f;
    private const float MaxThirst = 100f;
    private const float MaxHunger = 100f;


    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
    }

    private void Start()
    {
        stamina = MaxStamina;
        thirst = MaxThirst;
        life = MaxLife;
        hunger = MaxHunger;
    }

    public void SpendThirst(float amount)
    {
        thirst -= amount;
        thirst = Mathf.Clamp(thirst, 0, thirst);
    }

    public void RecoverThirst(float amount)
    {
        thirst += amount;
        thirst = Mathf.Clamp(thirst, 0, thirst);
    }

    public void SpendHunger(float amount)
    {
        hunger -= amount;
        hunger = Mathf.Clamp(hunger, 0, MaxHunger);
    }

    public void RecoverHunger(float amount)
    {
        hunger += amount;
        hunger = Mathf.Clamp(hunger, 0, MaxHunger);
    }

    public void SpendLife(float amount)
    {
        life -= amount;
        life = Mathf.Clamp(life, 0, MaxLife);
    }

    public void RecoverLife(float amount)
    {
        life += amount;
        life = Mathf.Clamp(life, 0, MaxLife);
    }

    public void SpendStamina(float amount)
    {
        stamina -= amount;
        stamina = Mathf.Clamp(stamina, 0, MaxStamina);
    }

    public void RecoverStamina(float amount)
    {
        stamina += amount;
        stamina = Mathf.Clamp(stamina, 0, MaxStamina);
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