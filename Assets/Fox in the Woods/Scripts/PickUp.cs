using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    SessionController sessionController;
    //Audio clip to play when the player picks up the coin
    [SerializeField] AudioClip pickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        sessionController = FindObjectOfType<SessionController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Triggered");
        if (other.gameObject.tag == "Player")
        {
            sessionController.IncreasePlayerCoins();
            // Get audio component and reproduce the finish sound
            AudioSource.PlayClipAtPoint(pickUpSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
