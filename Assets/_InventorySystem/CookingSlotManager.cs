using System.Collections.Generic;
using UnityEngine;

public class CookingSlotManager : MonoBehaviour
{
    public static CookingSlotManager Instance;
    public List<CookingSlot> cookingSlots;
    public RecipeManager recipeManager;
    public Transform dishSpawnPoint;

    private void Awake()
    {
        Instance = this;
    }

    public void TryCook()
    {
        List<string> currentIngredients = new List<string>();

        foreach (CookingSlot slot in cookingSlots)
        {
            if (slot.HasIngredient())
            {
                currentIngredients.Add(slot.GetIngredientName());
            }
        }

        string dishPrefabName = recipeManager.TryMakeDish(currentIngredients);

        if (!string.IsNullOrEmpty(dishPrefabName))
        {
            SpawnDish(dishPrefabName);
            ClearCookingSlots();
        }
        else
        {
            Debug.Log("No valid recipe found.");
        }
    }

    public void TryPlaceIngredient(string ingredientName, Sprite icon)
    {
        foreach (CookingSlot slot in cookingSlots)
        {
            if (!slot.HasIngredient())
            {
                slot.SetIngredient(ingredientName, icon);
                return;
            }
        }

        Debug.Log("All cooking slots are full!");
    }

    void SpawnDish(string prefabName)
    {
        GameObject dishPrefab = Resources.Load<GameObject>("Dishes/" + prefabName);
        if (dishPrefab != null)
        {
            Instantiate(dishPrefab, dishSpawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Dish prefab not found in Resources/Dishes/" + prefabName);
        }
    }

    public void ClearCookingSlots()
    {
        foreach (CookingSlot slot in cookingSlots)
        {
            slot.ClearSlot();
        }
    }
}