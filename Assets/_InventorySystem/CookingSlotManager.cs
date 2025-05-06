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
    public TMP_Text dishNameText;
    public List<DishData> dishPrefabs;

    private void Awake()
    {
        if (Instance == null)
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

        GameObject resultDish = recipeManager.TryMakeDish(currentIngredients);

        if (resultDish != null)
        {
            ShowDishName(resultDish.name);
            SpawnDishModel(resultDish);
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

    // ✅ MAKE SURE THIS IS PUBLIC AND SPELLING MATCHES
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

    void ShowDishName(string dishName)
    {
        if (dishNameText != null)
        {
            dishNameText.text = "You made: " + dishName;
            StartCoroutine(ClearDishNameTextAfterDelay());
        }
    }

    void SpawnDishModel(GameObject dishPrefab)
    {
        foreach (Transform child in dishSpawnPoint)
        {
            Destroy(child.gameObject);
        }

        if (dishPrefab != null)
        {
            GameObject spawnedDish = Instantiate(dishPrefab, dishSpawnPoint.position, dishSpawnPoint.rotation, dishSpawnPoint);
            spawnedDish.transform.localScale = Vector3.one;
        }
        else
        {
            Debug.LogWarning("Dish prefab is missing!");
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