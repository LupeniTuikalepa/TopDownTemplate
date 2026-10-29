using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.4f;

    [SerializeField] 
    private PlayerControls playerControls;

    [SerializeField] 
    private Rigidbody rb;
    
    private void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void MovePlayer()
    {
        Vector2 inputs = playerControls.movementInput;
        
        Vector3 direction = new Vector3(inputs.x, 0, inputs.y);

        Vector3 velocity = direction * speed;
        
        rb.linearVelocity =  velocity;
    }



}
