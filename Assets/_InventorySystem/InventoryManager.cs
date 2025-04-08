using UnityEngine;
using System.Collections.Generic;  // Add this to use Dictionary and other generic collections

public class InventoryManager : MonoBehaviour
{
    public InventorySlotUI[] slots; // Assign 5 in inspector
    public Sprite[] ingredientSprites; // Match names with keys in inventory
    public string[] ingredientNames; // Matches with sprites 1:1

    private Dictionary<string, int> ingredientCounts = new Dictionary<string, int>(); // Dictionary to hold ingredient counts
    private Dictionary<string, Sprite> spriteLookup = new Dictionary<string, Sprite>(); // Dictionary to hold ingredient sprites

    void OnEnable()
    {
        // Create sprite lookup
        for (int i = 0; i < ingredientNames.Length; i++)
        {
            spriteLookup[ingredientNames[i]] = ingredientSprites[i];
        }

        // Load inventory from a game-wide tracker
        ingredientCounts = IngredientDatabase.Instance.GetInventory(); // This needs to persist between scenes
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
