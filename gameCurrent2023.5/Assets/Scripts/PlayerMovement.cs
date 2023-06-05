using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float speedForce = 1.0f;
    public float jumpForce = 1.0f;
    float dirX = 0;

    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundCheckLayer;

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    public Transform WallCheck;
    public LayerMask WallLayer;
    private bool isWallJumping;
    private float wallJumpDirection = 0;
    private float wallJumpTime = 0.2f;
    private float wallJumpCounter;
    private float wallJumpDuartion = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f,16f);
    bool isFacing = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, groundCheckLayer);
        dirX = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        WallSlide();
        WallJump();
        if (!isWallJumping)
        {
            flip();
        }
    }
    private void FixedUpdate()
    {
        if(!isWallJumping)
        {
            rb.velocity = new Vector2(dirX * speedForce, rb.velocity.y);
        }
        
    }
    private bool isWall()
    {
        return Physics2D.OverlapCircle(WallCheck.position,.2f,WallLayer);
    }
    private void WallSlide()
    {
        if(isWall() && !isGrounded && dirX != 0)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding =false;
        }
    }
    private void WallJump()
    {
        if(isWallSliding)
        {
            isWallJumping = false;
            wallJumpDirection = -transform.localScale.x;
            wallJumpCounter = wallJumpTime;
            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpCounter -= Time.deltaTime;
        }
        if(Input.GetButtonDown("Jump"))
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpDuartion * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpCounter = 0f;

            if(transform.localScale.x != wallJumpDirection)
            {
                isFacing = !isFacing;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
            Invoke(nameof(StopWallJumping), wallJumpDuartion);
        }
    }
    private void StopWallJumping()
    {
        isWallJumping=false;
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
}
