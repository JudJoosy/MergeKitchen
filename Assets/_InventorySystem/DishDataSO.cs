using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDishData", menuName = "Cooking/Dish Data")]
public class DishDataSO : ScriptableObject
{
    public string dishName;
    public List<string> requiredIngredients;
    public int rewardAmount;
    public GameObject dishPrefab;
}
