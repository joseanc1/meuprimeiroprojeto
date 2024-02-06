using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startingVelocity = new Vector2(5f, 5f);

    public GameManager gameManager;

    public float speedUp = 1.1f;

    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (Random.Range(0, 100) > 50)
        {
            startingVelocity.x = startingVelocity.x *-1;    
        }

        if (Random.Range(0, 100) > 50)
        {
            startingVelocity.y = startingVelocity.y * -1;
        }
        rb.velocity = startingVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        // quando colidir com as paredes
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.velocity;
            
            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;
        }

        //quando colidir com player e inimigo
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= speedUp;
        }


        if (collision.gameObject.CompareTag("WallEnemy"))
        {
            gameManager.ScorePlayer();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("WallPlayer"))
        {
            gameManager.ScoreEnemy();
            ResetBall();
        }
    }
}
