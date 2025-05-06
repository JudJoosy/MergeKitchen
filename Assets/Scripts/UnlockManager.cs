using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    [System.Serializable]
    public class IngredientUnlockData
    {
        public string ingredientName;
        public int cost;
        public GameObject ingredientPrefab;
    }

    public List<IngredientUnlockData> unlockableIngredients;
    private HashSet<string> unlockedIngredients = new HashSet<string>();

    private void Start()
    {
        LoadUnlockedIngredients();
    }

    public bool TryUnlockIngredient(string ingredientName)
    {
        IngredientUnlockData data = unlockableIngredients.Find(i => i.ingredientName == ingredientName);
        if (data == null)
        {
            Debug.LogWarning($"Ingredient {ingredientName} not found in list.");
            return false;
        }

        if (unlockedIngredients.Contains(ingredientName))
        {
            Debug.Log($"{ingredientName} already unlocked.");
            return true;
        }

        if (CurrencyManager.Instance.SpendMoney(data.cost))
        {
            unlockedIngredients.Add(ingredientName);
            PlayerPrefs.SetInt("Unlocked_" + ingredientName, 1);
            PlayerPrefs.Save();
            Debug.Log($"{ingredientName} unlocked!");
            return true;
        }

        return false;
    }

    public bool IsIngredientUnlocked(string name)
    {
        return unlockedIngredients.Contains(name);
    }

    void LoadUnlockedIngredients()
    {
        foreach (var data in unlockableIngredients)
        {
            if (PlayerPrefs.GetInt("Unlocked_" + data.ingredientName, 0) == 1)
                unlockedIngredients.Add(data.ingredientName);
        }
    }

    public List<GameObject> GetUnlockedIngredientPrefabs()
    {
        List<GameObject> result = new List<GameObject>();
        foreach (var data in unlockableIngredients)
        {
            if (unlockedIngredients.Contains(data.ingredientName))
                result.Add(data.ingredientPrefab);
        }
        return result;
    }
}