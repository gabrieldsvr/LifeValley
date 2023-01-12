using UnityEngine;

[CreateAssetMenu(fileName = "Seed Data", menuName = "Data/Seed", order = 52)]
public class SeedData : ScriptableObject
{
    [SerializeField]private string name = "";
    public string GetName()
    {
        return name.ToUpper();
    }
}