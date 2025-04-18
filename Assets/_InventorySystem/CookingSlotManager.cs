using UnityEngine;

public class CookingSlotManager : MonoBehaviour
{
    public static CookingSlotManager Instance;

    public CookingSlot[] cookingSlots;

    private void Awake()
    {
        Instance = this;
    }

    public void TryPlaceIngredient(string ingredientName)
    {
        foreach (var slot in cookingSlots)
        {
            if (slot.IsEmpty())
            {
                slot.SetIngredient(ingredientName);
                break;
            }
        }
    }
}