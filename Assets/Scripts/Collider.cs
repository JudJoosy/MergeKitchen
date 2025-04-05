using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collider : MonoBehaviour
{
    //public float minx=-30f;
   // public float maxx = 34;
   // public float miny = -43f;
   //public float maxy = 33f;
   
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
       screenBounds=Camera.main.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height,Camera.main.transform.position.x));
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.y));

    }

    // Update is called once per frame
    void Update()
    {
       // //Vector3 currentPosition = transform.position;
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.x * -1);
       viewPos.x = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y * -1);
       // transform.position = viewPos;
    }
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.tag=="Collider")
        {
            Debug.Log("Object has collided with wall");
            
        }
    }

}
