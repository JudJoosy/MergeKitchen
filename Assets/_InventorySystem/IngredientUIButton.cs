using UnityEngine;
using UnityEngine.UI;

public class IngredientUIButton : MonoBehaviour
{
    public string ingredientName;
    public Image ingredientIcon;

    // Called when the player clicks this UI button
    public void OnClick()
    {
        if (CookingSlotManager.Instance != null)
        {
            CookingSlotManager.Instance.TryPlaceIngredient(ingredientName, ingredientIcon.sprite);
        }
        else
        {
            Debug.LogWarning("CookingSlotManager.Instance is null!");
        }
    }
}