using UnityEngine;

[System.Serializable]
public class Ingredient : MonoBehaviour
{
    public string displayName;  // Ingredient name, e.g., "Salt"
    public Sprite ingredientSprite; // Ingredient image
    public int quantity = 1;     // Quantity of the ingredient
    public int cost;             // Cost of the ingredient
    public Sprite icon;          // Icon to show in the inventory or UI

    // This will trigger when ingredients collide (for merging)
    private void OnTriggerEnter(Collider other)
    {
        Ingredient otherIngredient = other.GetComponent<Ingredient>();
        if (otherIngredient == null) return;

        if (displayName == otherIngredient.displayName)
        {
            quantity += otherIngredient.quantity;
            Destroy(otherIngredient.gameObject);
        }
    }
}