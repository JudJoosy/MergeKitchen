using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public List<Recipe> recipes;

    public GameObject CheckRecipe(List<string> inputIngredients)
    {
        foreach (var recipe in recipes)
        {
            if (AreIngredientsEqual(inputIngredients, recipe.ingredientNames))
            {
                return recipe.dishPrefab;
            }
        }

        return null;
    }

    private bool AreIngredientsEqual(List<string> list1, List<string> list2)
    {
        if (list1.Count != list2.Count)
            return false;

        List<string> temp1 = new List<string>(list1);
        List<string> temp2 = new List<string>(list2);

        temp1.Sort();
        temp2.Sort();

        for (int i = 0; i < temp1.Count; i++)
        {
            if (temp1[i] != temp2[i])
                return false;
        }

        return true;
    }
}
