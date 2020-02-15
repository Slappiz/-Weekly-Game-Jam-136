using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [Header("Collision")]
    public float collisionRadius = 0.1f;
    public float collisionRadiusGround = 0.05f;
    public Vector2 bottomOffset, rightOffset, leftOffset, topOffset;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public LayerMask playerLayer;

    [Header("Debug Helper")]
    public bool onGround = false;
    public bool onWall = false;
    public bool onPlayer = false;
    public bool belowPlayer = false;
    
    void Update()
    {
        var position = transform.position;
        
        onGround = Physics2D.OverlapCircle((Vector2) position + bottomOffset, collisionRadiusGround, groundLayer);
        onPlayer = Physics2D.OverlapCircle((Vector2) position + bottomOffset, collisionRadiusGround, playerLayer);
        belowPlayer = Physics2D.OverlapCircle((Vector2) position + topOffset, collisionRadiusGround, playerLayer);
        onWall = Physics2D.OverlapCircle((Vector2) position + leftOffset, collisionRadius, wallLayer)
                 || Physics2D.OverlapCircle((Vector2) position + rightOffset, collisionRadius, wallLayer);
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        var position = transform.position;
        
        //var positions = new Vector2[] {bottomOffset, leftOffset, rightOffset};
        Gizmos.DrawSphere((Vector2)position + topOffset, collisionRadiusGround);
        Gizmos.DrawSphere((Vector2)position + bottomOffset, collisionRadiusGround);
        Gizmos.DrawSphere((Vector2)position + leftOffset, collisionRadius);
        Gizmos.DrawSphere((Vector2)position + rightOffset, collisionRadius);
    }
}
