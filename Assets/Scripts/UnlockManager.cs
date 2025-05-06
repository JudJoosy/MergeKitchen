using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Using Unity's default UI Text instead of TMP_Text

public class UnlockManager : MonoBehaviour
{
    [System.Serializable]
    public class IngredientUnlockData
    {
        public string ingredientName;
        public int cost;
        public GameObject ingredientPrefab;
    }

    [Header("Ingredient Data")]
    public List<IngredientUnlockData> unlockableIngredients;

    private HashSet<string> unlockedIngredients = new HashSet<string>();

    [Header("UI Setup")]
    public GameObject buttonPrefab; // Prefab with Button + Text
    public Transform buttonContainer; // Parent layout object (e.g. Vertical Layout Group)

    private void Start()
    {
        LoadUnlockedIngredients();
        GenerateShopButtons();
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

    private void LoadUnlockedIngredients()
    {
        foreach (var data in unlockableIngredients)
        {
            if (PlayerPrefs.GetInt("Unlocked_" + data.ingredientName, 0) == 1)
            {
                unlockedIngredients.Add(data.ingredientName);
            }
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

    private void GenerateShopButtons()
    {
        foreach (var data in unlockableIngredients)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, buttonContainer);
            Button button = buttonObj.GetComponent<Button>();
            Text buttonText = buttonObj.GetComponentInChildren<Text>(); // Use Text instead of TMP_Text

            if (buttonText != null)
            {
                bool alreadyUnlocked = IsIngredientUnlocked(data.ingredientName);
                buttonText.text = alreadyUnlocked
                    ? $"{data.ingredientName} (Unlocked)"
                    : $"{data.ingredientName} - ${data.cost}";
            }

            string ingredientName = data.ingredientName;
            button.onClick.AddListener(() =>
            {
                if (TryUnlockIngredient(ingredientName))
                {
                    if (buttonText != null)
                        buttonText.text = $"{ingredientName} (Unlocked)";
                }
            });

            if (IsIngredientUnlocked(data.ingredientName))
                button.interactable = false;
        }
    }
}