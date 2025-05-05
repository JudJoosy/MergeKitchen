using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    public int currentMoney = 1000; // Starting money
    public Text moneyText; // Optional: connect to your UI

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene change
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateMoneyUI();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Try to find and reassign the moneyText in the new scene
        if (moneyText == null)
        {
            GameObject foundText = GameObject.Find("MoneyText");
            if (foundText != null)
            {
                moneyText = foundText.GetComponent<Text>();
                Debug.Log("MoneyText UI re-assigned.");
            }
            else
            {
                Debug.LogWarning("MoneyText UI not found in this scene.");
            }
        }

        UpdateMoneyUI();
    }

    public bool SpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyUI();
            return true;
        }
        else
        {
            Debug.Log("Not enough money!");
            return false;
        }
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyUI();
    }

    private void UpdateMoneyUI()
    {
        if (moneyText != null)
            moneyText.text = "$" + currentMoney.ToString();
        else
            Debug.LogWarning("moneyText UI reference is missing.");
    }
}
