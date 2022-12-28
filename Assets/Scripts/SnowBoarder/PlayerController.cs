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
    bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        // Get rigibody component into a private variable
        rb = GetComponent<Rigidbody2D>();
        // Find object of type surfaceEffector2D
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        canMove = true;
    }

    // When the player presses the horizontal axis  add torque to the object rotates int he oposite direction
    void Update()
    {
        if (canMove) {
            RotatePlayer();
            BoostPlayer();
        }

        //Print a message when the game object does a fill spin
        if (transform.rotation.z > 0.5f || transform.rotation.z < -0.5f)
        {
            Debug.Log("You did a full spin!");
        }

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

    // Disable controllers methods
    public void DisableControllers()
    {
        canMove = false;
    }
}
