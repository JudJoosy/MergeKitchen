using UnityEngine;

[System.Serializable]
public class Ingredient : MonoBehaviour
{
    public string displayName;      // Ingredient name, e.g., "Salt"
    public Sprite ingredientSprite; // Ingredient image (sprite)
    public int quantity = 1;        // Quantity of the ingredient
    public int cost;                // Cost of the ingredient
    public Sprite icon;             // Icon to show in the inventory or UI

    // This method is triggered when ingredients collide (for merging)
    private void OnTriggerEnter(Collider other)
    {
        Ingredient otherIngredient = other.GetComponent<Ingredient>();
        if (otherIngredient == null) return;

        // Check if the two ingredients are the same
        if (displayName == otherIngredient.displayName)
        {
            // Merge by adding the quantities together
            quantity += otherIngredient.quantity;

            // Destroy the other ingredient object after merging
            Destroy(otherIngredient.gameObject);
        }
    }
}