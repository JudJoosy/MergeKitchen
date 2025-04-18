using UnityEngine;
using UnityEngine.UI;

public class CookingSlot : MonoBehaviour
{
    [SerializeField] private Image ingredientImage;
    private string ingredientName;

    public void SetIngredient(string name, Sprite sprite)
    {
        ingredientName = name;
        ingredientImage.sprite = sprite;
        ingredientImage.enabled = true;
    }

    public void ClearSlot()
    {
        ingredientName = null;
        ingredientImage.sprite = null;
        ingredientImage.enabled = false;
    }

    public string GetIngredientName()
    {
        return ingredientName;
    }

    public bool HasIngredient()
    {
        return !string.IsNullOrEmpty(ingredientName);
    }
}