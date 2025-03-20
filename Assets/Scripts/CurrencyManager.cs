using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public int playerMoney = 0;
    public TextMeshProUGUI moneyText; // Assignthe UI text in the Inspector

    public void AddMoney(int amount)
    {
        playerMoney += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        moneyText.text = "$" + playerMoney.ToString();
    }
}
