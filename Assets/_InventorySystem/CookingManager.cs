using UnityEngine;

public class CookingManager : MonoBehaviour
{
    // Singleton instance
    public static CookingManager Instance { get; private set; }

    // Dish Prefabs
    public GameObject saltAndPepperDishPrefab;
    public GameObject fancySaltAndPepperDishPrefab;
    public GameObject holyTrinityDishPrefab;

    // Reference to result slot (where the dish will spawn in the scene)
    public Transform resultSlot;

    private CraftSlot[] craftSlots;

    // Ensure only one instance of CookingManager exists
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
            return;
        }

        Instance = this; // Set the instance to this object
    }

    void Start()
    {
        // Find all CraftSlots in the scene (your empty slots for ingredients)
        craftSlots = FindObjectsOfType<CraftSlot>();

        // Debug to check if resultSlot is correctly assigned
        if (resultSlot == null)
        {
            Debug.LogError("Result Slot is not assigned in the Inspector!");
        }
    }

    // Check for the recipe based on the ingredients in the craft slots
    public void CheckForRecipe()
    {
        string[] ingredients = new string[craftSlots.Length];

        // Gather all ingredient names from the slots
        for (int i = 0; i < craftSlots.Length; i++)
        {
            ingredients[i] = craftSlots[i].GetIngredientName();  // Get ingredient names from slots
        }

        // Debug to show which ingredients are in the slots
        Debug.Log("Ingredients in slots: " + string.Join(", ", ingredients));

        // Check the combination of ingredients and spawn the dish
        string dish = GetDishFromIngredients(ingredients);
        
        if (!string.IsNullOrEmpty(dish))
        {
            SpawnDish(dish);  // Spawn the dish if it's a valid combination
        }
        else
        {
            Debug.Log("Invalid combination.");
        }
    }

    // This method maps the ingredient combination to a dish
    public string GetDishFromIngredients(string[] ingredients)
    {
        // Check for each valid combination
        if (ingredients.Length == 2 && ingredients[0] == "Salt" && ingredients[1] == "Pepper")
        {
            return "SaltAndPepperDish";
        }
        else if (ingredients.Length == 3 && ingredients[0] == "Salt" && ingredients[1] == "Pepper" && ingredients[2] == "Thyme")
        {
            return "FancySaltAndPepperDish";
        }
        else if (ingredients.Length == 3 && ingredients[0] == "Thyme" && ingredients[1] == "Onion" && ingredients[2] == "Garlic")
        {
            return "HolyTrinityDish";
        }
        return string.Empty;  // Return empty if no match
    }

    // Spawn the dish based on the recipe
    private void SpawnDish(string dish)
    {
        GameObject dishPrefab = null;

        // Determine which dish prefab to spawn
        switch (dish)
        {
            case "SaltAndPepperDish":
                dishPrefab = saltAndPepperDishPrefab;
                break;
            case "FancySaltAndPepperDish":
                dishPrefab = fancySaltAndPepperDishPrefab;
                break;
            case "HolyTrinityDish":
                dishPrefab = holyTrinityDishPrefab;
                break;
            default:
                Debug.Log("Unknown dish: " + dish);
                return;
        }

        // Debug to check if dishPrefab is correctly assigned
        if (dishPrefab == null)
        {
            Debug.LogError("Dish prefab not assigned!");
            return;
        }

        // Instantiate the dish prefab at the result slot position
        Instantiate(dishPrefab, resultSlot.position, Quaternion.identity);

        // Debug to confirm the dish is being instantiated
        Debug.Log("Dish spawned: " + dish);
    }
}