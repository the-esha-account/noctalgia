using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rb;
    protected int facingDirection = 1;

    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected private Transform enemyCheck;
    [SerializeField] protected float enemyCheckRadius;

    protected bool wallDetected;
    protected bool groundDetected;
    protected Transform playerTransform;

    protected virtual void Start() 
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerTransform = PlayerManagerScript.instance.currentPlayer.transform;
        enemyCheck = PlayerManagerScript.instance.currentPlayer.transform.Find("enemyCheck");
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.collider.GetComponent<PlayerScript>() != null) 
        {
            PlayerScript player = collision.collider.GetComponent<PlayerScript>();
            if(player.transform.position.x > transform.position.x) 
            {
                player.Knockback(1);
            }
            else if (player.transform.position.x < transform.position.x) 
            {
                player.Knockback(-1);
            }
        }
    }

    protected virtual void Flip() 
    {
        facingDirection = facingDirection * -1;
        transform.Rotate(0, 180, 0);
    }

    protected virtual void CollisionChecks() 
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, wallCheckDistance, whatIsGround);
    }

    protected virtual void OnDrawGizmos() 
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance * facingDirection, wallCheck.position.y));
    }

}
