using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishManager : MonoBehaviour
{
	 public GameObject dishesContainer;
	 public float shrinkDuration = 2f;

	 public void MakeDishDisappear(GameObject dish)
	 {
		 StartCoroutine(ShrinkAndMoveToContainer(dish));
	 }

	 IEnumerator ShrinkAndMoveToContainer(GameObject dish)
	 {
		  Vector3 originalScale = dish.transform.localScale;
		  float elapsed = 0f;

		  while (elapsed < shrinkDuration)
		  {
			  float scale = Mathf.Lerp(1f, 0f, elapsed / shrinkDuration);
			  dish.transform.localScale = originalScale * scale;
			  elapsed += Time.deltaTime;
			  yield return null;
		  }

		  dish.transform.SetParent(dishesContainer.transform);
		  dish.SetActive(false);

		  dish.transform.localScale = originalScale;
	 }


}
