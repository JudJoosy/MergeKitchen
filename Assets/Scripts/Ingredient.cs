using UnityEngine;

[System.Serializable]
public class Ingredient : MonoBehaviour
{
    public string displayName;  // Renamed to avoid conflict with Object.name
    public Sprite ingredientSprite;
    public int quantity = 1;
    public Sprite icon;
    public int cost;

    private void OnTriggerEnter(Collider other)
    {
        Ingredient otherIngredient = other.GetComponent<Ingredient>();
        if (otherIngredient == null) return;

        if (displayName == otherIngredient.displayName)
        {
            quantity += otherIngredient.quantity;
            Destroy(otherIngredient.gameObject);
        }
    }
}