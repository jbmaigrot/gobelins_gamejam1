using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private static Player instance;

    private Vector3 startPosition;

    //Other movements variables
    public Rigidbody2D MyRigidbody { get; set; }


    // Dash variables
    private Dash dashAction;
    [SerializeField]
    private float dashForce;
    [SerializeField]
    private float dashDuration;

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    public override void Start()
    {
        base.Start();
        startPosition = transform.position;
        MyRigidbody = GetComponent<Rigidbody2D>();

        // Dash initialisation
        dashAction = new Dash
        {
            DashDuration = dashDuration,
            DashForce = dashForce
        };
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);

        HandleInput(horizontal);
        // Dash
        if (dashAction.IsDashing)
        {
            dashAction.Dashing(MyRigidbody);
        }
        else
        {
            HandleMovement(horizontal);
        }
    }

    //Handles running, sliding and jumping of the player
    private void HandleMovement(float horizontal)
    {
        MyRigidbody.velocity = new Vector2(horizontal * movementSpeed, MyRigidbody.velocity.y);
    }

    //Makes the player turn the other way
    private void Flip(float horizontal)
    {
        //If the player is not sliding or jumping, the player faces the other direction
        if ((horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight))
        {
            ChangeDirection();
        }
    }

    private void HandleInput(float horizontal)
    {
        // Dash input
        if (Input.GetKeyDown(KeyCode.V))
        {
            dashAction.StartDash(horizontal, 0);
        }
    }
}
