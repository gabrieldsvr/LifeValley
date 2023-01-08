using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instace;

    public ItemManager ItemManager;

    public TileManager TileManager;
    private void Awake()
    {
        if (instace != null && instace != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instace = this;
        }
        DontDestroyOnLoad(this.gameObject);

        ItemManager = GetComponent<ItemManager>();
        TileManager = GetComponent<TileManager>();
    }
}
