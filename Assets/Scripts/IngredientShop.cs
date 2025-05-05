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
    }

    private void SpawnIngredient(string ingredientName)
    {
        // Replace this with actual spawning logic for the 3D model
        Debug.Log("Spawning ingredient: " + ingredientName);
    }
}
