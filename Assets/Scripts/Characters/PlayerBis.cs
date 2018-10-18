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
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Transform[] groundPoints;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask groundMask;
    private bool isGrounded;
    private bool jump;


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
        isGrounded = IsGrounded(rb);

        // Dash
        if (dashAction.IsDashing)
        {
            v = dashAction.Dashing(v);
        }
        else if (dashButton)
        {
            dashAction.StartDash(horizontal, 0);
        }
        else
        {
            v = moveAction.HandleMovement(horizontal, v);
        }
        rb.velocity = v;
        if (jumpButton)
        {
            Jump();
        }

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

    private void Jump()
    {
        // Player is not grounded when he jump
        if (isGrounded && jump)
        {
            jump = false;
            Debug.Log(rb.name);
            //rb.AddForce(new Vector2(10,10));
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded(Rigidbody2D MyRigidbody)
    {
        if (MyRigidbody.velocity.y <= 0)
        {
            //MyRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            foreach (Transform point in groundPoints)
            {
                //Gets the colliders on the player's feet
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, groundMask);

                for (int i = 0; i < colliders.Length; i++)
                {
                    //If the colliders collide with something else than the player, then the players is grounded
                    if (colliders[i].gameObject != gameObject && colliders[i].gameObject.CompareTag("Floor"))
                    {
                        jump = true;
                        return true;
                    }
                }
            }
        }
        return false;

    }


}
