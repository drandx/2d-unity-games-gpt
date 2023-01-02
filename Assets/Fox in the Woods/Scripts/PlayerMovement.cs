using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Vector2 to store the move value
    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue value) {
        // Assign the move value to a class property
        move = value.Get<Vector2>();
        //Prints the value of the input
        Debug.Log(value);
    }
}
