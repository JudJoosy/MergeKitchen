using UnityEngine;

public class DishManager : MonoBehaviour
{
    public void MakeDish(Ingredient[] ingredients)
    {
        int totalDishCost = 0;

        foreach (var ingredient in ingredients)
        {
            Debug.Log($"Using ingredient: {ingredient.displayName}, cost: {ingredient.cost}");
            totalDishCost += ingredient.cost;
        }

        bool spent = CurrencyManager.Instance.SpendMoney(totalDishCost);
        Debug.Log($"Trying to spend {totalDishCost}. Success: {spent}");

        if (spent)
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
        Debug.Log($"Rewarding player with {rewardAmount}!");
        CurrencyManager.Instance.AddMoney(rewardAmount);
    }
}
