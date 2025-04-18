using UnityEngine;
using TMPro; // Assuming you are using TextMeshPro for UI elements

public class InventorySlot : MonoBehaviour
{
    public TMP_Text ingredientText; // Assuming you use TextMeshPro for ingredient names
    public SpriteRenderer spriteRenderer; // For showing ingredient sprite (or Image for UI)

    // Set the ingredient name and sprite for this inventory slot
    public void SetIngredient(string name, Sprite sprite)
    {
        if (ingredientText != null)
            ingredientText.text = name; // Set the ingredient name in the UI

        if (spriteRenderer != null)
            spriteRenderer.sprite = sprite; // Set the ingredient sprite
    }
}