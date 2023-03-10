using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Object to follow
    [SerializeField] GameObject objectToFollow;

    // Position camera to follow object
    private void LateUpdate()
    {
        // Set camera position to object position without changing z axis
        transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);
    }
}
