using UnityEngine;

public class DishManager : MonoBehaviour
{
    // Attempt to make a dish using the provided ingredients
    public void MakeDish(Ingredient[] ingredients)
    {
        int totalDishCost = 0;

        // Calculate the total cost of all ingredients used
        foreach (var ingredient in ingredients)
        {
            totalDishCost += ingredient.cost;
        }

        // Log the total dish cost
        Debug.Log($"Total dish cost: ${totalDishCost}");

        // Spend money to make the dish
        if (CurrencyManager.Instance.SpendMoney(totalDishCost))
        {
            Debug.Log("Dish made successfully!");
            RewardPlayerForDish();  // Reward the player for making the dish
        }
        else
        {
            Debug.Log("Not enough money to make the dish.");
        }
    }

    // Reward the player for successfully making a dish
    private void RewardPlayerForDish()
    {
        int rewardAmount = 500;  // The reward for making a dish
        CurrencyManager.Instance.AddMoney(rewardAmount);
        Debug.Log($"Player rewarded with ${rewardAmount}!");  // Debug message
    }
}