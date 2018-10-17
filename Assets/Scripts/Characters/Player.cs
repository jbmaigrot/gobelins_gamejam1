using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

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

    //public AnimationCurve curveX = AnimationCurve.Linear(0, 1, 1, 0);

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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
        moveAction.Initialize(rb);
    }

    // Update is called once per frame
    private void Update()
    {
    
    }

    private void FixedUpdate()
    {
        GetInputs();

        v = rb.velocity;

        // Dash
        if (dashAction.IsDashing)
        {
           
            v = dashAction.Dashing(v);
        }
        else if(dashButton)
        {
            
            dashAction.StartDash(horizontal, 0);
        }
        else
        {
            
            v = jumpAction.HandleJump(v);
            v = moveAction.HandleSingleMovement(horizontal, v);
        }

        rb.velocity = v;
    }

    private void GetInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        dashButton = Input.GetButtonDown("Dash");
    }
}
