using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Vector2 to store the move value
    private Vector2 move;
    // Speed of the player
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    void OnMove(InputValue value) {
        // Assign the move value to a class property
        move = value.Get<Vector2>();
        //Prints the value of the input
        Debug.Log(value);
    }

    // Make the player run  using the move value
    void Run() {
        // Get the rigidbody component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Add velocity to the rigidbody and avoid the player to move vertically. Use variable to adjust the speed
        rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
    }


}
