using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    private Dictionary<HashSet<string>, string> recipes = new Dictionary<HashSet<string>, string>(new HashSetComparer());

    void Start()
    {
        // Initial recipes
        recipes.Add(new HashSet<string> { "Salt", "Pepper" }, "Salt & Pepper Dish");
        recipes.Add(new HashSet<string> { "Salt", "Pepper", "Thyme" }, "Fancy Salt & Pepper Dish");
        recipes.Add(new HashSet<string> { "Thyme", "Onion", "Garlic" }, "Some What Holy Trinity Dish");
    }

    public string GetDish(List<string> ingredients)
    {
        HashSet<string> ingredientSet = new HashSet<string>(ingredients);

        foreach (var recipe in recipes)
        {
            if (recipe.Key.SetEquals(ingredientSet))
            {
                return recipe.Value;
            }
        }
        return "Unknown Dish";
    }

    // Helper class for comparing hashsets (recipes)
    private class HashSetComparer : IEqualityComparer<HashSet<string>>
    {
        public bool Equals(HashSet<string> x, HashSet<string> y)
        {
            return x.SetEquals(y);
        }

        public int GetHashCode(HashSet<string> obj)
        {
            int hash = 0;
            foreach (string item in obj)
            {
                 hash ^= item.GetHashCode();
            }
            return hash;
        }
    }
}
               