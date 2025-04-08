using UnityEngine;
using UnityEngine.UI;  // Make sure to use the UI namespace

public class CraftSlot : MonoBehaviour
{
    public Image slotImage;  // Reference to the Image component that will show the ingredient
    private string currentIngredient;

    void Start()
    {
        if (slotImage == null)
        {
            // Try to find the Image component on the same GameObject if not assigned
            slotImage = GetComponent<Image>();
        }
        ClearSlot();  // Ensure the slot is clear at the start
    }

    // Check if the slot is empty
    public bool IsEmpty()
    {
        return string.IsNullOrEmpty(currentIngredient);
    }

    // Set the ingredient in the slot
    public void SetIngredient(string ingredientName, Sprite ingredientSprite)
    {
        currentIngredient = ingredientName;  // Store the name of the ingredient (you can use this for logic)
        slotImage.sprite = ingredientSprite;  // Set the sprite of the ingredient
        slotImage.enabled = true;  // Enable the image component to make it visible
    }

    // Clear the slot (called when the ingredient is removed or the slot is empty)
    public void ClearSlot()
    {
        currentIngredient = string.Empty;
        slotImage.sprite = null;  // Remove the sprite from the slot
        slotImage.enabled = false;  // Disable the image component to hide it
    }

    // Get the ingredient name from the slot
    public string GetIngredientName()
    {
        return currentIngredient;
    }
}