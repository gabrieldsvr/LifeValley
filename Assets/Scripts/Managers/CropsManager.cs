using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using static Collectable;
using Random = UnityEngine.Random;

public class CropTile
{
    public int growTimer;
    public int growStage;
    public bool growFinished;
    public Seed Seed;
    public Vector3Int tilePosition;
    public void addTimeGroth()
    {
        growTimer++;
    }
    public void nextStage()
    {
        growStage++;
    }
}

public class CropsManager : TimeAgent
{
    [SerializeField] private TileBase plowed;
    [SerializeField] private TileBase seeded;
    [SerializeField] private Tilemap targetTilemap;

    private Dictionary<Vector2Int, CropTile> cropsTiles;

    private void Awake()
    {
        targetTilemap = GameManager.instace.TileManager.interactableMap;
    }

    private void Start()
    {
        cropsTiles = new Dictionary<Vector2Int, CropTile>();
        onTimeTick += Tick;
        Init();
    }


    public void Tick()
    {
        //TODO REMOVER DPS
        GameManager.instace.TimeManager.TimeValueCalculation();

        foreach (CropTile cropTile in cropsTiles.Values)
        {
            if (cropTile.growFinished)
            {
                continue;
            }

            if (cropTile.Seed == null)
            {
                continue;
            }

            cropTile.addTimeGroth();

            if (cropTile.growTimer >= cropTile.Seed.GetCropData().GetGrothStageTimeByStage(cropTile.growStage))
            {
                Grow(cropTile);

                cropTile.nextStage();
            }

            if (cropTile.growTimer >= cropTile.Seed.GetCropData().GetTimeToGrow())
            {
                cropTile.growFinished = true;
            }
        }
    }
    public bool Check(Vector3Int positon)
    {
        return cropsTiles.ContainsKey((Vector2Int)positon);
    }


    //Plow
    public void Plow(Vector3Int position)
    {
        if (cropsTiles.ContainsKey((Vector2Int)position))
        {
            return;
        }

        CreatePlowedTile(position);
    }

    private void CreatePlowedTile(Vector3Int position)
    {
        CropTile cropTile = new CropTile();

        cropsTiles.Add((Vector2Int)position, cropTile);

        targetTilemap.SetTile(position, plowed);
    }
    
    //Sow
    public void Sow(Vector3Int position, Seed seed)
    {
        targetTilemap.SetTile(position, seeded);
        cropsTiles[(Vector2Int)position].Seed = seed;
        cropsTiles[(Vector2Int)position].tilePosition = position;
    }
    
    private void Grow(CropTile cropTile)
    {
        targetTilemap.SetTile(cropTile.tilePosition,
            cropTile.Seed.GetCropData().GetSpriteTilesByIndex(cropTile.growStage));
    }

    public bool VerifyIsLastStage(Vector3Int position)
    {
        if (cropsTiles.Count != 0)
        {
            if (cropsTiles[(Vector2Int)position].Seed != null)
            {
                if (cropsTiles[(Vector2Int)position].Seed.GetCropData().GetTimeToGrow() >=
                    cropsTiles[(Vector2Int)position].growTimer)
                {
                    return true;
                }
            }
        }

        return false;
    }
    public void pick(Vector3Int pos)
    {
        cropsTiles[(Vector2Int)pos].Seed.Harvest(pos);
        cropsTiles.Remove((Vector2Int)pos);
        Plow(pos);
    }
}