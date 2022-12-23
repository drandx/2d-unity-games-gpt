using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Torque is the force that causes rotation
    [SerializeField] float torque = 0.5f;
    // Rigidbody2D is a component that allows us to apply forces to the object
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        // Get rigibody component into a private variable
        rb = GetComponent<Rigidbody2D>();
    }

    // When the player presses the horizontal axis  add torque to the object rotates int he oposite direction
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddTorque(-torque);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddTorque(torque);
        }
    }
}
