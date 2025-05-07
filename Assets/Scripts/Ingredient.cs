using UnityEngine;

[System.Serializable]
public class Ingredient : MonoBehaviour
{
    public string displayName;      // Ingredient name, e.g., "Salt"
    public Sprite ingredientSprite; // Ingredient image (sprite)
    public int quantity = 1;        // Quantity of the ingredient
    public int shopCost;            // Cost of the ingredient in the shop (to buy or unlock)
    public int cookingValue;        // Cost or value of the ingredient when used in a dish
    public Sprite icon;             // Icon to show in the inventory or UI

    // Get the ingredient's display name (can be used for UI purposes)
    public string GetIngredientName()
    {
        return displayName;
    }

    // Handle merging of ingredients (can be triggered by colliders)
    private void OnTriggerEnter(Collider other)
    {
        Ingredient otherIngredient = other.GetComponent<Ingredient>();
        if (otherIngredient == null) return;

        // Check if the ingredients are of the same type and merge them
        if (displayName == otherIngredient.displayName)
        {
            quantity += otherIngredient.quantity;
            Destroy(otherIngredient.gameObject);
        }
    }

    // Optional: Method to return the ingredient's cost (can be used for display)
    public string GetShopCostDisplay()
    {
        return "Price: $" + shopCost.ToString();
    }

    // Optional: Method to return the cooking value cost (can be used in cooking-related UI)
    public string GetCookingCostDisplay()
    {
        return "Cooking Cost: $" + cookingValue.ToString();
    }
}