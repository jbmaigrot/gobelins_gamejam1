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

    public Vector2 Dashing (Vector2 v)
    {
            // End of dash
            if (dashCurrentTime >= dashDuration)
            {
                // Reset the dash settings
                dashCurrentTime = 0;
                IsDashing = false;
                // Stop velocity
                v = Vector2.zero;
            }
            else
            {
                // Continue the dash
                dashCurrentTime += Time.deltaTime;
                v.x = dashForce * direction.x;
                v.y = dashForce * direction.y;
            }
        return v;
    }

    public void StartDash(float vertical, bool isFacingRight)
    {
        isDashing = true;
        // Direction of the dash
        if (isFacingRight)
        {
            direction.x = 1;
        }
        else
            direction.x = -1;
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
