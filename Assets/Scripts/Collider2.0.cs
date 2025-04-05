using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider2 : MonoBehaviour
{
   // private Vector2 screenBounds;
  //  private float ObjectWidth;
   // private float ObjectHeigth;
   private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
      // screenBounds=Camera.main.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, Camera.main.transform.position.x));
//screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.y));
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
{
    // //Vector3 currentPosition = transform.position;
    //Vector3 viewPos = transform.position;
    //viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1-ObjectWidth,screenBounds.x+ObjectWidth);
   // viewPos.x = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y * -1);
    // transform.position = viewPos;
}
    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag=="Collider")
        {
            
                
                    Debug.Log("Object has collided with wall");
                    rb.velocity = Vector3.zero;
                
            
        }
    }

}
