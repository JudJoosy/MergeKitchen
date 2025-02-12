using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltMerge : MonoBehaviour
{
    public GameObject PepperPrefab;
    private bool hasMerged = false;

    private void OnTriggerEnter(Collider other)
    {
        hasMerged = true;
        
        //Find the other salt object
        GameObject otherSalt = other.gameObject;

        // pepper spawn location
        Vector3 mergePosition = (transform.position + otherSalt.transform.position) / 2;

        //destroy salt objects
        Destroy(otherSalt);
        Destroy(gameObject);

        // Instantiate pepper object
        Instantiate(PepperPrefab, mergePosition, Quaternion.identity);

    }
  
}
