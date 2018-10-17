using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour {
    private Rigidbody2D rb;
    public string name;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis(name + "Horizontal");
        rb.velocity = new Vector2(horizontal * 10, rb.velocity.y);

        if(Input.GetButtonDown(name+"Jump"))
        {
            Debug.Log("Jump");
        }

        if (Input.GetButtonDown(name + "Dash"))
        {
            Debug.Log("Dash");

        }

        if (Input.GetAxis(name + "LT")>0 || Input.GetAxis(name + "RT")>0)
        {
            Debug.Log("BW");

        }

    }
}
