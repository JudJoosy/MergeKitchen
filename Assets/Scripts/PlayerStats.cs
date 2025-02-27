using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   public static PlayerStats Instance { get; private set; }

   public int currency;

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

   public void AddCurrency(int amount)
   {
       currency += amount;
       Debug.Log("Currency added! Current balance: " + currency);
   }
}
