using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSalt : MonoBehaviour
{
  private Vector3 offset;
  private bool isDragging = false;

  void Update()
  {
	  if (isDragging)
	  {
		  Vector3 newPosition = GetMouseWorldPosition() + offset;
		  transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
	  }
  }

  private void OnMouseDown()
  {
	  offset = transform.position - GetMouseWorldPosition();
	  isDragging = true;
  }

  private void OnMouseUp()
  {
	  isDragging = false;
  }

  Vector3 GetMouseWorldPosition()
  {
	  Vector3 mousePosition = Input.mousePosition;
	  mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
	  return Camera.main.ScreenToWorldPoint(mousePosition);
  }

}
