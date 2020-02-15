using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheckAnimationController : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TriggerEnter");
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("IsCarry", true); ;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("IsCarry", false); ;
        }
    }
}
