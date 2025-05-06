using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 5f;

    [SerializeField] int maxJumpCount = 3;
    [SerializeField] float fallSpeed = 2f;
    [SerializeField] float lowJumpSpeed = 1.5f;

    Rigidbody2D playerRb;
    Vector2 playerJump;
    private int jumpCount = 0;
    private bool isJumpPressed = false;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void OnJump(InputValue value)
    {
        isJumpPressed = value.isPressed;

        if(isJumpPressed && jumpCount <maxJumpCount)
        {
            playerRb.linearVelocity = new Vector2(0f,jumpSpeed);
            jumpCount++;
        }
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        if(!isJumpPressed && playerRb.linearVelocity.y>0)
        {
            playerRb.linearVelocity += Vector2.down * lowJumpSpeed;
        }
        else if(playerRb.linearVelocity.y<0)
        {
            playerRb.linearVelocity += Vector2.down * fallSpeed;
        }

    }
    void Update()
    {
        if(isJumpPressed && playerRb.linearVelocity.y > 0)
        {
            animator.SetBool("isJumping" , true);
        }
        else if(playerRb.linearVelocity.y == 0)
        {
            animator.SetBool("isJumping" , false);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Underground"))
        {
            jumpCount = 0;
        }
    }
}
