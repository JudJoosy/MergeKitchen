using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems; 

public class Ingredient : MonoBehaviour
{
	 public string ingredientType;  // Name of the Ingredient
	 private Vector3 offset;
	 private bool isDragging = false;

	 private void OnMouseDown()
	 {
		 // Store the offset between the mouse and the object position
		 offset = transform.position - GetMouseWorldPos();
		 isDragging = true;
	 }

	 private void OnMouseDrag()
	 {
		 if (isDragging)
		 {
			 transform.position = GetMouseWorldPos() + offset;
		 }
	 }

	 private void OnMouseUp()
	 {
		 isDragging = false;
	 }

	 private Vector3 GetMouseWorldPos()
	 {
		 Vector3 mousePoint = Input.mousePosition;
		 mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
		 return Camera.main.ScreenToWorldPoint(mousePoint);
	 }

	 private void OnTriggerEnter(Collider other)
	 {
		 Ingredient otherIngredient = other.GetComponent<Ingredient>();

		 if (otherIngredient != null && otherIngredient.ingredientType == ingredientType)
		 {
			 MergeIngredients(otherIngredient);
		 }
	 }

	 private void MergeIngredients(Ingredient otherIngredient)
	 {
		 // Calculate the position where both ingredients are
		 Vector3 mergePosition = (transform.position + otherIngredient.transform.position) / 2;

		 // Destroy both ingredients when they merge
		 Destroy(otherIngredient.gameObject);
		 Destroy(gameObject);

		 // For now, just log the merge event
		 Debug.Log("Merged " + ingredientType + " with " + otherIngredient.ingredientType);
	 }
}

