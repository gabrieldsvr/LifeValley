using UnityEngine;

[CreateAssetMenu(fileName = "Drink Data", menuName = "Data/Drink", order = 50)]
public class DrinkData : ScriptableObject
{
    [SerializeField] private string name = "";
    [SerializeField] private float drinkValue;
    [SerializeField] private float energyValue;

    public string GetName()
    {
        return name;
    }

    public float GetDrinkValue()
    {
        return drinkValue;
    }

    public float GetEnergyValue()
    {
        return energyValue;
    }
}