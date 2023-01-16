using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private FoodData foodData;

    public string GetName()
    {
        return foodData.GetName();
    }

    public float GetFoodValue()
    {
        return foodData.GetFoodValue();
    }
    
    public float GetEnergyValue()
    {
        return foodData.GetEnergyValue();
    }
}