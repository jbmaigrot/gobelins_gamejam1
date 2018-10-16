﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Animator MyAnimator { get; private set; }

    [SerializeField]
    protected float movementSpeed;

    protected bool isFacingRight;

    // Use this for initialization
    public virtual void Start()
    {
        isFacingRight = true;
        MyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeDirection()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
