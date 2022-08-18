using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MovementController : Player
{
    public enum MovementStates
    {
        Idle,
        Running,
        Jumping,
        Dead
    }

    public enum FacingDirection
    {
        Right,
        Left
    }
    
    
    [Header("Groundcheck values")]
    public LayerMask groundableLayers;
    public float extraHeight = 0.25f;
    public bool groundChecker;

    [Header("Movement values")]
    public MovementStates characterMovementState;
    public FacingDirection facingDirection;

    public GameObject shield;
    
    protected Rigidbody2D rigidBody;
    protected SpriteRenderer spriteRenderer;
    protected BoxCollider2D boxCollider;
    protected AnimationController animController;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        animController = GetComponent<AnimationController>();
    }
    
    void Update()
    {
        HandleJump();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        SetCharacterDirection();
        SetCharacterState();
        PlayAnimations();
    }

    void HandleMovement()
    {
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity = new Vector2(-movementSpeed, rigidBody.velocity.y);
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidBody.velocity = new Vector2(movementSpeed, rigidBody.velocity.y);
            
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rigidBody.velocity = Vector2.up * jumpForce;
        }
    }
    
    bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider.bounds.center,
            boxCollider.bounds.size, 0f, Vector2.down, extraHeight, groundableLayers);
        Color rayColor;
        
        if (raycastHit2D.collider != null)
        {
            groundChecker = true;
            rayColor = Color.green;
        }
        else
        {
            groundChecker = false;
            rayColor = Color.red;
        }
        
        
        return raycastHit2D.collider != null;
    }
    
    protected void SetCharacterState()
    {
        if (IsGrounded())
        {
            if (rigidBody.velocity.x == 0)
            {
                characterMovementState = MovementStates.Idle;
            }
            else if (rigidBody.velocity.x > 0)
            {
                facingDirection = FacingDirection.Right;
                characterMovementState = MovementStates.Running;
            }
            else
            {
                facingDirection = FacingDirection.Left;
                characterMovementState = MovementStates.Running;
            }
        }
        else //if (characterMovementState != MovementStates.Hurt)
        {
            if (rigidBody.velocity.x >= 0)
            {
                facingDirection = FacingDirection.Right;
                characterMovementState = MovementStates.Jumping;
            }
            else
            {
                facingDirection = FacingDirection.Left;
                characterMovementState = MovementStates.Jumping;
            }
        }
        if (Health <= 0)
        {
            characterMovementState = MovementStates.Dead;
        }
    }
    
    protected void SetCharacterDirection()
    {
        switch (facingDirection)
        {
            case FacingDirection.Right:
                spriteRenderer.flipX = false;
                break;
            case FacingDirection.Left:
                spriteRenderer.flipX = true;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    protected void PlayAnimations()
    {
        switch (characterMovementState)
        {
            case MovementStates.Idle:
                animController.PlayIdleAnim();
                break;
            case MovementStates.Running:
                animController.PlayRunningAnim();
                break;
            case MovementStates.Jumping:
                animController.PlayJumpingAnim();
                break;
            case MovementStates.Dead:
                animController.PlayDeathAnim();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Fireball"))
        {
            animController.PlayHurtAnim();
            Health = Health - 1;
        }
    }*/
}
