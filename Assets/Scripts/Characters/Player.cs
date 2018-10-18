using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator MyAnimator { get; private set; }
    [SerializeField]
    private string playerName;
    protected bool isFacingRight;

    //Other movements variables
    public Rigidbody2D rb { get; set; }
    Vector2 v;

    // Dash variables
    private Dash dashAction;
    private MovePlayer moveAction;
    private Jump jumpAction;
    [SerializeField]
    private float dashForce;
    [SerializeField]
    private float dashDuration;

    //Jump variables
    public float maxJumpTime = 0.5f;
    public float jumpSpeed = 61;
    public Transform groundCheck;
    public AnimationCurve jumpCurve = AnimationCurve.Linear(0, 0, 1, 0);

    //Inputs
    float horizontal;
    bool dashButton;
    bool jumpButton;

    public void Start()
    {
        MyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = true;

        // Dash initialisation
        dashAction = new Dash
        {
            DashDuration = dashDuration,
            DashForce = dashForce
        };

        // Jump initialisation
        jumpAction = new Jump
        {
            MaxJumpTime = maxJumpTime,
            JumpSpeed = jumpSpeed,
            GroundCheck = groundCheck,
            JumpCurve = jumpCurve,
            Player = transform
        };

        // Move initialisation
        moveAction = new MovePlayer();
        moveAction.Initialize(MyAnimator);
    }

    // Update is called once per frame
    private void Update()
    {
    
    }

    private void FixedUpdate()
    {
        GetInputs();
        HandleLayers();

        v = rb.velocity;
        Flip(horizontal);

        // Dash
        if (dashAction.IsDashing)
        {
            v = dashAction.Dashing(v);
        }
        else if(dashButton)
        {           
            dashAction.StartDash(horizontal, 0);
        }
        else if(jumpButton)
        {
            v = jumpAction.QuickJump(v);
        }
        else if (jumpButton && jumpAction.IsJumping())
        {
            v = jumpAction.LongJump(v);

        }
        else if (rb.velocity.y < 0)
        {
             MyAnimator.SetBool("Land", true);
            jumpAction.Land();
        }
        else if (!jumpAction.IsJumping())
        {
            v = moveAction.HandleMovement(horizontal, v);
        }

        rb.velocity = v;
    }

    private void GetInputs()
    {
        horizontal = Input.GetAxis(playerName + "Horizontal");
        dashButton = Input.GetButtonDown(playerName + "Dash");
        jumpButton = Input.GetButtonDown(playerName + "Jump");

    }

    //Makes the player turn the other way
    public void Flip(float horizontal)
    {
        //If needed, the player faces the other direction
        if ((horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        isFacingRight = !isFacingRight;
        rb.transform.localScale = new Vector3(rb.transform.localScale.x * -1, rb.transform.localScale.y, rb.transform.localScale.z);
    }

    //Changes the weight of animator layers
    private void HandleLayers()
    {
        //If the player is in the air, AirLayer is the main layer
        if (!jumpAction.IsGrounded())
        {
            MyAnimator.SetLayerWeight(1, 1);
        }

        //If the player is on the ground, the ground layer is the main layer
        else
        {
            MyAnimator.SetLayerWeight(1, 0);
        }
    }
}
