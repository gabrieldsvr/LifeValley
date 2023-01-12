using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instace;
    public ItemManager ItemManager;
    public TileManager TileManager;
    public Toolbar_UI ToolbarUI;
    public UI_Manager UIManager;
    public SeedManager SeedManager;
    public CropsManager CropsManager;
    public TimeManager TimeManager;


    public Player Player;
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
        UIManager = GetComponent<UI_Manager>();
        SeedManager = GetComponent<SeedManager>();
        ToolbarUI = GetComponent<Toolbar_UI>();
        TimeManager = GetComponent<TimeManager>();
        CropsManager = GetComponent<CropsManager>();
        
        Player = FindObjectOfType<Player>();
    }
}
