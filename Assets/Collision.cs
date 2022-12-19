using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
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
        Debug.Log("Trigger Detected");
        // Print the name of the object that collided with this object
        Debug.Log(collision.gameObject.name);

        // Print collided object tag
        Debug.Log(collision.gameObject.tag);
    }
}
