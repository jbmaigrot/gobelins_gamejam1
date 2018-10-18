using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer
{
    private Animator MyAnimator;

    [SerializeField]
    protected float movementSpeed = 5;
    [SerializeField]
    protected float maxSpeed = 40;

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    //Handles running
    public Vector2 HandleMovement(float horizontal, Vector2 v)
    {
        v.x = horizontal * 2 * movementSpeed;
        MyAnimator.SetFloat("PlayerSpeed", Mathf.Abs(horizontal));
        return v;
    }

    public void Initialize(Animator MyAnimator)
    {
        this.MyAnimator = MyAnimator;
    }


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

    //Handles running
    /*public void HandleAccelerationMovement(float horizontal, AnimationCurve curve, Vector2 v)
    {
        if ( moveTime < maxMoveTime)
        {
            v.x = maxSpeed * curve.Evaluate(moveTime / maxMoveTime);
            moveTime += Time.deltaTime;
        }
    }*/
}

