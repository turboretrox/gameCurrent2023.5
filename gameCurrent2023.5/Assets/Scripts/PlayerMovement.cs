using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float speedForce = 1.0f;
    public float jumpForce = 1.0f;
    float dirX = 0;

    
    public Transform groundCheck;
    public LayerMask groundCheckLayer;
    bool isFacing = true;

    private bool isWallSliding;
    private float wallslidingSpeed = 2.0f;
    public Transform wallCheck;
    public LayerMask wallLayer;


    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpCounter;
    private float wallJumpTime = 0.2f;
    private float wallDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrournded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


            
        WallSliding();
        WallJump();
        if(!isWallJumping)
        {
            flip();
        }
    }
    private void FixedUpdate()
    {
        if (!isWallJumping)
        {
            rb.velocity = new Vector2(dirX * speedForce, rb.velocity.y);
        }
           
    }

    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position,0.2f,wallLayer);
    }
    private void WallSliding()
    {
        if(isWalled() && !isGrournded() && dirX != 0)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.y, Mathf.Clamp(rb.velocity.y, -wallslidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }
    private void WallJump()
    {
        if(isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpCounter = wallJumpTime;
            CancelInvoke(nameof(stopwallJumping));
        }
        else
        {
            wallJumpCounter -= Time.deltaTime;
        }
        if(Input.GetButtonDown("Jump") && wallJumpCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpCounter = 0f;

            if(transform.localScale.x != wallJumpingDirection)
            {
                isFacing = !isFacing;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
            Invoke(nameof(stopwallJumping), wallDuration);
        }
    }
    private void stopwallJumping()
    {
        isWallJumping = false;
    }

    void flip()
    {
        if (isFacing && dirX < 0f || !isFacing && dirX > 0f)
        {
            isFacing = !isFacing;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private bool isGrournded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .2f, groundCheckLayer);
    }
}
