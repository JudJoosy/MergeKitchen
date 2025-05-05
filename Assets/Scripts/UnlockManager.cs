using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnlockableIngredient
{
    public string ingredientName;
    public bool isUnlocked;
}

public class UnlockManager : MonoBehaviour
{
    public static UnlockManager Instance;
    public static List<UnlockableIngredient> unlockedList = new List<UnlockableIngredient>();

    [SerializeField] private List<UnlockableIngredient> defaultUnlockables;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeUnlocks();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeUnlocks()
    {
        // Clone defaultUnlockables into the static unlockedList
        unlockedList = new List<UnlockableIngredient>();
        foreach (var item in defaultUnlockables)
        {
            unlockedList.Add(new UnlockableIngredient
            {
                ingredientName = item.ingredientName,
                isUnlocked = item.isUnlocked
            });
        }
    }

    public static bool IsIngredientUnlocked(string ingredientName)
    {
        var item = unlockedList.Find(i => i.ingredientName == ingredientName);
        return item != null && item.isUnlocked;
    }

    public static void UnlockIngredient(string ingredientName)
    {
        var item = unlockedList.Find(i => i.ingredientName == ingredientName);
        if (item != null)
        {
            item.isUnlocked = true;
            Debug.Log($"{ingredientName} has been unlocked.");
        }
        else
        {
            // If the ingredient doesn't exist yet, add it
            unlockedList.Add(new UnlockableIngredient
            {
                ingredientName = ingredientName,
                isUnlocked = true
            });
            Debug.Log($"{ingredientName} added and unlocked.");
        }
    }

    public static void LockIngredient(string ingredientName)
    {
        var item = unlockedList.Find(i => i.ingredientName == ingredientName);
        if (item != null)
        {
            item.isUnlocked = false;
        }
    }

    public static List<string> GetUnlockedIngredientNames()
    {
        List<string> result = new List<string>();
        foreach (var item in unlockedList)
        {
            if (item.isUnlocked)
            {
                result.Add(item.ingredientName);
            }
        }
        return result;
    }
}