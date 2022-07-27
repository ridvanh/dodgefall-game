using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MovementController
{
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void PlayJumpingAnim()
    {
        animator.SetBool("isJumping", true);
    }

    public void PlayIdleAnim()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
    }

    public void PlayRunningAnim()
    {
        animator.SetBool("isRunning", true);
        animator.SetBool("isJumping", false);
    }
    
    public void PlayHurtAnim()
    {
        animator.SetTrigger("isHurt");
        
    }
    
    public void PlayDeathAnim()
    {
        
    }
}
