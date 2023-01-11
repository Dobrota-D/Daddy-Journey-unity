using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerJump : MonoBehaviour
{
    public GroundCheck groundCheck;
    public float jumpForce = 20;
    public float gravity = -9.81f;
    public float gravityScale = 5;
    float velocity;
    void Update()
    {
        velocity += gravity * gravityScale * Time.deltaTime;
        if (groundCheck.isGrounded && velocity <= 0)
        {
            float offset = 1;
            velocity = 0;
            Vector3 closestPoint = groundCheck.hit.collider.ClosestPoint(transform.position);
            Vector3 snappedPosition = new Vector3(transform.position.x, closestPoint.y + offset, transform.position.z);

            transform.position = snappedPosition;
        }
        // verif jump : Keyboard
        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
        {
            velocity = jumpForce;
        }

        // verif jump : Manette
        if (Input.GetButtonDown("A") && groundCheck.isGrounded )
        {
            velocity = jumpForce;
        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }
}