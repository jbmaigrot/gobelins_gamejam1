using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    //Other movements variables
    public Rigidbody2D MyRigidbody { get; set; }


    // Dash variables
    private Dash dashAction;
    private MovePlayer moveAction;
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
        moveAction.initialize(MyRigidbody);
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
        else
        {
            moveAction.HandleMovement(horizontal);
        }
    }


    private void HandleInput(float horizontal)
    {
        // Dash input
        if (Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown("joystick button 2"))
        {
            dashAction.StartDash(horizontal, 0);
        }
    }
}
