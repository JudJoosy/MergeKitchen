using UnityEngine;
using UnityEngine.UI;  // Make sure this is included
using TMPro;

public class IngredientUIButton : MonoBehaviour
{
    public Button button; // Declare the Button

    void Start()
    {
        button = GetComponent<Button>(); // Get the Button component
        if (button != null)
        {
            button.onClick.AddListener(OnClick); // Add a listener for button click
        }
        else
        {
            Debug.LogError("Button component not found on " + gameObject.name);
        }
    }

    void OnClick()
    {
        // Handle the button click here
        Debug.Log("Button clicked!");
    }
}
