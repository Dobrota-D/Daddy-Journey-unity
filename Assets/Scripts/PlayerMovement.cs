using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour { 

    [Header ("Speed Movement")]
    [SerializeField] float currentSpeed;
    [SerializeField] float minSpeed;
    [SerializeField] float maxMoveSpeed;
    
    [Header("Jump Movement")]
    [SerializeField] float jumpForce;
    [SerializeField] float currentFallSpeed;
    [SerializeField] float initialFallSpeed;
    [SerializeField] bool isGrounded;
    [SerializeField] float gravity = -9.81f;
    [SerializeField]  float gravityScale = 5;
    [SerializeField] float jumpHeight = 50;
    [Header ("Direction")]
    [SerializeField] bool isGoingRight;
    

    private float _direction;
    private float velocity;
    

    private void Awake()
    {
        currentSpeed = minSpeed;
        currentFallSpeed = initialFallSpeed;
    }

    private void Start()
    {
        StartCoroutine(AccelerationCoroutine());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            isGoingRight = !isGoingRight;
        }
        if (other.gameObject.CompareTag("ground"))
        {
            Debug.Log("GROUND");
            isGrounded = true;
            currentFallSpeed = initialFallSpeed;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            Debug.Log("NOT GROUND");

            isGrounded = false;
        }
    }
    void Update()
    {

     

        if (isGoingRight)
        {
            _direction = 1;
        } else
        {
            _direction = -1;
        }
       // isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
       
        float horizontalMovement = 1;

        
        if (isGrounded && velocity < 0)
        {
            velocity = 0;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity = Mathf.Sqrt(jumpHeight * -2f * (gravity * gravityScale));
            // Jump();
            transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
        }
        velocity += gravity * gravityScale * Time.deltaTime;
        if (!isGrounded) 
        {
            Fall();

        }
        MovePlayer();
    }
    void MovePlayer()
    {
        //Vector3 targetVelocity = new Vector2(_horizontalMovement * moveSpeed, rb.velocity.y);
        // rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        // rb.AddForce(new Vector2(moveSpeed * _horizontalMovement, 0));
        //transform.position = transform.position + new Vector3(_direction * currentSpeed * Time.deltaTime, 0, 0);
        transform.Translate(Vector3.right * currentSpeed * _direction * Time.smoothDeltaTime);
    }

    void Jump()
    {
            //  rb.AddForce(new Vector3(0f, jumpForce), 0);
            //transform.position = transform.position + new Vector3(0, 1 * jumpForce * Time.deltaTime, 0);
            transform.Translate(Vector3.up * jumpForce * Time.smoothDeltaTime);
    }

    private void Fall()
    {

            transform.Translate(-Vector3.up * currentFallSpeed * Time.smoothDeltaTime);
        currentFallSpeed += 0.1f;
    }

    private IEnumerator AccelerationCoroutine()
    {
        while(currentSpeed < maxMoveSpeed)
        {
            yield return new WaitForSeconds(1f);
            currentSpeed += 1;
        }
    }
}
