using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform inventoryPanel;
    public CookingManager cookingManager;

    void Start()
    {
        // Add new ingredients (Thyme, Onion, and Garlic) here as well.
        IngredientDataTransfer.collectedIngredients = new List<string> { 
            "salt", 
            "pepper", 
            "thyme", 
            "onion", 
            "garlic"
        };

        CreateInventorySlots();
    }

    public void CreateInventorySlots()
    {
        // Clear any existing slots in the inventory
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        // Create a new slot for each ingredient
        foreach (string ing in IngredientDataTransfer.collectedIngredients)
        {
            GameObject slot = Instantiate(slotPrefab, inventoryPanel);
            slot.GetComponent<InventorySlot>().Setup(ing, cookingManager);
        }

        Debug.Log("Inventory slots created.");
    }
}