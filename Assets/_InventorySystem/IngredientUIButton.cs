using UnityEngine;
using UnityEngine.UI;

public class IngredientUIButton : MonoBehaviour
{
    public string ingredientName;
    public Sprite ingredientSprite;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        CookingSlotManager.Instance.TryPlaceIngredient(ingredientName, ingredientSprite);
    }
}