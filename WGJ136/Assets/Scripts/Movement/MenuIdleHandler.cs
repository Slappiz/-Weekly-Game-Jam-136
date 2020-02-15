using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using WGJ136.Movement;

[RequireComponent(typeof(Rigidbody2D))]
public class MenuIdleHandler : MonoBehaviour
{
    private Jump _jumpScript;
    private Walk _walkScript;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private CollisionDetection _collisionDetection;

    public float jumpStart = 1f;
    public float jumpRepeatRate = 4f;
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _collisionDetection = GetComponent<CollisionDetection>();
        
        _jumpScript = new Jump(_rigidbody);
        _walkScript = new Walk(_rigidbody);
    }

    private void Start()
    {
        InvokeRepeating("CheckJump", jumpStart, jumpRepeatRate);
    }

    void Update()
    {
        _jumpScript.Update();
        SetAnimations();
    }

    private void CheckJump()
    {
        if (_collisionDetection.onGround || _collisionDetection.onPlayer)
        {
            _jumpScript.StartJump();
        }
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
}
