using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer
{
    private Animator MyAnimator;

    [SerializeField]
    protected float movementSpeed = 4;
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
}

