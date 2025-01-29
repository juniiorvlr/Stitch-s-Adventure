using System;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovementmEOW : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    public float jumpTime = 0.35f;
    public float jumpTimeCounter;
    private bool isAirborne;

    public Animator animator;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if(input < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(input > 0)
        {
            spriteRenderer.flipX = false;
        }

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            isAirborne = true;
            jumpTimeCounter = jumpTime;
            playerRb.linearVelocity = Vector2.up * jumpForce;

            animator.SetBool("isJumping", !isGrounded);
        }

        if (Input.GetButton("Jump") && isAirborne == true)
        {
            if (jumpTimeCounter > 0)
            {
                playerRb.linearVelocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }

            else
            {
                isAirborne = false;
            }
            
        }

        if (Input.GetButtonUp("Jump"))
        {
            isAirborne = false;
        }

        if (Input.GetKeyDown(KeyCode.F) && !isGrounded)
        {
            ResetRotation();
        }
    }

    //Runs constantly (50 times/sec)
    void FixedUpdate ()
    {
        playerRb.linearVelocity = new Vector2(input * speed, playerRb.linearVelocity.y);

        animator.SetFloat("xVelocity", Math.Abs(playerRb.linearVelocity.x));
        animator.SetFloat("yVelocity", playerRb.linearVelocity.y);
    }

    void ResetRotation()
    {
        transform.rotation = Quaternion.identity; // Setzt die Rotation auf 0 zurück
       
    }
}
