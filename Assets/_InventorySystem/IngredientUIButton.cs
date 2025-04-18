using UnityEngine;

public class IngredientUIButton : MonoBehaviour
{
    public GameObject ingredientPrefab;
    public CookingSlot[] cookingSlots;

    public void OnClick_AddIngredient()
    {
        foreach (CookingSlot slot in cookingSlots)
        {
            if (slot.IsEmpty)
            {
                slot.SetIngredient(ingredientPrefab);
                break;
            }
        }
    }
}