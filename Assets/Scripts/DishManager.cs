using UnityEngine;

public class DishManager : MonoBehaviour
{
    // Attempt to make a dish using the provided ingredients
    public void MakeDish(Ingredient[] ingredients)
    {
        int totalDishCost = 0;

        // Log the ingredients used and calculate the total cost
        foreach (var ingredient in ingredients)
        {
            Debug.Log($"Ingredient: {ingredient.ingredientName}, Cost: {ingredient.cost}");  // Log each ingredient
            totalDishCost += ingredient.cost;  // Sum the costs
        }

        Debug.Log($"Total dish cost: ${totalDishCost}");  // Log the total cost

        // Spend money to make the dish
        if (CurrencyManager.Instance.SpendMoney(totalDishCost))
        {
            Debug.Log("Dish made successfully!");
            RewardPlayerForDish();  // Reward the player for making the dish
        }
        else
        {
            Debug.Log("Not enough money to make the dish.");  // Log if not enough money
        }
    }

    // Reward the player for successfully making a dish
    private void RewardPlayerForDish()
    {
        int rewardAmount = 500;  // The reward for making a dish
        CurrencyManager.Instance.AddMoney(rewardAmount);  // Add reward money
        Debug.Log($"Player rewarded with ${rewardAmount}!");  // Log the reward
    }
}