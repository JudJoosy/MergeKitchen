using UnityEngine;
using TMPro; // For using TextMeshPro if needed
using System.Collections.Generic; // Add this line

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(); // Use List<>
    public RecipeManager recipeManager;

    // Start is called before the first frame update
    private void Start()
    {
        PopulateUI();
    }

    // Populate the UI with the ingredients in the inventory slots
    private void PopulateUI()
    {
        foreach (var slot in inventorySlots)
        {
            if (slot != null)
            {
                // Example ingredient name and sprite for testing
                string ingredientName = "Salt";  // Replace with actual ingredient name
                Sprite ingredientSprite = null;  // Replace with actual ingredient sprite

                // Set the ingredient and sprite for each slot
                slot.SetIngredient(ingredientName, ingredientSprite);
            }
            else
            {
                Debug.LogError("Inventory Slot is not assigned!");
            }
        }
    }
}