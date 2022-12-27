using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustController : MonoBehaviour
{
    // Start is called before the first frame update
    // Dust particle system for the player
    [SerializeField] ParticleSystem dust;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        dust.Play();
    }

    private void OnCollisionExit2D(Collision2D other) {
        dust.Stop();
    }
}
