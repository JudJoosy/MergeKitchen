using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string ingredientName;
    public Sprite ingredientSprite;
    public int quantity = 1;
    public Sprite icon;

    private void OnTriggerEnter(Collider other)
    {
        Ingredient otherIngredient = other.GetComponent<Ingredient>();
        if (otherIngredient == null) return;

        if (ingredientName == otherIngredient.ingredientName)
        {
            quantity += otherIngredient.quantity;
            Destroy(otherIngredient.gameObject);
        }
    }
}