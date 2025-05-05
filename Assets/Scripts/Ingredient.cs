using UnityEngine;

[System.Serializable]
public class Ingredient : MonoBehaviour
{
    public string displayName;  // Renamed to avoid conflict with Object.name
    public Sprite ingredientSprite;
    public int quantity = 1;
    public Sprite icon;
    public int cost;

    // For merging in the MergeManager system
    public void MergeWith(Ingredient otherIngredient)
    {
        if (displayName == otherIngredient.displayName)
        {
            quantity += otherIngredient.quantity;
            Destroy(otherIngredient.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Optional, but if you want to handle merges using colliders, keep it
        Ingredient otherIngredient = other.GetComponent<Ingredient>();
        if (otherIngredient == null) return;

        // Merging happens if the ingredients match
        if (displayName == otherIngredient.displayName)
        {
            MergeWith(otherIngredient);  // Use the merge logic
        }
    }
}