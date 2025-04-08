using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    public CraftSlot[] craftingSlots;
    public Transform resultSpawnPoint;
    public float resultDisplayTime = 3f;

    public GameObject saltAndPepperPrefab;
    public GameObject fancySaltAndPepperPrefab;
    public GameObject holyTrinityPrefab;

    private Dictionary<HashSet<string>, GameObject> recipeBook;

    void Start()
    {
        recipeBook = new Dictionary<HashSet<string>, GameObject>(HashSetComparer<string>.Instance)
        {
            { new HashSet<string> { "salt", "pepper" }, saltAndPepperPrefab },
            { new HashSet<string> { "salt", "pepper", "thyme" }, fancySaltAndPepperPrefab },
            { new HashSet<string> { "thyme", "onion", "garlic" }, holyTrinityPrefab },
        };
    }

    public void TryAddIngredient(string ingredientName, Sprite sprite)
    {
        foreach (CraftSlot slot in craftingSlots)
        {
            if (slot.IsEmpty())
            {
                slot.SetIngredient(ingredientName, sprite);
                CheckRecipe();
                return;
            }
        }

        Debug.Log("All crafting slots are full.");
    }

    public void RemoveIngredient(string ingredientName)
    {
        foreach (CraftSlot slot in craftingSlots)
        {
            if (!slot.IsEmpty() && slot.GetIngredientName() == ingredientName)
            {
                slot.Clear();
                Debug.Log("Removed ingredient: " + ingredientName);
                return;
            }
        }

        Debug.Log("Ingredient not found in crafting slots.");
    }

    private void CheckRecipe()
    {
        HashSet<string> currentIngredients = new HashSet<string>();

        foreach (CraftSlot slot in craftingSlots)
        {
            if (!slot.IsEmpty())
                currentIngredients.Add(slot.GetIngredientName());
        }

        foreach (var recipe in recipeBook)
        {
            if (recipe.Key.SetEquals(currentIngredients))
            {
                Debug.Log("Valid recipe found!");
                SpawnResult(recipe.Value);
                ClearCraftingSlots();
                return;
            }
        }

        Debug.Log("No valid recipe found.");
    }

    private void SpawnResult(GameObject resultPrefab)
    {
        GameObject result = Instantiate(resultPrefab, resultSpawnPoint.position, Quaternion.identity);
        Destroy(result, resultDisplayTime);
    }

    public void ClearCraftingSlots()
    {
        foreach (CraftSlot slot in craftingSlots)
        {
            slot.Clear();
        }
    }
}
