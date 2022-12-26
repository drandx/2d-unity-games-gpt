using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // Detect when an object collides with the object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object is the player
        if (collision.gameObject.tag == "Ground")
        {
            // Print object tag
            Debug.Log("Collision");
        }
    }
}
