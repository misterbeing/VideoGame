using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Transform thisPlayersTransform;
    private Animator playerAnimator;

    private Transform initialPosition;

    private Rigidbody2D rb;
    public bool isGrounded;
    void Start()
    {
        initialPosition = this.transform;
        rb = GetComponent<Rigidbody2D>();
        thisPlayersTransform = this.transform;
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the ball is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Jump();
        }
        playeAnimations();
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    void playeAnimations()
    {
        if (isGrounded) 
        {
            if (rb.velocity.x > 0)
            {
                thisPlayersTransform.rotation = new Quaternion(thisPlayersTransform.rotation.x, 0, thisPlayersTransform.rotation.y, thisPlayersTransform.rotation.x);
                playerAnimator.SetBool("run", true);
            }

            else if (rb.velocity.x < 0)
            {
                thisPlayersTransform.rotation = new Quaternion(thisPlayersTransform.rotation.x, 180, thisPlayersTransform.rotation.y, thisPlayersTransform.rotation.x);
                playerAnimator.SetBool("run", true);
            }
            
        }

        if(!isGrounded)
        {
            if (rb.velocity.y >0)
            {
               playerAnimator.SetBool ("jump", true);
               playerAnimator.SetBool("fall", false);
            }

            else if (rb.velocity.y < 0)
            {
                playerAnimator.SetBool("jump", false);
                playerAnimator.SetBool("fall", true);
            }
        }


        else if(rb.velocity.x ==  0)
        {
            playerAnimator.SetBool("run", false);
            playerAnimator.SetBool("jump", false);
            playerAnimator.SetBool("fall", false);
            playerAnimator.Play("PlayerAnimations");
        }
    }
}
