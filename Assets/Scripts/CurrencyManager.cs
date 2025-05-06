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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (moneyText == null)
            Debug.LogError("CurrencyManager: moneyText UI reference is NOT assigned!");

        UpdateMoneyUI();
    }

    public bool SpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyUI();
            Debug.Log($"Spent ${amount}. Remaining: ${currentMoney}");
            return true;
        }

        Debug.Log("Not enough money!");
        return false;
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyUI();
        Debug.Log($"Added ${amount}. New balance: ${currentMoney}");
    }

    private void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            moneyText.text = "$" + currentMoney;
            Debug.Log("UI updated: $" + currentMoney);
        }
        else
        {
            Debug.LogWarning("CurrencyManager: moneyText UI reference is missing.");
        }
    }
}
