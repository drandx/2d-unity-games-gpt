using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Speed of the player
    [SerializeField] float runSpeed = 5f;
    // Game variable for jump speed
    [SerializeField] float jumpSpeed = 5f;
    // SerializeField for climb speed
    [SerializeField] float climbSpeed = 5f;

    // Vector2 to store the move value
    Vector2 move;
    // Get animation controller
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the animator component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipPlayer();
        ClimbLadder();
    }

    // IsGrounded method to check if the player is on the ground
    bool IsGrounded() {
        // Get the rigidbody component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Get the collider component
        Collider2D collider = GetComponent<Collider2D>();
        // Check if the player is on the ground
        return Physics2D.IsTouchingLayers(collider, LayerMask.GetMask("Ground"));
    }

    void OnMove(InputValue value) {
        // Assign the move value to a class property
        move = value.Get<Vector2>();
    }

    void OnJump(InputValue value) {
        // Jump if the player is on the ground and the jump button is pressed
        if (value.isPressed && IsGrounded()) {
            Jump();
        }
    }

    // Make the player run  using the move value
    void Run() {
        // Get the rigidbody component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Add velocity to the rigidbody and avoid the player to move vertically. Use variable to adjust the speed
        rb.velocity = new Vector2(move.x * runSpeed , rb.velocity.y);
        // Set animator to isRunning if the player is moving
        animator.SetBool("isRunning", move.x != 0);
        animator.SetBool("isClimbing", false);
    }

   // Make the player jump
    void Jump() {
        // Get the rigidbody component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Add velocity to the rigidbody and avoid the player to move horizontally. Use variable to adjust the jump speed
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpSpeed);
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

    // ClimbLadder method to make the player climb Climbable objects
    public void ClimbLadder() {
        if (!CanClimb()) {
            return;
        }
        // Get the rigidbody component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Add velocity to the rigidbody and avoid the player to move horizontally. Use variable to adjust the climb speed
        rb.velocity = new Vector2(rb.velocity.x, move.y * climbSpeed);
        // Set animator to isClimbing if the player is climbing
        animator.SetBool("isClimbing", move.y != 0);
    }

    // CanClimb method to check if the player is colliding with a Climbable object
    public bool CanClimb() {
        // Get the collider component
        Collider2D collider = GetComponent<Collider2D>();
        // Check if the player is colliding with a Climbable object
        return Physics2D.IsTouchingLayers(collider, LayerMask.GetMask("Climbable"));
    }


}
