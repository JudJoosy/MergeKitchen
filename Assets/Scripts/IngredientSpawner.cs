using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
	public GameObject[] ingredientPrefabs;
	public int maxIngredientCount = 10;
	public float spawnInterval = 3f;
	public Vector3 spawnAreaSize = new Vector3(5f, 5f, 5f);
	public float minSpacing = 1.5f;
	public static List<string> savedIngredients = new List<string>();
	
	private List<GameObject> spawnedIngredients = new List<GameObject>();
	private List<Vector3> usedPositions = new List<Vector3>();

	void Start()
	{
		 StartCoroutine(SpawnLoop()); // Start continuous spawning
		 Debug.Log("Ingredient Spawner Started");
	}

	void SaveIngredients()
	{
		savedIngredients.Clear();
		foreach (Ingredient ingredient in FindObjectsOfType<Ingredient>())
		{
			savedIngredients.Add(ingredient.ingredientType);
		}
	}

	void LoadIngredients()
	{
		foreach (string ingredient in savedIngredients)
		{
			// Instantiate ingredient using stored data
		}
	}

	IEnumerator SpawnLoop()
	{
		while (true) // Infinite loop for continuous spawning
		{
			if (spawnedIngredients.Count < maxIngredientCount)
			{
				SpawnIngredients();
			}

			yield return new WaitForSeconds(spawnInterval); // Wait before next spawn

			if (spawnedIngredients.Count >= maxIngredientCount)
			{
				 Destroy(spawnedIngredients[0]); // Remove the oldest ingredient
				 spawnedIngredients.RemoveAt(0);
			}
		}
	}

	void SpawnIngredients()
	{
		Vector3 spawnPosition = GetRandomPosition();

		if (spawnPosition != Vector3.zero)
		{
			int randomIndex = Random.Range(0, ingredientPrefabs.Length);
			GameObject ingredient = Instantiate(ingredientPrefabs[randomIndex], spawnPosition, Quaternion.identity);
			spawnedIngredients.Add(ingredient); // Track new ingredient

			Ingredient ingredientScript = ingredient.GetComponent<Ingredient>();
			if (ingredientScript != null)
			{
				ingredientScript.ingredientType = ingredientPrefabs[randomIndex].name;
			}
		}
	}

	void OnEnable()
	{
		SpawnIngredients();
	}

	void Awake()
	{
		SpawnIngredients();
		DontDestroyOnLoad(gameObject);
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
}
