using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBis : MonoBehaviour
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
    [SerializeField]
    private float dashForce;
    [SerializeField]
    private float dashDuration;

    //Jump variables

    public Transform groundCheck;

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

        v = rb.velocity;
        Flip(horizontal);

        // Dash
        if (dashAction.IsDashing)
        {
            v = dashAction.Dashing(v);
        }
        else if (dashButton)
        {
            dashAction.StartDash(horizontal, 0);
        }
        else if (jumpButton)
        {
 
        }
        else
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

}
