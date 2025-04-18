using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public Sprite[] ingredientIcons;
    public string[] ingredientNames;

    void Start()
    {
        PopulateUI();
    }

    void PopulateUI()
    {
        for (int i = 0; i < inventorySlots.Length && i < ingredientNames.Length; i++)
        {
            inventorySlots[i].SetIngredient(ingredientNames[i], ingredientIcons[i]);
        }
    }
}