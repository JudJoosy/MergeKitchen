using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{
    public Image icon;
    private string ingredientName = "";
    private bool isFilled = false;

    public void SetIngredient(string name, Sprite sprite)
    {
        ingredientName = name;
        icon.sprite = sprite;
        icon.enabled = true;
        isFilled = true;
    }

    public void Clear()
    {
        ingredientName = "";
        icon.sprite = null;
        icon.enabled = false;
        isFilled = false;
    }

    public bool IsEmpty()
    {
        return !isFilled;
    }

    public string GetIngredientName()
    {
        return ingredientName;
    }
}
