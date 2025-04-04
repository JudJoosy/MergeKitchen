using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inbounds : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject Camera;
    private Vector3 screenBounds;
    // Start is called before the first frame update

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        screenBounds=new Vector3 (Screen.width, Screen.height);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = transform.position;
        Vector3 screenPosition=mainCamera.WorldToScreenPoint (worldPosition);

        

    }
}
