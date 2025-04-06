using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform inventoryPanel;
    public CookingManager cookingManager;

    void Start()
    {
        IngredientDataTransfer.collectedIngredients = new List<string> { "salt", "pepper" };

        CreateInventorySlots();
    }


    public void CreateInventorySlots()
    {
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (string ing in IngredientDataTransfer.collectedIngredients)
        {
            GameObject slot = Instantiate(slotPrefab, inventoryPanel);

            slot.GetComponent<InventorySlot>().Setup(ing, cookingManager);
        }

        Debug.Log("Inventory slots created.");
    }
}