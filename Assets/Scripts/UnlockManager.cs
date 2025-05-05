using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnlockableIngredient
{
    public string ingredientName;
    public GameObject prefab;
    public int unlockCost;    // Cost to unlock the ingredient
    public bool isUnlocked;
}

public class UnlockManager : MonoBehaviour
{
    public List<UnlockableIngredient> unlockableIngredients;
    public Transform spawnArea; // Where to spawn in the merge scene

    // Check if an ingredient is unlocked
    public bool IsIngredientUnlocked(string ingredientName)
    {
        UnlockableIngredient item = unlockableIngredients.Find(i => i.ingredientName == ingredientName);
        return item != null && item.isUnlocked;
    }

    // Attempt to unlock the ingredient
    public void TryUnlockIngredient(string ingredientName)
    {
        UnlockableIngredient item = unlockableIngredients.Find(i => i.ingredientName == ingredientName);

        if (item != null && !item.isUnlocked)
        {
            // Check if the player has enough money
            if (CurrencyManager.Instance.SpendMoney(item.unlockCost))
            {
                item.isUnlocked = true;
                SpawnInMergeScene(item.prefab);
                Debug.Log($"{item.ingredientName} unlocked and spawned!");
            }
            else
            {
                Debug.LogWarning("Not enough money to unlock this ingredient!");
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
        // Spawn the ingredient prefab in the merge scene
        Vector3 randomOffset = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
        Instantiate(prefab, spawnArea.position + randomOffset, Quaternion.identity);
    }
}