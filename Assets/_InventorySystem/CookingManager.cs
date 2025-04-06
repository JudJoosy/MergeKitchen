
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    public TextMeshProUGUI dishResultText;
    private List<string> selectedIngredients = new List<string>();
    private Dictionary<HashSet<string>, string> recipes = new Dictionary<HashSet<string>, string>(HashSetComparer.Instance);

    void Start()
    {
        // Define known recipes (order-independent)
        recipes.Add(new HashSet<string> { "salt", "pepper" }, "Salt and Pepper Dish");
        recipes.Add(new HashSet<string> { "salt", "pepper", "thyme" }, "Fancy Salt and Pepper Dish");
        recipes.Add(new HashSet<string> { "thyme", "onion", "garlic" }, "Somewhat Holy Trinity Dish");
    }

    public void TryAddIngredient(string ingredient)
    {
        if (selectedIngredients.Contains(ingredient)) return;

        selectedIngredients.Add(ingredient);
        Debug.Log("Added ingredient: " + ingredient);

        if (selectedIngredients.Count >= 2)
        {
            CookDish();
        }
    }

    void CookDish()
    {
        var ingredientSet = new HashSet<string>(selectedIngredients);
        string resultDish = "Unknown Dish";

        foreach (var recipe in recipes)
        {
            if (recipe.Key.SetEquals(ingredientSet))
            {
                resultDish = recipe.Value;
                break;
            }
        }

        ShowDishResult(resultDish);
        selectedIngredients.Clear();
    }

    void ShowDishResult(string dishName)
    {
        dishResultText.gameObject.SetActive(true);
        dishResultText.text = $"You made: {dishName}!";
        Debug.Log($"You made: {dishName}!");
        Invoke(nameof(HideDishResult), 2f);
    }

    void HideDishResult()
    {
        dishResultText.gameObject.SetActive(false);
    }
}

public class HashSetComparer : IEqualityComparer<HashSet<string>>
{
    public static readonly HashSetComparer Instance = new HashSetComparer();

    public bool Equals(HashSet<string> x, HashSet<string> y)
    {
        return x.SetEquals(y);
    }

    public int GetHashCode(HashSet<string> obj)
    {
        int hash = 0;
        foreach (var item in obj.OrderBy(i => i))
        {
            hash ^= item.GetHashCode();
        }
        return hash;
    }
}