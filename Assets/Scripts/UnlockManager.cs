using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnlockableIngredient
{
    public string ingredientName;
    public GameObject prefab;
    public int unlockCost;
    public bool isUnlocked;
}

public class UnlockManager : MonoBehaviour
{
    public List<UnlockableIngredient> unlockableIngredients;
    public Transform spawnArea; // Where to spawn in the merge scene

    public void TryUnlockIngredient(string ingredientName)
    {
        UnlockableIngredient item = unlockableIngredients.Find(i => i.ingredientName == ingredientName);

        if (item != null && !item.isUnlocked)
        {
            if (CurrencyManager.Instance.SpendMoney(item.unlockCost))
            {
                item.isUnlocked = true;
                SpawnInMergeScene(item.prefab);
                Debug.Log($"{item.ingredientName} unlocked and spawned!");
            }
        }
        else if (item != null && item.isUnlocked)
        {
            Debug.Log($"{item.ingredientName} is already unlocked.");
        }
        else
        {
            Debug.LogWarning("Ingredient not found.");
        }
    }

    private void SpawnInMergeScene(GameObject prefab)
    {
        Vector3 randomOffset = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
        Instantiate(prefab, spawnArea.position + randomOffset, Quaternion.identity);
    }
}