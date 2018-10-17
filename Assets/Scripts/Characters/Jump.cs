using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump {

    private bool grounded = false;
    private bool jump = false;
    private float jumpTime = 0;
    private float maxJumpTime;
    private float jumpSpeed;
    private int layer;
    private Transform player;
    private Transform groundCheck;
    private AnimationCurve jumpCurve = AnimationCurve.Linear(0, 0, 1, 0);

    // Update is called once per frame
    public Vector2 HandleJump (Vector2 v) {
        /*if (player.gameObject.layer == 9)
        {
            layer = 8;
        }
        else
        {
            layer = 9;
        }*/
        grounded = Physics2D.Linecast(player.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) || Physics2D.Linecast(player.position, groundCheck.position, player.gameObject.layer);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
            jumpTime += Time.deltaTime;
            v.y = jumpSpeed;
        }
        else if (Input.GetButton("Jump") && jump && jumpTime < maxJumpTime)
        {
            v.y = jumpSpeed * JumpCurve.Evaluate(jumpTime / maxJumpTime);
            jumpTime += Time.deltaTime;
        }
        else
        {
            jump = false;
            jumpTime = 0;
        }

        Debug.Log("Speed : "  + v);
        return v;
    }

    //Getters and setters
    public float MaxJumpTime
    {
        get
        {
            return maxJumpTime;
        }

        set
        {
            maxJumpTime = value;
        }
    }

    public float JumpSpeed
    {
        get
        {
            return jumpSpeed;
        }

        set
        {
            jumpSpeed = value;
        }
    }

    public Transform GroundCheck
    {
        get
        {
            return groundCheck;
        }

        set
        {
            groundCheck = value;
        }
    }

    public AnimationCurve JumpCurve
    {
        get
        {
            return jumpCurve;
        }

        set
        {
            jumpCurve = value;
        }
    }

    public Transform Player
    {
        get
        {
            return player;
        }

        set
        {
            player = value;
        }
    }
}
