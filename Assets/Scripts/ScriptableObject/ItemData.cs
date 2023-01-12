using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Data/Item", order = 50)]
public class ItemData : ScriptableObject
{
    [SerializeField] private string name = "";
    [SerializeField] private Sprite icon;

    public string GetName()
    {
        return name;
    }

    public Sprite GetIcon()
    {
        return icon;
    }
}