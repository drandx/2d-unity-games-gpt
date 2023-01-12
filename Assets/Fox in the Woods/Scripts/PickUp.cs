using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    SessionController sessionController;

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
            Destroy(gameObject);
        }
    }
}
