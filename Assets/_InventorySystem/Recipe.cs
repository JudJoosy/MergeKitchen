using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    public List<string> ingredientNames; 
    public GameObject dishPrefab;       
    public string dishName;              
}