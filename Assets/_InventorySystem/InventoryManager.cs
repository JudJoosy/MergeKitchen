using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlotUI[] slots;  // Assign the 5 inventory slots in the Inspector
    public Sprite[] ingredientSprites;  // The 2D sprites for the ingredients
    public string[] ingredientNames;  // Names of ingredients to match 1:1 with sprites

    private Dictionary<string, int> ingredientCounts = new Dictionary<string, int>();
    private Dictionary<string, Sprite> spriteLookup = new Dictionary<string, Sprite>();

    void Start()
    {
        // Initialize sprite lookup (name -> sprite)
        for (int i = 0; i < ingredientNames.Length; i++)
        {
            spriteLookup[ingredientNames[i]] = ingredientSprites[i];
        }

        // Get the current inventory from the IngredientDatabase
        ingredientCounts = IngredientDatabase.Instance.GetInventory();

        // Populate the UI with the ingredients
        PopulateUI();
    }

    void PopulateUI()
    {
        int index = 0;
        foreach (var entry in ingredientCounts)
        {
            if (index >= slots.Length) break;

            if (spriteLookup.ContainsKey(entry.Key))
            {
                slots[index].SetupSlot(entry.Key, spriteLookup[entry.Key], entry.Value);
                index++;
            }
        }

        // Clear any unused slots
        for (; index < slots.Length; index++)
        {
            slots[index].UpdateQuantity(0);
        }
    }
}
