using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FoxScript : EnemyScript
{
    [Header("Move info")]
    [SerializeField] private float speed;

    [Header("Collision info")]
    [SerializeField] private Tilemap foxChaseTilemap;

    [Header("Position info")]
    private Transform playerPos;
    private Vector3 futurePos;
    [SerializeField] private float chaseSpeed;
    public Transform player;

    public float detectionRange = 10.0f;
    public bool isNotOnTile = false;

    protected override void Start()
    {
        base.Start();
        facingDirection = -1;
        player = playerTransform;
        playerPos = player.GetComponent<Transform>();
    }

    private void Chase()
    {
        Vector3 currentPos = transform.position;
        futurePos = player.position;

        Vector2 direction = futurePos - currentPos;

        if (direction.x > 0 && facingDirection == -1)
        {
            Flip();
        }
        else if (direction.x < 0 && facingDirection == 1)
        {
            Flip();
        }

        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, chaseSpeed * Time.deltaTime);
    }


    private bool ShouldChasePlayer()
    {
        Vector3Int playerCellPos = foxChaseTilemap.WorldToCell(player.position);
        TileBase tile = foxChaseTilemap.GetTile(playerCellPos);
        isNotOnTile = (tile != null);
        return isNotOnTile;
    }

    private bool DetectRange() 
    {
        float horizontalDistance = Vector3.Distance(new Vector3(playerPos.position.x, playerPos.position.y, 0), new Vector3(transform.position.x, transform.position.y, 0));
        return (horizontalDistance <= detectionRange);
    }

    private void Update()
    {
        bool chasePlayer = ShouldChasePlayer();
        bool withinRange = DetectRange();

        if (chasePlayer && withinRange)
        {
            Chase();
        }

        rb.velocity = new Vector2(speed * facingDirection, rb.velocity.y);
        CollisionChecks();
        if (wallDetected || !groundDetected)
        {
            Flip();
        }

        if(isNotOnTile) {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false);
        }
        else {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), true);
        }

    }
}
