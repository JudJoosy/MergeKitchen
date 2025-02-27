using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class shopManager : MonoBehaviour
{
    public int[,] shopItems = new int[20,2];
    public float coins;
    public Text CoinsText;

    private void Start()
    {
        CoinsText.text = "Coins:" + coins.ToString();

        //Shop ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;
        shopItems[1, 6] = 6;
        shopItems[1, 7] = 7;
        shopItems[1, 8] = 8;
        shopItems[1, 9] = 9;
        shopItems[1, 10] = 10;
        shopItems[1, 11] = 11;
        shopItems[1, 12] = 12;
        shopItems[1, 13] = 13;
        shopItems[1, 14] = 14;
        shopItems[1, 15] = 15;
        shopItems[1, 16] = 16;
        shopItems[1, 17] = 17;
        shopItems[1, 18] = 18;
        shopItems[1, 19] = 19;
        shopItems[1, 20] = 20;

        //Shop Price's
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 25;
        shopItems[2, 3] = 60;
        shopItems[2, 4] = 125;
        shopItems[2, 5] = 275;
        shopItems[2, 6] = 600;
        shopItems[2, 7] = 1250;
        shopItems[2, 8] = 2500;
        shopItems[2, 9] = 5000;
        shopItems[2, 10] = 10000;
        shopItems[2, 11] = 20000;
        shopItems[2, 12] = 45000;
        shopItems[2, 13] = 90000;
        shopItems[2, 14] = 175000;
        shopItems[2, 15] = 350000;
        shopItems[2, 16] = 640000;
        shopItems[2, 17] = 1250000;
        shopItems[2, 18] = 2500000;
        shopItems[2, 19] = 5000000;
        shopItems[2, 20] = 10000000;



    }

    public void Buy()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, buttonRef.GetComponent<shopScript>().itemID])
        {
            coins -= shopItems[2, buttonRef.GetComponent<shopScript>().itemID];

            CoinsText.text = "Coins" + coins.ToString();
        }
    }

}
