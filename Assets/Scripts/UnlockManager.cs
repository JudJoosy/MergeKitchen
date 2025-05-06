using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Use TextMeshPro or switch to UnityEngine.UI.Text if needed

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
    public GameObject buttonPrefab; // Prefab with Button + Text (or TMP_Text)
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
            TMP_Text buttonText = buttonObj.GetComponentInChildren<TMP_Text>(); // Or use Text if not TMP

            if (buttonText != null)
            {
                bool alreadyUnlocked = IsIngredientUnlocked(data.ingredientName);
                buttonText.text = alreadyUnlocked
                    ? $"{data.ingredientName} (Unlocked)"
                    : $"{data.ingredientName} - ${data.cost}";

                // Debugging to check if the button text is set correctly
                Debug.Log($"Button Text Set: {buttonText.text}");
            }
            else
            {
                Debug.LogWarning("Button Text component not found!");
            }

            string ingredientName = data.ingredientName;
            button.onClick.AddListener(() =>
            {
                if (TryUnlockIngredient(ingredientName))
                {
                    if (buttonText != null)
                    {
                        buttonText.text = $"{ingredientName} (Unlocked)";
                    }
                }
            });

            // Debugging button interactability
            if (IsIngredientUnlocked(data.ingredientName))
            {
                button.interactable = false;
                Debug.Log($"Button for {data.ingredientName} set to non-interactable (already unlocked).");
            }
            else
            {
                button.interactable = true;
                Debug.Log($"Button for {data.ingredientName} is interactable.");
            }
        }
    }
}