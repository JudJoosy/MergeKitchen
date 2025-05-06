using UnityEngine;
using UnityEngine.UI;

public class IngredientUIButton : MonoBehaviour
{
    [Header("Ingredient Info")]
    public string ingredientName;
    public Image ingredientIcon;

    // Called when the player clicks this UI button
    public void OnClick()
    {
        if (CookingSlotManager.Instance != null)
        {
            if (!string.IsNullOrEmpty(ingredientName) && ingredientIcon != null)
            {
                CookingSlotManager.Instance.TryPlaceIngredient(ingredientName, ingredientIcon.sprite);
            }
            else
            {
                Debug.LogWarning("Ingredient name or icon is not assigned.");
            }
        }
        else
        {
            Debug.LogError("CookingSlotManager.Instance is null! Make sure there's a CookingSlotManager in the scene.");
        }
    }
}