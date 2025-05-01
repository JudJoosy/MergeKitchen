using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    public int currentMoney = 0;
    public Text currencyText; // Regular UI Text

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

    void Start()
    {
        UpdateCurrencyUI();
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateCurrencyUI();
    }

    private void UpdateCurrencyUI()
    {
        currencyText.text = "$" + currentMoney.ToString();
    }
}