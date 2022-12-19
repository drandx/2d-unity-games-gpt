using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollider : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detect when object collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("*** Martina Obstacle ***");
        // Print the name of the object that collided with this object
        Debug.Log(collision.gameObject.name);

        // Reset the position of the object that collided with this object
        collision.gameObject.transform.position = new Vector3(0, 0, 0);

        Debug.Log("Position updated ??");
    }
}
