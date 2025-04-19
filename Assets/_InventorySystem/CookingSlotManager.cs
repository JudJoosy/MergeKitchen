using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CookingSlotManager : MonoBehaviour
{
    public static CookingSlotManager Instance;

    [System.Serializable]
    public class DishData
    {
        public string dishName;
        public GameObject dishPrefab;
    }

    public List<CookingSlot> cookingSlots;
    public RecipeManager recipeManager;
    public Transform dishSpawnPoint;
    public TMP_Text dishNameText; // UI text to show the dish name
    public List<DishData> dishPrefabs;

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

        string dishName = recipeManager.TryMakeDish(currentIngredients);

        if (!string.IsNullOrEmpty(dishName))
        {
            ShowDishName(dishName);
            ClearCookingSlots();
        }
        else
        {
            Debug.Log("No valid recipe found.");
            if (dishNameText != null)
            {
                dishNameText.text = "Invalid recipe!";
                StartCoroutine(ClearDishNameTextAfterDelay());
            }
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

    // Show the dish name on the UI (without spawning the model)
    void ShowDishName(string dishName)
    {
        if (dishNameText != null)
        {
            dishNameText.text = "You made: " + dishName;
            StartCoroutine(ClearDishNameTextAfterDelay());
        }
    }

    public void ClearCookingSlots()
    {
        foreach (CookingSlot slot in cookingSlots)
        {
            slot.ClearSlot();
        }
    }

    IEnumerator ClearDishNameTextAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        if (dishNameText != null)
        {
            dishNameText.text = "";
        }
    }
}