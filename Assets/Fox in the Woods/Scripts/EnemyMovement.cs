using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Rigidbody2D to store the enemy rigidbody
    Rigidbody2D enemyRigidbody;
    // Enemy speed
    [SerializeField] float enemySpeed = 1f;

    void Start()
    {
        // Get the enemy rigidbody
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move the enemy until itn hits a wall
        MoveEnemy();
    }

    // // OnCollisionEnter2D method to check if the enemy hits a wall
    // void OnCollisionEnter2D(Collision2D collision) {
    //     // Print the collision object tag
    //     Debug.Log(collision.gameObject.tag);

    //     // Check if the enemy hits a wall
    //     if (collision.gameObject.tag == "Wall") {
    //         SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

    //         // Flip the enemy
    //         transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidbody.velocity.x)), 1f);
    //         Debug.Log(spriteRenderer.flipX);
    //         // Flip sprite renderer
    //         GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    //         Debug.Log(spriteRenderer.flipX);
    //     }
    // }

    // MoveEnemy method to move the enemy
    void MoveEnemy() {
        // Move the enemy
        enemyRigidbody.velocity = new Vector2(transform.localScale.x, 0f) * enemySpeed;
    }

   private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Exit!");
   }
}