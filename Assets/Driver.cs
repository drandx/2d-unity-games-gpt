using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        //Say hello world
        Debug.Log("Hello World");
        //transform.Rotate(0, 0, 45);
    }

    // Update is called once per frame
    void Update()
    {
        //rotate every 60 frames
        // if (Time.frameCount % 60 == 0)
        // {
        //     transform.Rotate(0, 0, 90);
        //     transform.localScale = new Vector3(1, 1, 1);
        //     transform.
        // }
        //transform.Rotate(0, 0, steerSpeed);
        
        // Rotate based on input manager
        transform.Rotate(0, 0, Input.GetAxis("Horizontal"));



        //Move object in a circle
        //transform.position = new Vector3(Mathf.Cos(Time.time), Mathf.Sin(Time.time), 10);
        //transform.Translate(Mathf.Cos(Time.time), Mathf.Sin(Time.time), 10);
        transform.Translate(0, moveSpeed, 0);
        
        // Move object forward on y axis with acceleration
        //transform.Translate(0, 0.000001f * Time.frameCount, 0);


    }
}
