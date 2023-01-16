using UnityEngine;

[CreateAssetMenu(fileName = "Food Data", menuName = "Data/Food", order = 50)]
public class FoodData : ScriptableObject
{
    [SerializeField] private string name = "";
    [SerializeField] private float foodValue;
    [SerializeField] private float energyValue;

    
    public string GetName()
    {
        return name;
    }

    public float GetFoodValue()
    {
        return foodValue;
    }

    public float GetEnergyValue()
    {
        return energyValue;
    }
}