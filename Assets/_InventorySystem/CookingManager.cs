
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CookingManager : MonoBehaviour
{
    public TextMeshProUGUI dishResultText;
    private List<string> currentIngredients = new List<string>();

    public void TryAddIngredient(string ingredient)
    {
        currentIngredients.Add(ingredient);
        Debug.Log("Added ingredient: " + ingredient);

        if (currentIngredients.Count >= 2)
        {
            CheckDish();
        }
    }

    public void CheckDish()
    {
        if (currentIngredients.Count == 0)
            return;

        string result = string.Join(" + ", currentIngredients);
        ShowDishResult($"You made: {result}!");
        currentIngredients.Clear();
    }

    void ShowDishResult(string message)
    {
        dishResultText.text = message;
        dishResultText.gameObject.SetActive(true);
        StartCoroutine(HideResultAfterSeconds(2f));
    }

    IEnumerator HideResultAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dishResultText.gameObject.SetActive(false);
    }
}