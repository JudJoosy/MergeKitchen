using UnityEngine;

public class DishManager : MonoBehaviour
{
    // Attempt to make a dish
    public void MakeDish(Ingredient[] ingredients)
    {
        int totalDishCost = 0;

        // Calculate the total cost of all ingredients used
        foreach (var ingredient in ingredients)
        {
            totalDishCost += ingredient.cost; // Sum up the cost of each ingredient
        }

        // Deduct money based on the total cost of the ingredients
        if (CurrencyManager.Instance.SpendMoney(totalDishCost))
        {
            Debug.Log("Dish made successfully!");
            RewardPlayerForDish(); // Reward the player for making a successful dish
        }
        else
        {
            Debug.Log("Not enough money to make the dish!");
        }
    }

    // Reward the player when a dish is made
    private void RewardPlayerForDish()
    {
        int rewardAmount = 500;  // Reward for making a dish
        CurrencyManager.Instance.AddMoney(rewardAmount);
        Debug.Log($"Player rewarded with {rewardAmount} money!");
    }
}