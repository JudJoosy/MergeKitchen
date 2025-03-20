using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
// [Lopez, Judith]
*/

public class InventoryManager : MonoBehaviour
{
	public static InventoryManager Instance;

	public List<GameObject> ingredientPreFabs; // Assign prefabs in Inspector

	public Transform[] cookingSlots; // Assign UI slots in Inspector

	public void SpawnIngredient(int itemID)
	{
		if (!UnlockManager.Instance.IsItemUnlocked(itemID))
		{
			Debug.LogError("Ingredient not unlocked yet!");
			return;
		}

		GameObject ingredientPrefab = ingredientPreFabs[itemID];

		foreach (Transform slot in cookingSlots)
		{
			if (slot.childCount == 0)
			{
				Instantiate(ingredientPrefab, slot.position, Quaternion.identity, slot);
				Debug.Log("Spawned ingredient: " + itemID);
				return;
			}
		}

		Debug.Log("No empty cooking slots available!");
	}
		
}
