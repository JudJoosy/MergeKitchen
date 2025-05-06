using UnityEngine;

public class DishManager : MonoBehaviour
{
    // Reference to the CurrencyManager
    private CurrencyManager currencyManager;

    private void Start()
    {
        // Ensure we have a reference to the CurrencyManager
        if (CurrencyManager.Instance != null)
        {
            currencyManager = CurrencyManager.Instance;
        }
        else
        {
            Debug.LogError("DishManager: CurrencyManager instance not found.");
        }
    }

    // Call this to make a dish from an array of ingredients
    public void MakeDish(Ingredient[] ingredients)
    {
        if (ingredients == null || ingredients.Length == 0)
        {
            Debug.LogWarning("DishManager: No ingredients provided.");
            return;
        }

        Debug.Log("Dish made successfully with " + ingredients.Length + " ingredients.");
        RewardPlayerForDish();
    }

    // Rewards the player for making a dish
    private void RewardPlayerForDish()
    {
        int rewardAmount = 500;

        if (currencyManager != null)
        {
            currencyManager.AddMoney(rewardAmount);
            Debug.Log($"Player rewarded with ${rewardAmount}. New balance: ${currencyManager.currentMoney}");
        }
        else
        {
            Debug.LogWarning("DishManager: CurrencyManager reference missing.");
        }
    }
}