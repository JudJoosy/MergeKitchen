using UnityEngine;
using UnityEngine.UI;

public class CookingSlot : MonoBehaviour
{
    public Image icon;
    private string ingredientName;

    public void SetIngredient(string name, Sprite sprite)
    {
        ingredientName = name;
        icon.sprite = sprite;
        icon.enabled = true;
    }

    public bool HasIngredient()
    {
        return !string.IsNullOrEmpty(ingredientName);
    }

    public string GetIngredientName()
    {
        return ingredientName;
    }

    public void ClearSlot()
    {
        ingredientName = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}