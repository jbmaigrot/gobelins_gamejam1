using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public Rigidbody2D MyRigidbody { get; set; }

    [SerializeField]
    protected float movementSpeed;
    [SerializeField]
    protected float maxSpeed = 25;
    [SerializeField]
    protected float Acceleration = 2000;
    [SerializeField]
    protected float Deceleration = 1;

    protected bool isFacingRight;

    // Use this for initialization
    void Start()
    {
        isFacingRight = true;
        MyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);
        HandleMovement(horizontal);
    }

    //Handles running
    private void HandleMovement(float horizontal)
    {
        //MyRigidbody.velocity = new Vector2(horizontal * 2 * movementSpeed, MyRigidbody.velocity.y);
        if ((Input.GetKey("left")) && (movementSpeed < maxSpeed))
            movementSpeed = movementSpeed - Acceleration * Time.deltaTime;
        else if ((Input.GetKey("right")) && (movementSpeed > -maxSpeed))
            movementSpeed = movementSpeed + Acceleration * Time.deltaTime;
        else
        {
            if (movementSpeed > (Deceleration * Time.deltaTime)) 
         movementSpeed = movementSpeed - (Deceleration * Time.deltaTime);
         else if (movementSpeed < -(Deceleration * Time.deltaTime)) 
             movementSpeed = movementSpeed + (Deceleration * Time.deltaTime);
         else movementSpeed = 0;
        }
        Vector2 vector = new Vector2(transform.position.x + movementSpeed * Time.deltaTime, MyRigidbody.transform.position.y);
        MyRigidbody.transform.position = vector;
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

    private void ChangeDirection()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}

