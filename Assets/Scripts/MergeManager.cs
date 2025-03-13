using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
  public static MergeManager Instance; //singleton to access this

  private List<string> mergedIngredients = new List<string>();

  private void Awake()
  {
	 if (Instance == null)
	 {
		 Instance = this;
		 DontDestroyOnLoad(gameObject); //Kepp this manager across scenes
	 }
	 else
	 {
		 Destroy(gameObject);
	 }
  }

  public void MergeIngredients(string ingredientName)
  {
	  // Add merged ingredient to the list 
	  mergedIngredients.Add(ingredientName);
  }

  public List<string> GetMergedIngredients()
  {
	  return mergedIngredients;
  }

  public void ClearMergedIngredients()
  {
	  mergedIngredients.Clear();
  }

}
