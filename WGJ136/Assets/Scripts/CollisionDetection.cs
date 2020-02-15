using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [Header("Collision")]
    public float collisionRadius = 0.1f;
    public Vector2 bottomOffset, rightOffset, leftOffset;
    public LayerMask groundLayer;
    public LayerMask playerLayer;

    [Header("Animator")] 
    public Animator animator;
    
    [Header("Debug Helper")]
    public bool onGround = false;
    public bool onWall = false;
    public bool onPlayer = false;
    void Update()
    {
        var position = transform.position;
        
        onGround = Physics2D.OverlapCircle((Vector2) position + bottomOffset, collisionRadius, groundLayer);
        onPlayer = Physics2D.OverlapCircle((Vector2) position + bottomOffset, collisionRadius, playerLayer);
        onWall = Physics2D.OverlapCircle((Vector2) position + leftOffset, collisionRadius, groundLayer)
                 || Physics2D.OverlapCircle((Vector2) position + rightOffset, collisionRadius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        var position = transform.position;
        
        //var positions = new Vector2[] {bottomOffset, leftOffset, rightOffset};
        
        Gizmos.DrawSphere((Vector2)position + bottomOffset, collisionRadius);
        Gizmos.DrawSphere((Vector2)position + leftOffset, collisionRadius);
        Gizmos.DrawSphere((Vector2)position + rightOffset, collisionRadius);
    }
}
