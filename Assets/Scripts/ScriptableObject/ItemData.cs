using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Data/Item", order = 50)]
public class ItemData : ScriptableObject
{
    [SerializeField] private string name = "";
    [SerializeField] private Sprite icon;
    [SerializeField] private ItemTypes type = ItemTypes.Collectable;


    public enum ItemTypes
    {
        Food,
        Drink,
        Seed,
        Tool,
        Collectable
    }

    public string GetName()
    {
        return name;
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public ItemTypes GetType()
    {
        return type;
    }
}