using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().name == "Merge_Scene")
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Merge_Scene")
        {
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Ingredient Spawner Ready for Place button");
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Merge_Scene")
        {
            Destroy(gameObject);
        }
    }

    public void PlaceIngredient()
    {
        if (spawnedIngredients.Count < maxIngredientCount)
        {
            SpawnIngredient();
        }
        else
        {
            Debug.Log("Max ingredient limit reached!");
        }
    }

    void SpawnIngredient()
    {
        Vector3 spawnPosition = GetRandomPosition();

        if (spawnPosition == Vector3.zero)
        {
            Debug.LogWarning("No valid position found.");
            return;
        }

        List<GameObject> unlockedPrefabs = new List<GameObject>();
        foreach (var prefabCandidate in ingredientPrefabs)
        {
            if (UnlockManager.IsIngredientUnlocked(prefabCandidate.name))
            {
                unlockedPrefabs.Add(prefabCandidate);
            }
        }

        if (unlockedPrefabs.Count == 0)
        {
            Debug.LogWarning("No unlocked ingredients to spawn.");
            return;
        }

        int index = Random.Range(0, unlockedPrefabs.Count);
        GameObject selectedPrefab = unlockedPrefabs[index];

        GameObject ingredient = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        spawnedIngredients.Add(ingredient);

        Ingredient ingredientScript = ingredient.GetComponent<Ingredient>();
        if (ingredientScript != null)
        {
            ingredientScript.displayName = selectedPrefab.name;
        }
    }

    void SaveIngredients()
    {
        savedIngredients.Clear();
        foreach (Ingredient ingredient in FindObjectsOfType<Ingredient>())
        {
            savedIngredients.Add(ingredient.displayName);
        }
    }

    void LoadIngredients()
    {
        foreach (string ingredientName in savedIngredients)
        {
            SpawnIngredientFromSavedData(ingredientName);
        }
    }

    void SpawnIngredientFromSavedData(string ingredientName)
    {
        GameObject ingredientPrefab = null;
        foreach (var prefabOption in ingredientPrefabs)
        {
            if (prefabOption.name == ingredientName)
            {
                ingredientPrefab = prefabOption;
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
                ingredientScript.displayName = ingredientName;
                spawnedIngredients.Add(ingredient);
            }
        }
        else
        {
            Debug.LogError("No prefab found for ingredient: " + ingredientName);
        }
    }

    Vector3 GetRandomPosition()
    {
        for (int attempts = 0; attempts < 10; attempts++)
        {
            float x = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
            float y = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);
            float z = Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);
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
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}