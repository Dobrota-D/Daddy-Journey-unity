using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour { 

    [Header ("Speed Movement")]
    [SerializeField] float currentSpeed;
    [SerializeField] float minSpeed;
    [SerializeField] float maxMoveSpeed;
    [SerializeField] Animator animator;
    [Header ("Direction")]
    [SerializeField] bool isGoingRight;
    public AudioSource audioSource;
    public AudioClip wallSound;
    private float _direction;

    private void Awake()
    {
        currentSpeed = minSpeed;
    }

    private void OnEnable()
    {
        StartCoroutine(AccelerationCoroutine());
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponent<PlayerJump>().enabled = true;
    }
    private void OnDisable()
    {
        StopCoroutine(AccelerationCoroutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        // collision with a wall : just go back
        if (other.gameObject.CompareTag("wall"))
        {
            AudioSource.PlayClipAtPoint(wallSound, transform.position);
            isGoingRight = !isGoingRight;
            FlipPlayer();
        }

        if (other.gameObject.CompareTag("obstacle"))
        {
            AudioSource.PlayClipAtPoint(wallSound, transform.position);

            isGoingRight = !isGoingRight;
            currentSpeed = minSpeed;
            FlipPlayer();
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

    void FlipPlayer()
    {
            GetComponentInChildren<SpriteRenderer>().flipX = !GetComponentInChildren<SpriteRenderer>().flipX;
    }

    private IEnumerator AccelerationCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (currentSpeed < maxMoveSpeed)
            {
                currentSpeed += 1;
            }
            
            if (currentSpeed < maxMoveSpeed)
            {
                yield return new WaitForSeconds(1f);
                currentSpeed += 1;
            }
        }
       
    }
}
