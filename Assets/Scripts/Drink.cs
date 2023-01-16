using UnityEngine;

public class Drink : MonoBehaviour
{
    [SerializeField] private DrinkData drinkData;

    public string GetName()
    {
        return drinkData.GetName();
    }

    public float GetDrinkValue()
    {
        return drinkData.GetDrinkValue();
    }

    public float GetEnergyValue()
    {
        return drinkData.GetEnergyValue();
    }
}