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
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * speedForce, rb.velocity.y); 
    }
}
