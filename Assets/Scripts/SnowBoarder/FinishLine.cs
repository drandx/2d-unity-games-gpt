using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Detect when Riders enters in the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the rider is the player
        if (collision.gameObject.tag == "Rider")
        {
            // Print object tag
            Debug.Log("Finish it");
        }
    }
}
