using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    List<GameObject> collectedPackages = new List<GameObject>();
    // Temporary sprite renderer
    SpriteRenderer spriteRenderer;
    // Original sprite color
    Color originalColor;

    // Get the current sprite renderer
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Show collectedPackage on the same position as the object
    private void LateUpdate()
    {
        foreach (GameObject item in collectedPackages)
        {
            item.transform.position = transform.position;
            item.transform.rotation = transform.rotation;
            // Change the item object color to green
            item.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }


    // Detect when object collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");
        // Print the name of the object that collided with this object
        Debug.Log(collision.gameObject.name);
    }

    // Print when object collides with a trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collided object tag is "Package" print "Package Pickup" or if collided object tag is "Customer" print "Package Delivered"
        if (collision.gameObject.tag == "Package")
        {
            Debug.Log("Package Pickup");
            // Resize 50% of the collided object
            collision.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            collectedPackages.Add(collision.gameObject);

            // Change the object color on the first time it collides with a package
            if (collectedPackages.Count == 1)
            {
                GetComponent<SpriteRenderer>().color = Color.magenta;
            }
        }
        else if (collision.gameObject.tag == "Customer" && collectedPackages.Count > 0)
        {
            Debug.Log("Package Delivered");
            //Destroy all collectedPackages
            foreach (GameObject item in collectedPackages)
            {
                Destroy(item);
            }
            collectedPackages = new List<GameObject>();
            // Replace sprite with the original sprite
            GetComponent<SpriteRenderer>().color = originalColor;
        }
    }
}
