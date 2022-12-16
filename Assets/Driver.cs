using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
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
        transform.Rotate(0, 0, Input.GetAxis("Horizontal"));
        
        //transform.Translate(0, moveSpeed, 0);

        // Move object forward on y axis using vertical input
        transform.Translate(0, Input.GetAxis("Vertical") * 0.005f, 0);

    }
}
