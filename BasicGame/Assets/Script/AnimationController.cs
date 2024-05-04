using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
    }


}
