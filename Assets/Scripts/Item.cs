using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
    [SerializeField]private ItemData data;
    

    [HideInInspector] public Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public string GetName() { return data.GetName().ToUpper(); }
    public Sprite GetIcon() { return data.GetIcon(); }
    
}
