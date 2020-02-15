using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckAnimationController : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TriggerEnter");
        if (other.gameObject.tag == "Untagged")
        {
            animator.SetBool("IsJumping", false);
        }
        else if (other.gameObject.tag == "Player")
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsRiding", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("TriggerExit");
        if (other.gameObject.tag == "Untagged")
        {
            animator.SetBool("IsJumping", true);
        }
        else if (other.gameObject.tag == "Player")
        {
            animator.SetBool("IsRiding", false);
            animator.SetBool("IsJumping", true);
        }
    }
}
