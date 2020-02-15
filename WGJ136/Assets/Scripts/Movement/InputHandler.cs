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

     [Header("Settings")] 
    public bool reverseSpriteFlipper;
    public float slideSpeed = .1f;
        
    private Jump _jumpScript;
    private Walk _walkScript;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private CollisionDetection _collisionDetection;
    
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
        CheckMove();
        CheckJump();
        _jumpScript.Update();
        SetAnimations();
        WallSlide();
    }

    private void WallSlide()
    {
        if (!_collisionDetection.onGround && _collisionDetection.onWall)
        {
            _rigidbody.velocity = new Vector2(
                _rigidbody.velocity.x, 
                _rigidbody.velocity.y - slideSpeed * Time.deltaTime);
        }
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(jump) && (_collisionDetection.onGround || _collisionDetection.onPlayer))
        {
            _jumpScript.StartJump();
        }
    }

    private void CheckMove()
    {
        Vector2 direction = Vector2.zero;
        
        if (Input.GetKey(moveLeft))
        {
            direction.x -= 1;
            if (reverseSpriteFlipper) _spriteRenderer.flipX = true;
            else _spriteRenderer.flipX = false;
        }
        
        if (Input.GetKey(moveRight))
        {
            direction.x += 1;
            
            if (reverseSpriteFlipper) _spriteRenderer.flipX = false;
            else _spriteRenderer.flipX = true;
        }
        
        _walkScript.Move(direction);
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
