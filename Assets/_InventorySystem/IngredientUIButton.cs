using UnityEngine;
using UnityEngine.UI;

public class IngredientUIButton : MonoBehaviour
{
    public Button ingredientButton;
    public string ingredientName;

    void Start()
    {
        ingredientButton.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // Add the ingredient to the IngredientDatabase when the button is clicked
        IngredientDatabase.Instance.AddIngredient(ingredientName);
        Debug.Log("Ingredient Added: " + ingredientName);
    }
}
