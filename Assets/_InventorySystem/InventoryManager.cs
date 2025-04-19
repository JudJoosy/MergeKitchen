using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(); // Assigned in Inspector
    public RecipeManager recipeManager;

    // Sample ingredient data (replace with real data or load dynamically)
    [System.Serializable]
    public class IngredientData
    {
        public string name;
        public Sprite sprite;
    }

    public List<IngredientData> initialIngredients; // Assign different ingredients in the Inspector

    private void Start()
    {
        PopulateUI();
    }

    private void PopulateUI()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (i < initialIngredients.Count)
            {
                var data = initialIngredients[i];
                inventorySlots[i].SetIngredient(data.name, data.sprite);
            }
            else
            {
                inventorySlots[i].ClearSlot(); // Clear empty slots
            }
        }
    }
}