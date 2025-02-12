using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//(This script will serve to allow the player to tap on the screen ) 

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInput playerInput;
    private InputAction touchPositionAction;
    private InputAction touchPressAction;
 
    //The following part is more used for testing purposes 
    public Color newColor;

   
    private void Awake()
    {
        playerInput=GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions.FindAction("Touch");
        touchPressAction = playerInput.actions.FindAction("TouchPress");
    }
    private void OnEnable()
    {
        touchPressAction.performed += TouchPress;

    }
    private void OnDisable()
    {
        touchPressAction.performed -= TouchPress;

    }
    private void TouchPress(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        Debug.Log("The button is indeed pressed ");

    }
    

}
