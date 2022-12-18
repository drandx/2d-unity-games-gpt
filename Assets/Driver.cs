using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] float moveSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        //Say hello world
        Debug.Log("Hello World");
        //transform.Rotate(0, 0, 45);
    }

    // Update is called once per frame
    void Update()
    { 
        // Rotate based on input manager
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime);
        
        // Move object forward on y axis using vertical input
        transform.Translate(0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime, 0);
 
    }

    // Detect when the object collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");
    }
}