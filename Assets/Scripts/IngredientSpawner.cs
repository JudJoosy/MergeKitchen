using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
	public GameObject[] ingredientPrefabs;
	public int ingredientCount = 5;
	public Vector2 spawnAreaSize = new Vector2(5f, 5f);
	public float minSpacing = 1.5f;
	public float spawnHeight = 1f;

	private List<Vector3> usedPositions = new List<Vector3>();

	void Start()
	{
		SpawnIngredients();
	}

	void SpawnIngredients()
	{
		for (int i = 0; i < ingredientCount; i++)
		{
			Vector3 spawnPosition = GetRandomPosition();

			if (spawnPosition != Vector3.zero)
			{
				int randomIndex = Random.Range(0, ingredientPrefabs.Length);
				GameObject ingredient = Instantiate(ingredientPrefabs[randomIndex], spawnPosition, Quaternion.identity);

				//Assign the ingredient type based on prefab name
				Ingredient ingredientScript = ingredient.GetComponent<Ingredient>();
				if (ingredientScript != null)
				{
					ingredientScript.ingredientType = ingredientPrefabs[randomIndex].name;
				}
			}
		}
	}

	Vector3 GetRandomPosition()
	{
		for (int attempts = 0; attempts < 10; attempts++)
		{
			float x = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
			float z = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);
			Vector3 randomPos = new Vector3(x, spawnHeight, 0);

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
