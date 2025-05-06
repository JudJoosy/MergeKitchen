using UnityEngine;

public class DishManager : MonoBehaviour
{
    // This method is called after a recipe has matched
    public void MakeDish(Ingredient[] ingredients)
    {
        int totalDishCost = 0;

        foreach (var ingredient in ingredients)
        {
            totalDishCost += ingredient.cost;
        }

        // Spend money for ingredients (optional - depends on your design)
        if (CurrencyManager.Instance.SpendMoney(totalDishCost))
        {
            Debug.Log("Dish made successfully!");
            RewardPlayerForDish();
        }
        else
        {
            Debug.Log("Not enough money to make the dish.");
        }
    }

    private void RewardPlayerForDish()
    {
        int rewardAmount = 500; // You can scale this with difficulty later
        CurrencyManager.Instance.AddMoney(rewardAmount);
        Debug.Log($"Player rewarded with ${rewardAmount}!");
    }
}