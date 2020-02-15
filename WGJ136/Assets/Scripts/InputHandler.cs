using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WGJ136.Movement;

[RequireComponent(typeof(Rigidbody2D))]
public class InputHandler : MonoBehaviour
{
    [Header("Keybindings")]
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode jump;

    [Header("Settings")] 
    public bool reverseFlipper;
    
    private Jump _jumpScript;
    private Walk _walkScript;
    //private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        //_animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        
        _jumpScript = new Jump(_rigidbody);
        _walkScript = new Walk(_rigidbody);
    }

    void Update()
    {
        CheckMove();
        CheckJump();
        _jumpScript.Update();
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(jump))
        {
            //_animator.SetBool("IsJumping", true);
            _jumpScript.StartJump();
        }
    }

    private void CheckMove()
    {
        Vector2 direction = Vector2.zero;
        
        if (Input.GetKey(moveLeft))
        {
            direction.x -= 1;
            if (reverseFlipper) _spriteRenderer.flipX = true;
            else _spriteRenderer.flipX = false;
        }
        
        if (Input.GetKey(moveRight))
        {
            direction.x += 1;
            
            if (reverseFlipper) _spriteRenderer.flipX = false;
            else _spriteRenderer.flipX = true;
        }
        
        _walkScript.Move(direction);
    }
}
