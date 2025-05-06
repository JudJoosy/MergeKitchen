using UnityEngine;

public class IngredientShop : MonoBehaviour
{
    public IngredientDatabase ingredientDB;
    public Transform mergeArea;

    public void TryBuyIngredient(string ingredientName)
    {
        var ingredient = ingredientDB.GetIngredientByName(ingredientName);

        if (ingredient != null)
        {
            if (CurrencyManager.Instance.SpendMoney(ingredient.cost))
            {
                SpawnIngredient(ingredient.name);
            }
            else
            {
                Debug.Log("Not enough money to buy " + ingredient.name);
            }
        }
        else
        {
            Debug.LogWarning("Ingredient not found in database: " + ingredientName);
        }
    }

    private void SpawnIngredient(string ingredientName)
    {
        // You can later replace this with actual spawn logic
        Debug.Log("Spawning ingredient: " + ingredientName);
    }
}
