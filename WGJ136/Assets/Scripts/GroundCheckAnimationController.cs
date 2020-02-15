using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckAnimationController : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsCarry", false);
        animator.SetBool("IsRiding", false);
        animator.SetBool("IsHappy", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Untagged"))
        {
            animator.SetBool("IsJumping", false);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsRiding", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Untagged"))
        {
            animator.SetBool("IsJumping", true);
        }
        else if (other.gameObject.tag == "Player")
        {
            animator.SetBool("IsRiding", false); ;
        }
    }
}
