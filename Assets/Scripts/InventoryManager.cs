using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
// [Lopez, Judith]
*/

public class InventoryManager : MonoBehaviour
{
	public Ingredient storedIngredient;  // The ingredient in this inventory slot
	public GameObject slotModel;  // Visual representation of the slot (optional)
	public List<Ingredient> inventory = new List<Ingredient>();  // List of ingredients in inventory
	public GameObject inventorySlotPrefab;  // Prefab for the inventory slot (UI element)
	public Transform inventoryParent;  // Parent to place inventory slots

	public InventorySlot[] inventorySlots;  // Array of inventory slots

	public static InventoryManager Instance;
    public List<IngredientData> inventoryItems = new List<IngredientData>();

	private void Awake()
    {
        Instance = this;
    }

    public void AddToInventory(IngredientData ingredient)
    {
        inventoryItems.Add(ingredient);
    }

    public void RemoveFromInventory(IngredientData ingredient)
    {
        inventoryItems.Remove(ingredient);
    }


	// Add a new ingredient to the inventory
	public void AddToInventory(Ingredient ingredient)
	{
		// Check if the ingredient already exists in the inventory
		var existingIngredient = inventory.Find(item => item.ingredientName == ingredient.ingredientName);
		if (existingIngredient != null)
		{
			// If it exists, increase the quantity
			existingIngredient.quantity++;
		}
		else
		{
			// If it doesn't exist, add it as a new ingredient
			inventory.Add(ingredient);
		}

		// Update the UI after adding the ingredient to inventory
		UpdateInventoryUI();
	}


	// Example function where SetIngredient might be called
	public void AddIngredientToSlot(Ingredient ingredient)
	{
		foreach (var slot in inventorySlots)
		{
			if (slot.storedIngredient == null) // Check if slot is empty
			{
				slot.SetIngredient(ingredient);  // Call the SetIngredient method to assign the ingredient
				break;
			}
		}
	}


	// Update the inventory UI
	void UpdateInventoryUI()
	{
		// Clear existing UI slots
		foreach (Transform child in inventoryParent)
		{
			Destroy(child.gameObject);
		}

		// Create new slots for each ingredient in the inventory
		foreach (Ingredient ingredient in inventory)
		{
			GameObject newSlot = Instantiate(inventorySlotPrefab, inventoryParent);
			newSlot.GetComponent<InventorySlot>().SetIngredient(ingredient);  // Set the ingredient in the slot
		}
	}
		
}
