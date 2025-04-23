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

        DishData result = recipeManager.TryMakeDish(currentIngredients);

        if (result != null)
        {
            ShowDishName(result.dishName);
            SpawnDishModel(result.dishPrefab);
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

    void ShowDishName(string dishName)
    {
        if (dishNameText != null)
        {
            dishNameText.text = "You made: " + dishName;
            StartCoroutine(ClearDishNameTextAfterDelay());
        }
    }

    void SpawnDishModel(GameObject prefab)
    {
        foreach (Transform child in dishSpawnPoint)
        {
            Destroy(child.gameObject);
        }

        if (prefab != null)
        {
            GameObject spawnedDish = Instantiate(prefab, dishSpawnPoint.position, dishSpawnPoint.rotation, dishSpawnPoint);
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