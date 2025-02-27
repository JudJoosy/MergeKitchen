using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopScript : MonoBehaviour
{
    public int itemID;
    public GameObject ShopManager;

    private void Update()
    {
        //Changing how price will be displayed
        //priceText.text = "Price $" + ShopManager.GetComponent<shopManager>().shopItems[2, itemID].ToString();
    }
}
