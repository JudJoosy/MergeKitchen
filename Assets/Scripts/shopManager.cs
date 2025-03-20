using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class shopManager : MonoBehaviour
{
    public int[,] shopItems = new int[3,20]; // Fixing array indexing (0 - based)
    public float coins;
    public Text coinsText;

    private void Start()
    {
       if (coinsText == null)
       {
           Debug.LogError("CoinsText is not assigned in the inspector!");
           return;
       }

       UpdateCoinsUI(); // Calls a method to update the text

       // Fixing array indexing (0 - based)
       for (int i = 0; i < 20; i++)
       {
           shopItems[0, i] = i + 1; // Shop IDs (1 to 20)
       }

       // Assign shop prices
       int[] prices = { 10, 25, 60, 125, 275, 600, 1250, 2500, 5000, 10000, 20000, 45000, 90000, 175000, 350000, 640000, 1250000, 2500000, 5000000, 10000000};

       for (int i = 0; i < 20; i++)
       {
           shopItems[1, i] = prices[i]; //Assigning prices
       }
    }

    public void Buy()
    {
       GameObject buttonRef = EventSystem.current.currentSelectedGameObject;

       if (buttonRef == null)
       {
           Debug.LogError("No button selected! ");
           return;
       }

       ShopItem shopItem = buttonRef.GetComponent<ShopItem>();

       if (shopItem == null)
       {
           Debug.LogError("ShopItem component missinng on button: "); 
           return;
       }

       int itemID = shopItem.itemID;

       if (coins >= shopItems[1, itemID])
       {
           coins -= shopItems[1, itemID];
           UpdateCoinsUI(); // Update UI text
          
           UnlockManager.Instance.UnlockItem(itemID);
       }
       else
       {
           Debug.Log("Not enough coins!");
       }
    }

    private void UpdateCoinsUI()
    {
        if (coinsText != null)
        {
            coinsText.text = "Coins: " + coins.ToString();
        }
        else
        {
            Debug.LogError("coinsText is not assigned in Inspector!");
        }
    }
}
