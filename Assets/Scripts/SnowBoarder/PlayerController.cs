using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Torque is the force that causes rotation
    [SerializeField] float torque = 0.5f;
    // Rigidbody2D is a component that allows us to apply forces to the object
    Rigidbody2D rb;
    //Sureface effector 2d 
    SurfaceEffector2D surfaceEffector2D;
    // Base speed of the player
    [SerializeField] float baseSpeed = 20f;
    // Boosted speed
    [SerializeField] float boostedSpeed = 25f;

    // Start is called before the first frame update
    void Start()
    {
        // Get rigibody component into a private variable
        rb = GetComponent<Rigidbody2D>();
        // Find object of type surfaceEffector2D
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // When the player presses the horizontal axis  add torque to the object rotates int he oposite direction
    void Update()
    {
        RotatePlayer();
        BoostPlayer();
    }

    // Method to boost the player speed when the player presses the vertical axis
    private void BoostPlayer()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            //Add boost speed to surface effector
            surfaceEffector2D.speed = boostedSpeed;
        } else
        {
            //Add base speed to surface effector
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    private void RotatePlayer()
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
