using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour {
    private Rigidbody2D rb;
    public string playerName;
    private Boolean switchOn;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        switchOn = true;
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis(playerName + "Horizontal");
        rb.velocity = new Vector2(horizontal * 10, rb.velocity.y);

        if(Input.GetButtonDown(playerName+"Jump"))
        {
        }

        if (Input.GetButtonDown(playerName + "Dash"))
        {

        }

        if ((Input.GetAxis(playerName + "LT") ==1 || Input.GetAxis(playerName + "RT") ==1) && switchOn)
        {
            if (this.gameObject.layer == 9)
                this.gameObject.layer = 8;
            else
                this.gameObject.layer = 9;
            switchOn = false;
        }
        else if((Input.GetAxis(playerName + "LT") == 0 || Input.GetAxis(playerName + "RT") == 0) && !switchOn)
        {
            switchOn = true;
        }

    }
}
