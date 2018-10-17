using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Other movements variables
    public Rigidbody2D MyRigidbody { get; set; }

    // Dash variables
    private Dash dashAction;
    private MovePlayer moveAction;
    [SerializeField]
    private float dashForce;
    [SerializeField]
    private float dashDuration;

    public AnimationCurve curveX = AnimationCurve.Linear(0, 1, 1, 0);

    public void Start()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();

        // Dash initialisation
        dashAction = new Dash
        {
            DashDuration = dashDuration,
            DashForce = dashForce
        };

        // Move initialisation
        moveAction = new MovePlayer();
        moveAction.Initialize(MyRigidbody);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        moveAction.Flip(horizontal);

        HandleInput(horizontal);

        // Dash
        if (dashAction.IsDashing)
        {
            dashAction.Dashing(MyRigidbody);
        }
        else if (Input.GetButtonDown("Horizontal"))
        {
            if (moveAction.GetIsMoving())
            {
                moveAction.HandleAccelerationMovement(horizontal, curveX);
            }
            else
                moveAction.HandleSingleMovement(horizontal);
        }
        else
        {
            moveAction.DontMove();
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
