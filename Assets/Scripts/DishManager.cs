using UnityEngine;

public class DishManager : MonoBehaviour
{
    [System.Serializable]
    public class Dish
    {
        public string dishName;
        public GameObject dishPrefab;
    }

    public Dish[] dishes;
    public Transform dishSpawnPoint;

    public void SpawnDish(string dishName)
    {
        foreach (Dish dish in dishes)
        {
            if (dish.dishName == dishName)
            {
                Instantiate(dish.dishPrefab, dishSpawnPoint.position, dishSpawnPoint.rotation);
                return;
            }
        }

        Debug.LogWarning("Dish not found: " + dishName);
    }
}