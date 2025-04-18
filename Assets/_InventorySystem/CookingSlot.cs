using UnityEngine;

public class CookingSlot : MonoBehaviour
{
    public Transform slotPoint; // Point where the ingredient will spawn
    public GameObject currentIngredient;

    public bool IsEmpty => currentIngredient == null;

    public void SetIngredient(GameObject ingredientPrefab)
    {
        if (!IsEmpty)
            return;

        GameObject newIngredient = Instantiate(ingredientPrefab, slotPoint.position, Quaternion.identity);
        newIngredient.transform.SetParent(slotPoint);
        currentIngredient = newIngredient;
    }

    public string GetIngredientName()
    {
        return currentIngredient != null ? currentIngredient.name.Replace("(Clone)", "").Trim() : "";
    }

    public void ClearIngredient()
    {
        if (currentIngredient != null)
            Destroy(currentIngredient);
        currentIngredient = null;
    }
}