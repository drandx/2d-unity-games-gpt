using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    // Time to reload the scene
    [SerializeField] float timeToReload = 0.5f;
    // Reference to particle system
    [SerializeField] ParticleSystem crashParticles;
    // Crash sound audioclip variable
    [SerializeField] AudioClip crashSound;
    //Player controller script
    PlayerController playerController;

    //Get an instance of the player controller script
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Detect when an object collides with the object
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            // Play the particle system
            crashParticles.Play();
            Invoke("ReloadScene", timeToReload);
            //Get audio component and play the crash sound
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            playerController.DisableControllers();
        }
    }
    // Method to reload the scene with a timeout
    void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
