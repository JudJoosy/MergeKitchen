using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    public int currentMoney = 1000;
    public Text moneyText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Make sure the CurrencyManager persists across scenes
        }
        else
        {
            Destroy(gameObject);  // If an instance already exists, destroy this one
        }
    }

    private void Start()
    {
        UpdateMoneyUI();
    }

    public bool SpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyUI();
            Debug.Log($"Spent ${amount}. Remaining: ${currentMoney}");  // Debug message
            return true;
        }

        Debug.Log("Not enough money!");
        return false;
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyUI();
        Debug.Log($"Added ${amount}. Current money: ${currentMoney}");  // Debug message
    }

    private void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            moneyText.text = "$" + currentMoney;
            Debug.Log("UI updated: " + moneyText.text);  // Debug message
        }
        else
        {
            Debug.LogWarning("CurrencyManager: moneyText UI reference is missing.");
        }
    }
}