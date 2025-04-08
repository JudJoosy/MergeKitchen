using UnityEngine;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public string ingredientName;
    public Sprite ingredientSprite;
    public CookingManager cookingManager;
    public GameObject highlightVisual;
    public TextMeshProUGUI countText;

    private int count = 0;
    private bool isSelected = false;

    public void Setup(string name, Sprite sprite, int quantity, CookingManager manager)
    {
        ingredientName = name;
        ingredientSprite = sprite;
        count = quantity;
        cookingManager = manager;

        GetComponentInChildren<TextMeshProUGUI>().text = name;
        countText.text = count.ToString();
        highlightVisual.SetActive(false);
    }

    public void UpdateCount(int newCount)
    {
        count = newCount;
        countText.text = count.ToString();
    }

    public void OnClick()
    {
        if (isSelected)
        {
            cookingManager.RemoveIngredient(ingredientName);
            highlightVisual.SetActive(false);
            isSelected = false;
        }
        else
        {
            cookingManager.TryAddIngredient(ingredientName, ingredientSprite);
            highlightVisual.SetActive(true);
            isSelected = true;
        }
    }
}
