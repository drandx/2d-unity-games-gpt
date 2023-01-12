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
    // SerializeField for bullet object
    [SerializeField] GameObject bullet;

    // isAlive variable to check if the player is alive
    bool isAlive = true;

    // CapsuleCollider2D to store the player collider
    CapsuleCollider2D bodyCollider;

    // BoxCollider2D to store the player feet collider
    BoxCollider2D feetCollider;

    // Vector2 to store the move value
    Vector2 move;
    // Get animation controller
    Animator animator;
    // Player gravity scale
    float gravityScale;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the animator component
        animator = GetComponent<Animator>();
        // Get initial gravity scale
        gravityScale = GetComponent<Rigidbody2D>().gravityScale;
        // Get both colliders
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        ClimbLadder();
        FlipPlayer();
        Die();
    }

   // Die method to kill the player
   void Die() {
        if (!isAlive) {
            return;
        }
        // Check if the player collided with any layer with the tag "Enemies"
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")) || bodyCollider.IsTouchingLayers(LayerMask.GetMask("Hazards"))) {
            // Set isAlive to false and disable controllers
            isAlive = false;
            // DIsable input system
            GetComponent<PlayerInput>().enabled = false;
            // Set animator to Dying
            animator.SetTrigger("Dying");

            //Get the player moving direaction sign
            float direction = Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x);
            // Add force to the player to make it fly
            GetComponent<Rigidbody2D>().AddForce(new Vector2(direction * 1f, direction * 1f), ForceMode2D.Impulse);

            // Decrease player lives
            FindObjectOfType<SessionController>().DecreasePlayerLives();
        }
        
   }

    // IsGrounded method to check if the player is on the ground
    bool IsGrounded() {
        // Check if the player is on the ground
        return Physics2D.IsTouchingLayers(feetCollider, LayerMask.GetMask("Ground"));
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
        if (move.x != 0) {
            transform.localScale = new Vector2(Mathf.Sign(move.x), 1f);
        }
    }

    // ClimbLadder method to make the player climb Climbable objects
    public void ClimbLadder() {
        if (!CanClimb()) {
            // Set gravity scale to initial value to avoid the player to fall
            GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            return;
        }
        // Get the rigidbody component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Add velocity to the rigidbody and avoid the player to move horizontally. Use variable to adjust the climb speed
        rb.velocity = new Vector2(rb.velocity.x, move.y * climbSpeed);
        // Set animator to isClimbing if the player is climbing
        animator.SetBool("isClimbing", move.y != 0);

        // Set gravity scale to 0 to avoid the player to fall
        rb.gravityScale = 0;
    }

    // CanClimb method to check if the player is colliding with a Climbable object
    public bool CanClimb() {
        // Check if the player is colliding with a Climbable object
        return Physics2D.IsTouchingLayers(bodyCollider, LayerMask.GetMask("Climbable"));
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

    void OnFire(InputValue value) {
        // Check if the player is alive
        if (!isAlive) {
            return;
        }

        // Instantiate a projectile if the button is pressed
        if (value.isPressed) {
            // Get gun child object
            GameObject gun = transform.Find("Gun").gameObject;
            // Instantiate the projectile
            Instantiate(bullet, gun.transform.position, transform.rotation);
        }
    }
}
