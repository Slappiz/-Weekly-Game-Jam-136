using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using WGJ136.Movement;

[RequireComponent(typeof(Rigidbody2D))]
public class InputHandler : MonoBehaviour
{
    [Header("Keybindings")]
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode jump;
    public KeyCode down;

    [Header("Settings")] 
    public bool reverseSpriteFlipper;

    private Jump _jumpScript;
    private Walk _walkScript;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private CollisionDetection _collisionDetection;
    
    // Jump
    private float jumpPressRemember = 0f;
    private const float jumpPressedRememberTime = 0.2f;
    private float groundRemember = 0f;
    private const float groundRememberTimer = 0.2f;
    
    // Climb
    private bool isWallGrabbing = false;
    private float climbSpeed = .6f;
    
    private int direction = 0;
    
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _collisionDetection = GetComponent<CollisionDetection>();
        
        _jumpScript = new Jump(_rigidbody);
        _walkScript = new Walk(_rigidbody);
    }

    void Update()
    {
        WallSlide();
        CheckJump();
        SetAnimations();
        WallGrab();
        CheckMove();
    }

    private void FixedUpdate()
    {
        _walkScript.Move(direction);
        _jumpScript.Update();
    }

    private void WallSlide()
    {
        if (!_collisionDetection.onGround && (_collisionDetection.onWallLeft || _collisionDetection.onWallRight))
        {
            if (_rigidbody.velocity.y < 0)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f);
            }
        }
    }

    private void WallGrab()
    {
        isWallGrabbing = (
            (_collisionDetection.onWallLeft && Input.GetKey(moveLeft)) ||
            (_collisionDetection.onWallRight && Input.GetKey(moveRight)));
        
        if (isWallGrabbing)
        {
            float directionY = 0;
            _rigidbody.gravityScale = 0;
            if (Input.GetKey(jump))
            {
                directionY += 1;
            }

            if (Input.GetKey(down))
            {
                directionY -= 1;
            }
            
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, directionY * climbSpeed);
        }
        else
        {
            _rigidbody.gravityScale = 1;
        }
    }

    private void CheckJump()
    {
        jumpPressRemember -= Time.deltaTime;
        if (Input.GetKeyDown(jump))
        {
            jumpPressRemember = jumpPressedRememberTime;
        }

        groundRemember -= Time.deltaTime;
        if (_collisionDetection.onGround || _collisionDetection.onPlayer)
        {
            groundRemember = groundRememberTimer;
        }
        
        if ((groundRemember > 0) && (jumpPressRemember > 0))
        {
            jumpPressRemember = 0;
            groundRemember = 0;
            _jumpScript.StartJump();
        }
    }

    private void CheckMove()
    {
        direction = 0;
        
        if (Input.GetKey(moveLeft))
        {
            direction = -1;
            if (reverseSpriteFlipper) _spriteRenderer.flipX = true;
            else _spriteRenderer.flipX = false;
        }
        
        if (Input.GetKey(moveRight))
        {
            direction = 1;
            
            if (reverseSpriteFlipper) _spriteRenderer.flipX = false;
            else _spriteRenderer.flipX = true;
        }
        
        //_walkScript.Move(direction);
    }
    
    void SetAnimations()
    {
        if (_collisionDetection.onGround)
        {
            if(_animator.GetBool("IsJumping")) _animator.SetBool("IsJumping", false); 
        }
        else _animator.SetBool("IsJumping", true);

        if (_collisionDetection.onPlayer)
        {
            if(!_animator.GetBool("IsRiding")) _animator.SetBool("IsRiding", true);
        }
        else _animator.SetBool("IsRiding", false);
        
        if (_collisionDetection.belowPlayer){ _animator.SetBool("IsCarry", true); }
        else _animator.SetBool("IsCarry", false);
    }

    public void SetHappy()
    {
        _animator.SetBool("IsHappy", true);
    }
}
