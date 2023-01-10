using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float maxMoveSpeed = 10;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public bool isJumping = false;
    public float jumpForce;
    public bool isGrounded;
    public Transform groundCheck;
    private float horizontalMovement;
    public float groundCheckRadius;
    public LayerMask collisionLayers;


    //moveBack



    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        float horizontalMovement = 1;

      

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

      

        MovePlayer(horizontalMovement);
    }
    void FixedUpdate()
    {
      
        MovePlayer(horizontalMovement);

    }
    void MovePlayer(float _horizontalMovement)
    {
        //Vector3 targetVelocity = new Vector2(_horizontalMovement * moveSpeed, rb.velocity.y);
        // rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        if(moveSpeed == maxMoveSpeed)
        {
            moveSpeed = 5;
        }

        
         rb.AddForce(new Vector2(moveSpeed * _horizontalMovement, 0));
        Debug.Log(_horizontalMovement);
        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
   
}
