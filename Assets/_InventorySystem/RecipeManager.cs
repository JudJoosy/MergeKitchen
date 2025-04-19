using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    private Dictionary<HashSet<string>, string> recipes = new Dictionary<HashSet<string>, string>(HashSetComparer.Instance);

    private void Awake()
    {
        // Define your recipes
        recipes.Add(new HashSet<string> { "Salt", "Pepper" }, "Salt and pepper");
        recipes.Add(new HashSet<string> { "Salt", "Pepper", "Thyme" }, "Fancy Salt and pepper ");
        recipes.Add(new HashSet<string> { "Thyme", "Onion", "Garlic" }, "The holy trinity");
    }

    public string TryMakeDish(List<string> ingredients)
    {
        var ingredientSet = new HashSet<string>(ingredients);

        foreach (var recipe in recipes)
        {
            if (recipe.Key.SetEquals(ingredientSet))
            {
                return recipe.Value;
            }
        }

        return null;
    }

    // Custom comparer for HashSet
    private class HashSetComparer : IEqualityComparer<HashSet<string>>
    {
        public static readonly HashSetComparer Instance = new HashSetComparer();

        public bool Equals(HashSet<string> x, HashSet<string> y)
        {
            return x.SetEquals(y);
        }

        public int GetHashCode(HashSet<string> obj)
        {
            int hash = 0;
            foreach (string s in obj.OrderBy(e => e))
            {
                hash ^= s.GetHashCode();
            }
            return hash;
        }
    }
}