using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float timeToReload = 0.5f;

    // Detect when Riders enters in the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the rider is the player
        if (collision.gameObject.tag == "Rider")
        {
            Invoke("ReloadScene", timeToReload);
        }
    }

    // Method to reload the scene with a timeout
    void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
