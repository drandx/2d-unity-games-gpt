using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // SerializeField for bullet speed
    [SerializeField] float bulletSpeed = 10f;
    PlayerMovement playerMovement;
    // Object rigidbody
    Rigidbody2D bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // Get rigidbody
        bulletRigidbody = GetComponent<Rigidbody2D>();
        // Find the instantiated object of the player
        playerMovement = FindObjectOfType<PlayerMovement>();
        transform.localScale = new Vector2(playerMovement.transform.localScale.x, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet
        bulletRigidbody.velocity = new Vector2(transform.localScale.x * bulletSpeed, 0f);
    }

    // Destroy enemy on collision
    private void OnTriggerEnter2D(Collider2D other) {
        // Check if the bullet collided with an enemy
        if (other.gameObject.tag == "Enemy") {
            // Destroy the enemy
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) {
        // Destroy the bullet
        Destroy(gameObject);
    }
    
    
}
