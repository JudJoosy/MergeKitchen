using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingSlotManager : MonoBehaviour
{
    public static CookingSlotManager Instance;

    [SerializeField] private List<CookingSlot> cookingSlots;
    [SerializeField] private RecipeManager recipeManager;
    [SerializeField] private GameObject dishPrefab;
    [SerializeField] private Transform dishSpawnPoint;

    private void Awake()
    {
        Instance = this;
    }

    public void TryPlaceIngredient(string name, Sprite sprite)
    {
        foreach (var slot in cookingSlots)
        {
            if (!slot.HasIngredient())
            {
                slot.SetIngredient(name, sprite);
                CheckForDish();
                return;
            }
        }

        Debug.Log("All cooking slots are full!");
    }

    private void CheckForDish()
    {
        List<string> currentIngredients = new List<string>();

        foreach (var slot in cookingSlots)
        {
            if (slot.HasIngredient())
            {
                currentIngredients.Add(slot.GetIngredientName());
            }
        }

        string dishName = recipeManager.TryMakeDish(currentIngredients);

        if (!string.IsNullOrEmpty(dishName))
        {
            SpawnDish(dishName);
            ClearCookingSlots();
        }
    }

    private void SpawnDish(string dishName)
    {
        GameObject dish = Instantiate(dishPrefab, dishSpawnPoint.position, Quaternion.identity);
        dish.name = dishName;

        Debug.Log($"Dish created: {dishName}");

        Destroy(dish, 3f); // Auto remove after 3 seconds
    }

    private void ClearCookingSlots()
    {
        foreach (var slot in cookingSlots)
        {
            slot.ClearSlot();
        }
    }
}