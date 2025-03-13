using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
// [Lopez, Judith]
*/

public class InventoryManager : MonoBehaviour
{
	public Transform[] inventorySlots; //Assign slots in Inspector
	public GameObject saltPrefab, pepperPrefab; // Assign prefabs in inspector

	private void Start()
	{
		List<string> mergedIngredients = MergeManager.Instance.GetMergedIngredients();

		foreach (string ingredient in mergedIngredients)
		{
			SpawnInInventory(ingredient);
		}

		MergeManager.Instance.ClearMergedIngredients(); // Clear after spawning
	}

	void SpawnInInventory(string ingredient)
	{
		GameObject prefabToSpawn = null;

		switch (ingredient)
		{
			case "Salt":
				prefabToSpawn = saltPrefab;
				break;
			case "Pepper":
				prefabToSpawn = pepperPrefab;
				break;
		}

		if (prefabToSpawn != null)
		{
			foreach (Transform slot in inventorySlots)
			{
				if (slot.childCount == 0) // Find an empty slot
				{
					Instantiate(prefabToSpawn, slot.position, Quaternion.identity, slot);
					break;
				}
			}
		}
	}
}
