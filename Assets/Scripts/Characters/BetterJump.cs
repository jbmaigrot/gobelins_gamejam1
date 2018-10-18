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
        if (body.velocity.y < -0.1f)
        {
            body.gravityScale = falling*2;
        }
        else if (body.velocity.y > 0.1 && !Input.GetButton(playerName + "Jump"))
        {
            body.gravityScale = jumping*2;
        }
        else
        {
            body.gravityScale = 1f;
        }
    }
}
