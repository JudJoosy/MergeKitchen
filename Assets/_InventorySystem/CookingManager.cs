using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    private List<string> currentIngredients = new List<string>();

    public void TryAddIngredient(string ingredient)
    {
        currentIngredients.Add(ingredient);
        Debug.Log($"Added {ingredient} to current cooking list.");

        if (currentIngredients.Count >= 2)
        {
            CheckDish();
        }
    }


    void CheckDish()
    {
        string result = string.Join("+", currentIngredients);
        Debug.Log($"You made a dish with: {result}");

        currentIngredients.Clear();
    }
}