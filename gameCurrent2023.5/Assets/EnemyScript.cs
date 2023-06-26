using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform player;
    public float agroRange;
    public float moveSpeed;

    Rigidbody2D rb;

    private void Start()
    {
            rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if(distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }
    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
        else if(transform.position.x > player.position.x)
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }
    }
    void StopChasingPlayer()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
