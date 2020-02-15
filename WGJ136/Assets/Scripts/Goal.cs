using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public float collisionRadius = 0.1f;
    public LayerMask playerLayer;
    public bool onPlayer = false;

    private void Start()
    {
        InvokeRepeating("Rotate", 1f, 1f);
    }

    void FixedUpdate()
    {
        onPlayer = Physics2D.OverlapCircle((Vector2) transform.position, collisionRadius, playerLayer);
    }

    private void Rotate()
    {
        transform.Rotate(0,0,90);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        var position = transform.position;
        
        //var positions = new Vector2[] {bottomOffset, leftOffset, rightOffset};
        Gizmos.DrawWireSphere((Vector2)transform.position , collisionRadius);
    }
}
