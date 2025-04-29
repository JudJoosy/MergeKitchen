using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management
using System; // Needed for System.Enum

public class IngredientSpawnerController : MonoBehaviour
{
    public GameObject[] ingredientPrefabs;
    public int maxIngredientCount = 10;
    public Vector3 spawnAreaSize = new Vector3(5f, 5f, 5f);
    public float minSpacing = 1.5f;
    public static List<string> savedIngredients = new List<string>();

    private List<GameObject> spawnedIngredients = new List<GameObject>();
    private List<Vector3> usedPositions = new List<Vector3>();

    void Awake()
    {
        // Don't destroy the spawner in MergingScene, destroy in others
        if (SceneManager.GetActiveScene().name == "Merge_Scene") // Replace with your actual scene name
        {
            DontDestroyOnLoad(gameObject); // Keep the spawner in the MergingScene
        }
        else
        {
            Destroy(gameObject);  // Destroy the spawner if it's not in MergingScene
        }

        // Add scene loaded listener
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        // Only allow placing if we're in the MergingScene
        if (SceneManager.GetActiveScene().name != "Merge_Scene")
        {
            gameObject.SetActive(false);  // Disable the spawner in other scenes
        }
        else
        {
            Debug.Log("Ingredient Spawner Ready for Place button");
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ensure spawner is destroyed or disabled in other scenes
        if (scene.name != "Merge_Scene")
        {
            Destroy(gameObject);  // Destroy the spawner if the scene is not MergingScene
        }
    }

    // Public function to call from UI button
    public void PlaceIngredient()
    {
        if (spawnedIngredients.Count < maxIngredientCount)
        {
            SpawnIngredient();
        }
        else
        {
            Debug.Log("Max ingredient limit reached!");
            // Optionally, disable the button or show a message to the user
        }
    }

    void SpawnIngredient()
    {
        Vector3 spawnPosition = GetRandomPosition();

        if (spawnPosition != Vector3.zero)
        {
            int randomIndex = UnityEngine.Random.Range(0, ingredientPrefabs.Length);
            GameObject ingredient = Instantiate(ingredientPrefabs[randomIndex], spawnPosition, Quaternion.identity);
            spawnedIngredients.Add(ingredient); // Track new ingredient

            Ingredient ingredientScript = ingredient.GetComponent<Ingredient>();
            if (ingredientScript != null)
            {
                // Convert prefab name to IngredientType
                if (System.Enum.TryParse(ingredientPrefabs[randomIndex].name, out IngredientType ingredientType))
                {
                    ingredientScript.ingredientType = ingredientType;
                }
                else
                {
                    Debug.LogError("Invalid ingredient type name: " + ingredientPrefabs[randomIndex].name);
                }
            }
        }
        else
        {
            Debug.LogWarning("Failed to find a valid spawn position!");
        }
    }

    void SaveIngredients()
    {
        savedIngredients.Clear();
        foreach (Ingredient ingredient in FindObjectsOfType<Ingredient>())
        {
            savedIngredients.Add(ingredient.ingredientType.ToString()); // Save the ingredient type name
        }
    }

    void LoadIngredients()
    {
        foreach (string ingredient in savedIngredients)
        {
            // Instantiate ingredient using stored data (future feature)
            IngredientType ingredientType;
            if (Enum.TryParse(ingredient, out ingredientType))
            {
                // You will likely need to map the ingredient type to an actual prefab.
                // Here’s an example to spawn it back (assuming you have the mapping)
                SpawnIngredientFromSavedData(ingredientType);
            }
        }
    }

    void SpawnIngredientFromSavedData(IngredientType ingredientType)
    {
        // Find the prefab based on the saved ingredient type
        GameObject ingredientPrefab = null;
        foreach (var prefab in ingredientPrefabs)
        {
            if (prefab.name == ingredientType.ToString())
            {
                ingredientPrefab = prefab;
                break;
            }
        }

        if (ingredientPrefab != null)
        {
            Vector3 spawnPosition = GetRandomPosition();
            GameObject ingredient = Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);
            Ingredient ingredientScript = ingredient.GetComponent<Ingredient>();
            if (ingredientScript != null)
            {
                ingredientScript.ingredientType = ingredientType;
                spawnedIngredients.Add(ingredient);
            }
        }
        else
        {
            Debug.LogError("No prefab found for ingredient type: " + ingredientType.ToString());
        }
    }

    Vector3 GetRandomPosition()
    {
        for (int attempts = 0; attempts < 10; attempts++)
        {
            float x = UnityEngine.Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
            float y = UnityEngine.Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);
            float z = UnityEngine.Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);
            Vector3 randomPos = new Vector3(x, y, z);

            if (IsPositionValid(randomPos))
            {
                usedPositions.Add(randomPos);
                return randomPos;
            }
        }
        return Vector3.zero;
    }

    bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 usedPos in usedPositions)
        {
            if (Vector3.Distance(position, usedPos) < minSpacing)
            {
                return false;
            }
        }
        return true;
    }

    private void OnDestroy()
    {
        // Remove the scene listener when the object is destroyed to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}