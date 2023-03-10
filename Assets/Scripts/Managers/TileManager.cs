using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Tilemap interactableMap;
    [SerializeField] public Tilemap cropsMap;

    [SerializeField] private Tile hiddenIteractableTile;
    [SerializeField] private Tile interactedTile;
    void Start()
    {
        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);

            if (tile != null && tile.name == "interactable_visible")
            {
                interactableMap.SetTile(position,hiddenIteractableTile);
            }
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if (tile != null)
        {
            if (tile.name == "interactable")
            {
                return true;
            }

            return false;
        }

        return false;
    }
    public bool IsPlow(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if (tile != null)
        {
            if (tile.name == "plow")
            {
                return true;
            }

            return false;
        }

        return false;
    }
    public void SetInteracted(Vector3Int position)
    {
        interactableMap.SetTile(position,interactedTile);
    }
    
    
}
