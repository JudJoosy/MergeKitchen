using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
// [Lopez,Judith]
//

public class CookingManager : MonoBehaviour
{
	public static CookingManager Instance;
	private List<string> currentIngredients = new List<string>();

	public int playerMoney = 0; //player's money
	
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	public void AddIngredient(string ingredient)
	{
		currentIngredients.Add(ingredient);

		if (currentIngredients.Contains("Salt") && currentIngredients.Contains("Pepper"))
		{
			CreateDish();
		}
	}

	void CreateDish()
	{
		Debug.Log("Dish made! Earned money.");
		playerMoney += 50; //add money for making Dish

		currentIngredients.Clear(); //reset for next dish
	}
}
