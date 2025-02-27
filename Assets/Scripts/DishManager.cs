using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DishManager : MonoBehaviour
{
	 public float shrinkDuration = 2f;

	 public void MakeDishDisappear(GameObject dish)
	 {
		 StartCoroutine(ShrinkAndDestroy(dish, shrinkDuration));
	 }

	 void OnEnable()
	 {
		 SceneManager.sceneLoaded += OnSceneLoaded;
	 }

	 void OnDisable()
	 {
		 SceneManager.sceneLoaded -= OnSceneLoaded;
	 }

	 void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	 {
		 if (scene.name == "MergingScene")
		 {
			 GameObject[] dishes = GameObject.FindGameObjectsWithTag("Dish"); // Ensure your dishes have a "Dish" tag
			 foreach (GameObject dish in dishes)
			 {
				StartShrinking(dish);
			 }
		 }
	 }

	 public void StartShrinking(GameObject dish)
	 {
		 StartCoroutine(ShrinkAndDestroy(dish, 2f));
	 }

	 IEnumerator ShrinkAndDestroy(GameObject dish, float duration)
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

		  Destroy(dish);
	 }


}
