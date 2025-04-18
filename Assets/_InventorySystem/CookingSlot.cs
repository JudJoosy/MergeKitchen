using TMPro; // Add this if you're using TextMeshPro
using UnityEngine;

public class CookingSlot : MonoBehaviour
{
    public string ingredient;  // Store the ingredient's name
    public TextMeshProUGUI ingredientText;  // Reference to the TMP component

    // This method will be used to set the ingredient in the cooking slot
    public void SetIngredient(string ingredient)
    {
        if (string.IsNullOrEmpty(ingredient)) return;  // Avoid setting empty ingredients
        this.ingredient = ingredient;

        // Update the TMP text with the ingredient name
        if (ingredientText != null)
        {
            ingredientText.text = ingredient;  // Display the ingredient name in TMP text
        }
        else
        {
            Debug.LogError("Ingredient TextMeshProUGUI not assigned on " + gameObject.name);
        }
    }

    // Check if the slot is empty
    public bool IsEmpty()
    {
        return string.IsNullOrEmpty(ingredient);
    }
}