using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {

    public float falling = 2.5f;
    public float jumping = 2f;
    [SerializeField]
    private string playerName;

    private Rigidbody2D body;
    // Use this for initialization
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //falling
        if (body.velocity.y < -0.2f)
        {
            body.gravityScale = falling;
        }
        else if (body.velocity.y > 0 && !Input.GetButtonDown(playerName + "Jump"))
        {
            body.gravityScale = jumping;
        }
        else
        {
            body.gravityScale = 1f;
        }
    }
}
