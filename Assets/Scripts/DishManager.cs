using UnityEngine;
using System.Collections.Generic;

public class DishManager : MonoBehaviour
{
    public void MakeDish(Ingredient[] ingredients)
    {
        if (ingredients == null || ingredients.Length == 0)
        {
            Debug.LogWarning("No ingredients provided to MakeDish.");
            return;
        }

        int totalDishCost = 0;
        List<string> ingredientNames = new List<string>();

        foreach (var ingredient in ingredients)
        {
            if (ingredient == null) continue;

            totalDishCost += ingredient.cost;
            ingredientNames.Add(ingredient.displayName); // FIXED LINE
            Debug.Log($"Ingredient used: {ingredient.displayName} with cost {ingredient.cost}");
        }

        Debug.Log($"Attempting to spend {totalDishCost}");

        if (CurrencyManager.Instance == null)
        {
            Debug.LogError("CurrencyManager.Instance is null!");
            return;
        }

        if (CurrencyManager.Instance.SpendMoney(totalDishCost))
        {
            Debug.Log("Dish made successfully!");
            RewardPlayerForDish();
        }
        else
        {
            Debug.Log("Not enough money to make the dish!");
        }
    }

    private void RewardPlayerForDish()
    {
        int rewardAmount = 500;
        CurrencyManager.Instance.AddMoney(rewardAmount);
        Debug.Log($"Player rewarded with {rewardAmount} money!");
    }
}