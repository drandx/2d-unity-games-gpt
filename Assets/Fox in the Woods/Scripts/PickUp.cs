using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //Audio clip to play when the player picks up the coin
    [SerializeField] AudioClip pickUpSound;
    // WasCoinPickedUp variable to check if the coin was picked up
    bool WasCoinPickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("PickUp Triggered");
        if (other.gameObject.tag == "Player" && !WasCoinPickedUp)
        {
            WasCoinPickedUp = true;
            FindObjectOfType<SessionController>().IncreasePlayerCoins();
            // Get audio component and reproduce the finish sound
            AudioSource.PlayClipAtPoint(pickUpSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
