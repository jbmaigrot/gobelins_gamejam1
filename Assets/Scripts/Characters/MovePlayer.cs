using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer
{

    private Rigidbody2D MyRigidbody;
    private bool isMoving;

    [SerializeField]
    protected float movementSpeed = 10;
    [SerializeField]
    protected float maxSpeed = 40;
    [SerializeField]
    protected float Acceleration = 15;
    [SerializeField]
    protected float Deceleration = 1000;
    private float moveTime = 0;
    public float maxMoveTime = 0.5f;

    protected bool isFacingRight;



    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        //Flip(horizontal);
        //HandleMovement(horizontal);
    }

    //Handles running
    public Vector2 HandleSingleMovement(float horizontal, Vector2 v)
    {
        //MyRigidbody.velocity = new Vector2(horizontal * 2 * movementSpeed, MyRigidbody.velocity.y);

        /*if(horizontal < -0.1f)
        {
            if(MyRigidbody.velocity.x > -maxSpeed)
            {
                MyRigidbody.AddForce(new Vector2(-Acceleration, 0.0f));
            }
            else
            {
                MyRigidbody.velocity = new Vector2(-maxSpeed, MyRigidbody.velocity.y);
            }
        }
        else if (horizontal > 0.1f)
        {
            if (MyRigidbody.velocity.x < maxSpeed)
            {
                MyRigidbody.AddForce(new Vector2(Acceleration, 0.0f));
            }
            else
            {
                MyRigidbody.velocity = new Vector2(maxSpeed, MyRigidbody.velocity.y);
            }
        }*/
        v = new Vector2(horizontal * 2 * movementSpeed, v.y);
        //MyAnimator.SetFloat("speed", Mathf.Abs(horizontal));
        /*isMoving = true;
        MyRigidbody.velocity = new Vector2(MyRigidbody.velocity.x + Acceleration * horizontal, MyRigidbody.velocity.y);*/
        return v;
    }

    //Handles running
    public void HandleAccelerationMovement(float horizontal, AnimationCurve curve)
    {
        if ( moveTime < maxMoveTime)
        {
            MyRigidbody.velocity = new Vector2(maxSpeed * curve.Evaluate(moveTime / maxMoveTime), MyRigidbody.velocity.y);
            moveTime += Time.deltaTime;
        }
    }

    //Makes the player turn the other way
    public void Flip(float horizontal)
    {
        //If the player is not sliding or jumping, the player faces the other direction
        if ((horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        isFacingRight = !isFacingRight;
        MyRigidbody.transform.localScale = new Vector3(MyRigidbody.transform.localScale.x * -1, MyRigidbody.transform.localScale.y, MyRigidbody.transform.localScale.z);
    }

    public void Initialize(Rigidbody2D myRigidbody)
    {
        MyRigidbody = myRigidbody;
        isFacingRight = true;
    }

    public void DontMove()
    {
        isMoving = false;
        moveTime = 0;
    }

    public bool GetIsMoving()
    {
        return isMoving;
    }
}

