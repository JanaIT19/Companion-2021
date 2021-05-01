using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    //Animator playerAnimator;
    Rigidbody2D playerRb;
    SpriteRenderer playerSpriteRenderer;

    bool isGrounded;

    [SerializeField]
    Transform groundCheck;
    
    //[SerializeField]
    //Transform groundCheckL;

    //[SerializeField]
    //Transform groundCheckR;

    [SerializeField]
    private float runSpeed = 2.5f;

    [SerializeField]
    private float jumpSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //playerAnimator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        //playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }


        if(Input.GetAxisRaw("Horizontal")>0)
        {
            playerRb.velocity = new Vector2(runSpeed, playerRb.velocity.y);
            if(isGrounded)
            {
            //playerAnimator.Play("");  running animation
            }
            //playerSpriteRenderer.flipX = false;
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if(Input.GetAxisRaw("Horizontal")<0)
        {
            playerRb.velocity = new Vector2(-runSpeed, playerRb.velocity.y);
            if(isGrounded)
            {
            //playerAnimator.Play("");  running animation
            }
            //playerSpriteRenderer.flipX = true;
            transform.localScale = new Vector3((-1) * Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } 
        else
        {
            if(isGrounded)
            {
                //playerAnimator.Play("");  idle animation
            }
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }

        if(Input.GetAxisRaw("Vertical")>0 && isGrounded)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);
            //playerAnimator.Play("");  jumping animation
        }

    }
}
