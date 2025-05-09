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

    [SerializeField] GameObject jumpResetImage; 
    [SerializeField] GameObject jumpImage1;
    [SerializeField] GameObject jumpImage2;
    [SerializeField] GameObject jumpImage3;

    Rigidbody2D playerRb;
    Vector2 playerJump;
    private int jumpCount = 0;
    private bool isJumpPressed = false;

    private Animator animator;
    private bool checkJump = false;

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
        if(jumpCount == 0 )
        {
            jumpImage1.SetActive(true);
            jumpImage2.SetActive(true);
            jumpImage3.SetActive(true);
        }
        else if(jumpCount == 1)
        {
            jumpImage1.SetActive(true);
            jumpImage2.SetActive(true);
            jumpImage3.SetActive(false);
        }
        else if(jumpCount ==2)
        {
            jumpImage1.SetActive(true);
            jumpImage2.SetActive(false);
            jumpImage3.SetActive(false);
        }
        else
        {
            jumpImage1.SetActive(false);
            jumpImage2.SetActive(false);
            jumpImage3.SetActive(false);
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
            if(checkJump == false)
            {
                jumpResetImage.SetActive(false);
                jumpCount = 0;
                checkJump = true;
            }
            else if(checkJump == true)
            {
                jumpResetImage.SetActive(true);
                jumpCount = 0;
                jumpImage1.SetActive(true);
                jumpImage2.SetActive(true);
                jumpImage3.SetActive(true);
            }
        }
        //플랫폼 태그에 닿으면 점프 초기화와 UI등장
        if(collision.gameObject.CompareTag("Platform"))
        {
            jumpResetImage.SetActive(true);
            jumpCount = 0;
            jumpImage1.SetActive(true);
            jumpImage2.SetActive(true);
            jumpImage3.SetActive(true);
        }
    }
}