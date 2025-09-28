using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Move info")]
    public float moveSpeed;
    public float jumpForce;
    public Vector2 wallJumpDirection;
    private bool canMove;
    private float movingInput;

    [Header("Knockback info")]
    [SerializeField] private Vector2 knockbackDirection;
    [SerializeField] private float knockbackTime;
    [SerializeField] private float knockbackProtectionTime;
                     private bool isKnocked;
                     private bool canBeKnocked = true;

    [Header("Collision info")]
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private Transform enemyCheck;
    [SerializeField] private float enemyCheckRadius;
    private bool isGrounded;
    private bool isWallDetected;
    private bool facingRight = true;
    private int facingDirection = 1;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        AnimationController();
        if(isKnocked) 
        {
            Debug.Log("done");
        }
        FlipController();
        CollisionChecks();
        InputChecks();
        CheckForEnemy();

        if(isGrounded) 
        {
            canMove = true;
        }
        Move();
    }

    private void CheckForEnemy() 
    {
        Collider2D[] hitedColldiers = Physics2D.OverlapCircleAll(enemyCheck.position, enemyCheckRadius);
    }

    private void AnimationController() 
    {
        bool isMoving = rb.velocity.x != 0;
        anim.SetBool("isKnocked", isKnocked);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isWallDetected", isWallDetected);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    private void Move() 
    {
        if (canMove) 
        {
            rb.velocity = new Vector2(moveSpeed * movingInput, rb.velocity.y);
        }
    }

    private void InputChecks() 
    {
        movingInput = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            JumpButton();
        }
    }

    private void JumpButton() 
    {
        if (isGrounded) 
        {
            Jump();
        }
    }

    public void Knockback(int direction) {
        if(!canBeKnocked) 
        {
            return;
        }

        isKnocked = true;
        canBeKnocked = false;
        rb.velocity = new Vector2(knockbackDirection.x * direction, knockbackDirection.y);
        Invoke("CancelKnockback", knockbackTime);
        Invoke("AllowKnockback", knockbackProtectionTime);
    }

    private void CancelKnockback() 
    {
        isKnocked = false;
    }

    private void AllowKnockback() 
    {
        canBeKnocked = true;
    }

    private void Jump() 
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void FlipController() 
    {
        if(facingRight && rb.velocity.x < 0) 
        {
            Flip();
        }
        else if (!facingRight && rb.velocity.x > 0) 
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingDirection = facingDirection * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
        isWallDetected = Physics2D.Raycast(transform.position, Vector2.right * facingDirection, wallCheckDistance, whatIsGround);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + wallCheckDistance * facingDirection, transform.position.y));
        Gizmos.DrawWireSphere(enemyCheck.position, enemyCheckRadius);
    }
}
