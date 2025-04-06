using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
   public string ingredientName;
   public CookingManager cookingManager;

   public TextMeshProUGUI ingredientText;

   public void Setup(string name, CookingManager manager)
   {
	   ingredientName = name;
       cookingManager = manager;

	   if (ingredientText != null)
	   {
		   ingredientText.text = name;
	   }
	   else
	   {
		   Debug.LogError("TextMeshPro component not found in InventorySlot prefab.");
	   }


	   Button button = GetComponent<Button>();
	   {
		   if (button != null)
		   {
			   button.onClick.AddListener(OnClick);
		   }
		   else
		   {
			   Debug.LogError("Button component not found in InventorySlot prefab.");
		   }
	   }
   }


   public void OnClick()
   {
	   if (cookingManager != null)
	   {
		   cookingManager.TryAddIngredient(ingredientName);
	   }
	   else
	   {
		   Debug.LogError("CookingManager reference is missing in InventorySlot.");
	   }
   }
}