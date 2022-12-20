using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    // Collided object
    GameObject collectedPackage;

    // Show collectedPackage on the same position as the object
    private void LateUpdate()
    {
        if (hasPackage == true)
        {
            collectedPackage.transform.position = transform.position;
        }
    }


    // Detect when object collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision Detected");
        // Print the name of the object that collided with this object
        //Debug.Log(collision.gameObject.name);
    }

    // Print when object collides with a trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collided object tag is "Package" print "Package Pickup" or if collided object tag is "Customer" print "Package Delivered"
        if (collision.gameObject.tag == "Package" && hasPackage == false)
        {
            Debug.Log("Package Pickup");
            hasPackage = true;
            collectedPackage = collision.gameObject;
        }
        else if (collision.gameObject.tag == "Customer" && hasPackage == true)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            // Destroy collectedPackage
            Destroy(collectedPackage);
        }
    }
}
