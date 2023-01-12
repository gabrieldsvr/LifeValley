using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Data/Crop")]
public class CropData : ScriptableObject
{
    [SerializeField] private int timeToGrow = 10;
    [SerializeField] private List<int> growthStagesTimes;
    [SerializeField] private List<Tile> spritesTilesGrow;
    [SerializeField] private Item itemDropped;
    [SerializeField] private int numberOfDroppedItems = 1;

    public int GetTimeToGrow()
    {
        return timeToGrow;
    }

    public List<Tile> GetSpritesTilesGrow()
    {
        return spritesTilesGrow;
    }

    public List<int> GetGrowthStagesTimes()
    {
        return growthStagesTimes;
    }

    public int GetGrothStageTimeByStage(int stage)
    {
        return growthStagesTimes[stage];
    }

    public Tile GetSpriteTilesByIndex(int index)
    {
        if (index < 0 || index >= spritesTilesGrow.Count)
        {
            Debug.Log("Index is out of range");
            throw new IndexOutOfRangeException("Index is out of range");
        }

        return spritesTilesGrow[index];
    }

    public Item GetItemDropped()
    {
        return itemDropped;
    }
    public int GetNumberOfDroppedItems()
    {
        return numberOfDroppedItems;
    }
}