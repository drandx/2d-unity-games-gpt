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
        FlipPlayer();
    }

    void OnMove(InputValue value) {
        // Assign the move value to a class property
        move = value.Get<Vector2>();
        // Print the move value to the console
        Debug.Log(move);
    }

    // Make the player run  using the move value
    void Run() {
        // Get the rigidbody component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Add velocity to the rigidbody and avoid the player to move vertically. Use variable to adjust the speed
        rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
    }

    //Flip the player sprite depending on the direction is moving
    void FlipPlayer() {
        // Get the sprite renderer component
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        // Check if the player is moving to the right
        if (move.x > 0) {
            // Flip the sprite
            sr.flipX = false;
        }
        // Check if the player is moving to the left
        else if (move.x < 0) {
            // Flip the sprite
            sr.flipX = true;
        }
    }


}
