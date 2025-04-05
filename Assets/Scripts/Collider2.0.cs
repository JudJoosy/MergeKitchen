using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider2 : MonoBehaviour
{
    // private Vector2 screenBounds;
    //  private float ObjectWidth;
    // private float ObjectHeigth;
    private Vector3 offset;
    private bool isDragging = false;
    
    // Start is called before the first frame update
    void Start()
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
    }
    void OnMouseUp()
    {
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        float screenWidth = Camera.main.orthographicSize * 2 * 2 * Camera.main.aspect;
        float screenHeight = Camera.main.orthographicSize * 2;
        float left = -screenWidth / 2;
        float top = screenHeight / 2;
        float right = screenWidth / 2;
        float bottom = -screenHeight / 2;
        newPosition.x = Mathf.Clamp(newPosition.x, left, right);
        newPosition.y=Mathf.Clamp(newPosition.y, top, bottom);
        transform.position = newPosition;
    }
   
    
    
}
