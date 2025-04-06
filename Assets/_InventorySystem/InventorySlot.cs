using UnityEngine;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public string ingredientName;
    public CookingManager cookingManager;

    // Add public fields for each model
    public GameObject saltModel;
    public GameObject pepperModel;
    public GameObject thymeModel;
    public GameObject onionModel;
    public GameObject garlicModel;

    public GameObject ingredientModelHolder;  // Reference to the model holder in the prefab

    public void Setup(string name, CookingManager manager)
    {
        ingredientName = name;
        cookingManager = manager;

        // Update the text (if you have text for the ingredient)
        GetComponentInChildren<TextMeshProUGUI>().text = name;

        // Set the 3D model based on the ingredient
        Set3DModel(name);
    }

    private void Set3DModel(string ingredient)
    {
        // Destroy any old model before adding the new one
        foreach (Transform child in ingredientModelHolder.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate the correct 3D model based on the ingredient name
        GameObject modelPrefab = GetIngredientModelPrefab(ingredient);

        if (modelPrefab != null)
        {
            GameObject model = Instantiate(modelPrefab, ingredientModelHolder.transform);
            model.transform.localPosition = Vector3.zero;  // Adjust the position as needed
        }
    }

    private GameObject GetIngredientModelPrefab(string ingredient)
    {
        // Return the correct prefab based on the ingredient name
        switch (ingredient)
        {
            case "salt":
                return saltModel;
            case "pepper":
                return pepperModel;
            case "thyme":
                return thymeModel;
            case "onion":
                return onionModel;
            case "garlic":
                return garlicModel;
            default:
                return null;
        }
    }

    public void OnClick()
    {
        cookingManager.TryAddIngredient(ingredientName);
    }
}