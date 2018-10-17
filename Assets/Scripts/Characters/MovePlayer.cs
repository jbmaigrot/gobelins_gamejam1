using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer
{

    private Rigidbody2D MyRigidbody;

    [SerializeField]
    protected float movementSpeed = 0;
    [SerializeField]
    protected float maxSpeed = 10;
    [SerializeField]
    protected float Acceleration = 2000;
    [SerializeField]
    protected float Deceleration = 200;

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
    public void HandleMovement(float horizontal)
    {
        //MyRigidbody.velocity = new Vector2(horizontal * 2 * movementSpeed, MyRigidbody.velocity.y);
        if ((horizontal<0) && (movementSpeed < maxSpeed))
        {
            movementSpeed = movementSpeed - Acceleration * Time.deltaTime;
            if (movementSpeed < -maxSpeed)
                movementSpeed = -maxSpeed;
        }

        else if ((horizontal > 0) && (movementSpeed > -maxSpeed))
        {
            movementSpeed = movementSpeed + Acceleration * Time.deltaTime;
            if (movementSpeed > maxSpeed)
                movementSpeed = maxSpeed;
        }
        else
        {
            if (movementSpeed > (Deceleration * Time.deltaTime)) 
         movementSpeed = movementSpeed - (Deceleration * Time.deltaTime);
         else if (movementSpeed < -(Deceleration * Time.deltaTime)) 
             movementSpeed = movementSpeed + (Deceleration * Time.deltaTime);
         else movementSpeed = 0;
        }

        Vector2 vector = new Vector2(MyRigidbody.transform.position.x + movementSpeed * Time.deltaTime, MyRigidbody.transform.position.y);
        MyRigidbody.transform.position = vector;
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

    public void initialize(Rigidbody2D myRigidbody)
    {
        MyRigidbody = myRigidbody;
        isFacingRight = true;
    }
}

