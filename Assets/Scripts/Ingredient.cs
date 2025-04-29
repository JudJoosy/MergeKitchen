using UnityEngine;

public enum IngredientType
{
    Spice,
    Vegetable,
    Meat,
    Fruit
}

public class Ingredient : MonoBehaviour
{
    public string ingredientName;
    public Sprite ingredientSprite;   // The sprite to represent the ingredient in the UI (if needed)
    public IngredientType ingredientType;  // Enum type for ingredient type
    public int quantity = 1;  // Quantity of the ingredient (default 1)
    public Sprite icon;  // Add this line to define the icon for the ingredient

    private void OnTriggerEnter(Collider other)
    {
        Ingredient otherIngredient = other.GetComponent<Ingredient>();

        if (otherIngredient == null)
        {
            Debug.LogError("The other collider does not contain an Ingredient.");
            return;
        }

        // Proceed with merging ingredients
        MergeIngredients(otherIngredient);
    }

    private void MergeIngredients(Ingredient otherIngredient)
    {
        if (otherIngredient == null)
        {
            Debug.LogError("Other ingredient is null during merge.");
            return;
        }

        // Ensure both ingredients have names
        if (string.IsNullOrEmpty(ingredientName) || string.IsNullOrEmpty(otherIngredient.ingredientName))
        {
            Debug.LogError("One or both ingredients have no name.");
            return;
        }

        // Check if both ingredients are of the same type and name
        if (ingredientType == otherIngredient.ingredientType && ingredientName == otherIngredient.ingredientName)
        {
            // Optionally, check if quantities exceed a certain limit
            if (quantity >= 100) // Example of a maximum quantity limit
            {
                Debug.LogWarning($"Maximum quantity reached for {ingredientName}, cannot merge further.");
                return;
            }

            // Example of merging the ingredients by combining their quantities
            Debug.Log($"Merging {ingredientName} (Quantity: {quantity}) with {otherIngredient.ingredientName} (Quantity: {otherIngredient.quantity})");

            // Combine quantities
            quantity += otherIngredient.quantity;

            // Optionally destroy the other ingredient after merging
            Destroy(otherIngredient.gameObject);

            // Optional: Check if merging results in a limit or a special state for the ingredient
            // For example, when merging two vegetables it can result in a "cooked" vegetable or another form of ingredient.
        }
        else
        {
            Debug.LogWarning("Ingredients are not the same type or name, cannot merge.");
        }
    }
}