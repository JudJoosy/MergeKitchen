using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//(This script will serve to allow the player to tap on the screen ) 

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
      
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("Player is touching screen");
        foreach(Touch touch in Input.touches)
        {
            if (touch.fingerId == 0)
            {
                print("Player is touching the screen");
            }
                if (touch.fingerId == 1)
            {
                print("Player is conitnuing to touch the screen");
            }
        }
    }
}
