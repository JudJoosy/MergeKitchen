using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
	public static UnlockManager Instance;
	public List<int> unlockedItems = new List<int>();

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void UnlockItem(int itemID)
	{
		if (!unlockedItems.Contains(itemID))
		{
			unlockedItems.Add(itemID);
			Debug.Log("Unlocked item ID: " + itemID);
		}
	}

	public bool IsItemUnlocked(int itemID)
	{
		return unlockedItems.Contains(itemID);
	}
}
