using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash {
    
    private Vector2 direction;
    private float dashCurrentTime;

    private bool isDashing;
    private float dashForce;
    private float dashDuration;

    void Start()
    {
        isDashing = false;
        // Default values
        dashForce = 30;
        dashDuration = 0.2f;
    }

    public void Dashing (Rigidbody2D player)
    {
            // End of dash
            if (dashCurrentTime <= 0)
            {
                // Reset the dash settings
                dashCurrentTime = dashDuration;
                IsDashing = false;
                // Stop velocity
                player.velocity = Vector2.zero;
            }
            else
            {
                // Continue the dash
                dashCurrentTime -= Time.deltaTime;
                player.velocity = new Vector2(dashForce * direction.x, dashForce * direction.y);
            }
    }

    public void StartDash(float horizontal, float vertical)
    {
        isDashing = true;
        // Direction of the dash
        direction.x = horizontal;
        direction.y = vertical;
    }

    /*
     * GETTERS & SETTERS
     */
    
    public float DashForce
    {
        get
        {
            return dashForce;
        }

        set
        {
            dashForce = value;
        }
    }

    public bool IsDashing
    {
        get
        {
            return isDashing;
        }

        set
        {
            isDashing = value;
        }
    }

    public float DashDuration
    {
        get
        {
            return dashDuration;
        }

        set
        {
            dashDuration = value;
        }
    }
}
