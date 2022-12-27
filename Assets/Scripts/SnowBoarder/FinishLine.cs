using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float timeToReload = 0.5f;
    // Reference to a particle system
    [SerializeField] ParticleSystem finishParticles;

    // Detect when Riders enters in the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the rider is the player
        if (collision.gameObject.tag == "Rider")
        {
            Invoke("ReloadScene", timeToReload);
            // Play the particle system
            finishParticles.Play();
            // Get audio component and reproduce the finish sound
            GetComponent<AudioSource>().Play();
        }
    }

    // Method to reload the scene with a timeout
    void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
