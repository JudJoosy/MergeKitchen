using UnityEngine;
using UnityEngine.UI;

public class IngredientUIButton : MonoBehaviour
{
    public string ingredientName;
    public Sprite ingredientIcon;

    public void OnClick()
    {
        CookingSlotManager.Instance.TryPlaceIngredient(ingredientName, ingredientIcon);
    }
}