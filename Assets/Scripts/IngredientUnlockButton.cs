using UnityEngine;
using UnityEngine.UI;

public class IngredientUnlockButton : MonoBehaviour
{
    public string ingredientName;
    public UnlockManager unlockManager;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        if (unlockManager == null)
            unlockManager = FindObjectOfType<UnlockManager>();

        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
        else
        {
            Debug.LogWarning("Button component missing on " + gameObject.name);
        }
    }

    private void OnClick()
    {
        if (unlockManager != null)
        {
            if (unlockManager.TryUnlockIngredient(ingredientName))
            {
                button.interactable = false;
            }
        }
        else
        {
            Debug.LogWarning("UnlockManager not assigned in " + gameObject.name);
        }
    }
}