using UnityEngine;
using UnityEngine.UI;

public class IngredientUIButton : MonoBehaviour
{
    public string ingredientName;
    public Sprite ingredientSprite;

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnIngredientClicked);
    }

    // When the ingredient button is clicked
    public void OnIngredientClicked()
    {
        // Find the first available craft slot and place the ingredient there
        CraftSlot[] craftSlots = FindObjectsOfType<CraftSlot>();

        foreach (CraftSlot slot in craftSlots)
        {
            if (slot.IsEmpty())  // Check if slot is empty
            {
                slot.SetIngredient(ingredientName, ingredientSprite);
                break;  // Stop once an empty slot is filled
            }
        }

        // Once all slots are filled, check for the recipe
        if (AreAllSlotsFilled(craftSlots))
        {
            CookingManager.Instance.CheckForRecipe();  // Call the method to check the recipe
        }
    }

    // Check if all slots are filled
    private bool AreAllSlotsFilled(CraftSlot[] craftSlots)
    {
        foreach (CraftSlot slot in craftSlots)
        {
            if (slot.IsEmpty())
            {
                return false;
            }
        }
        return true;
    }
}