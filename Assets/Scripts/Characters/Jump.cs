using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump {
    private Animator MyAnimator;
    private bool isJumping = false;
    private bool isLanding = false;
    private float jumpTime = 0;
    private float maxJumpTime;
    private float jumpSpeed;
    private Transform player;
    private Transform groundCheck;
    private AnimationCurve jumpCurve = AnimationCurve.Linear(0, 0, 1, 0);

    public Vector2 QuickJump(Vector2 v)
    {
        isJumping = true;
        jumpTime += Time.deltaTime;
        v.y = jumpSpeed;
        return v;
    }

    public Vector2 LongJump(Vector2 v)
    {
        v.y = jumpSpeed * JumpCurve.Evaluate(jumpTime / maxJumpTime);
        jumpTime += Time.deltaTime;
        return v;
    }

    public void Land()
    {
        if (isJumping && jumpTime < maxJumpTime)
        {
            isJumping = false;
            isLanding = true;
            jumpTime = 0;
        }
    }

    public bool IsJumping()
    {
        return isJumping && jumpTime < maxJumpTime;
    }

    public bool IsGrounded()
    {
        if (Physics2D.Linecast(player.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) || Physics2D.Linecast(player.position, groundCheck.position, player.gameObject.layer))
        {
            MyAnimator.ResetTrigger("Jump");
            return true;
        }
        else
            return false;
    }

    public void Initialize(Animator animator)
    {
        MyAnimator = animator;
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
