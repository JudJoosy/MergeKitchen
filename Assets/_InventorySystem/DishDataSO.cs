using UnityEngine;

[CreateAssetMenu(fileName = "NewDishData", menuName = "Cooking/Dish Data")]
public class DishDataSO : ScriptableObject
{
    public string dishName;
    public GameObject dishPrefab;
    public int dishValue;
}