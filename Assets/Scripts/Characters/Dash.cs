using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    private Rigidbody2D body;


    public float moveSpeed;

    private float direction;

    private bool isDashing;
    public float dashSpeed;
    public float dashLength;
    private float dashCurrentTime;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        isDashing = false;
  
    }

    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        HandleDash(horizontal);
    }

    private void HandleDash(float horizontal)
    {
        if(isDashing)
        {
            //End of dash
            if (dashCurrentTime <= 0)
            {
                //Reset the dash settings
                dashCurrentTime = dashLength;
                isDashing = false;

                //Stop velocity
                body.velocity = Vector2.zero;
            }
            else
            {
                dashCurrentTime -= Time.deltaTime;
                body.velocity = new Vector2(dashSpeed * direction, 0);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                isDashing = true;
                Debug.Log("d");
                if (horizontal > 0)
                {
                    direction = 1;
                }
                else if (horizontal < 0)
                {
                    direction = -1;
                }
            }
        }


    }

    /*
    private Rigidbody2D body;

    private bool dash;
    [SerializeField]
    private float dashForce;
    [SerializeField]
    private float dashSpeed;
    private float dashCurrentTime;
    public float dashTime;

    private float direction;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        HandleInput(horizontal);
        HandleMovement(horizontal);
        
    }

    private void HandleMovement(float horizontal)
    {
        if (dash)
        {
            dash = false;
            dashSpeed = dashForce;
            dashCurrentTime = dashTime;
        }
        else if (dashCurrentTime <= 0)
        {
            dashSpeed = 1;
        }
        else
        {
            dashCurrentTime -= Time.deltaTime;
        }

        body.velocity = new Vector2(direction * dashSpeed, body.velocity.y);

    }

    private void HandleInput(float horizontal)
    {
        // Pressing V
        if (Input.GetKeyDown(KeyCode.V))
        {
            dash = true;
        }
        if (horizontal!=0)
        {
            direction = horizontal;
        }

    }*/
}
