using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WGJ136.Movement;

[RequireComponent(typeof(Rigidbody2D))]
public class InputHandler : MonoBehaviour
{
    public KeyCode moveLeft;

    public KeyCode moveRight;

    public KeyCode jump;

    public Jump jumpScript;

    public Walk walkScript;

    private void Awake()
    {
        jumpScript = new Jump(GetComponent<Rigidbody2D>());
        walkScript = new Walk(GetComponent<Rigidbody2D>());
    }

    void Update()
    {
        CheckMove();
        CheckJump();
        jumpScript.Update();
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(jump))
        {
            jumpScript.StartJump();
        }
    }

    private void CheckMove()
    {
        Vector2 direction = Vector2.zero;
        
        if (Input.GetKey(moveLeft))
        {
            direction.x -= 1;
        }
        
        if (Input.GetKey(moveRight))
        {
            direction.x += 1;
        }
        
        walkScript.Move(direction);
    }
}
