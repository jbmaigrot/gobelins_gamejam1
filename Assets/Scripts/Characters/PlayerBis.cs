﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerBis : MonoBehaviour
{
    public Animator MyAnimator { get; private set; }

    [SerializeField]
    private RuntimeAnimatorController whiteController;

    [SerializeField]
    private RuntimeAnimatorController blackController;

    [SerializeField]
    private GameObject switchEffectWhitePrefab;
    [SerializeField]
    private GameObject switchEffectBlackPrefab;
    [SerializeField]
    private GameObject dashPrefab;
    [SerializeField]
    private GameObject landPrefab;
    [SerializeField]
    private GameObject jumpPrefab;

    [SerializeField]
    private string playerName;
    protected bool isFacingRight;
    protected bool canMove;
    private int health;
    private Shake shake;

    //Other movements variables
    public Rigidbody2D rb { get; set; }
    Vector2 v;

    // Dash variables
    private Dash dashAction;
    private MovePlayer moveAction;
    [SerializeField]
    private float dashForce;
    [SerializeField]
    private float dashDuration;

    //Jump variables
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Transform[] groundPoints;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask groundMask;
    private bool isGrounded;
    private bool canJump;
    private bool switchOn;

    //Inputs
    float horizontal;
    bool dashButton;
    bool jumpButton;

    public void Start()
    {
        MyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = true;
        canMove = true;
        health = 3;
        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        // Dash initialisation
        dashAction = new Dash
        {
            DashDuration = dashDuration,
            DashForce = dashForce
        };

        // Move initialisation
        moveAction = new MovePlayer();
        moveAction.Initialize(MyAnimator);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        GetInputs();
        HandleLayers();

        v = rb.velocity;
        if (canMove)
        {
            Flip(horizontal);
        }
        isGrounded = IsGrounded(rb);

        if (v.y < -0.2)
        {
            MyAnimator.SetBool("Land", true);
        }

        // Dash
        if (dashAction.IsDashing)
        {
            v = dashAction.Dashing(v);
        }
        else if (dashButton)
        {
            dashAction.StartDash(0, isFacingRight, MyAnimator);
            StartCoroutine("DashEffect");
        }
        else
        {
            if (canMove)
            {
                v = moveAction.HandleMovement(horizontal, v);
            }
        }
        rb.velocity = v;
        if (jumpButton)
        {
            Jump();
            StartCoroutine(JumpEffect(horizontal));
            //GamePad.SetVibration(PlayerIndex.Two, 1, 1);
            //GamePad.SetVibration(PlayerIndex.One, 1, 1);
        }

        if ((Input.GetAxis(playerName + "LT") == 1 || Input.GetAxis(playerName + "RT") == 1) && switchOn)
        {
            StartCoroutine(Switch());
        }
        else if ((Input.GetAxis(playerName + "LT") == 0 || Input.GetAxis(playerName + "RT") == 0) && !switchOn)
        {
            switchOn = true;
        }


    }

    private void GetInputs()
    {
        horizontal = Input.GetAxis(playerName + "Horizontal");
        dashButton = Input.GetButtonDown(playerName + "Dash");
        jumpButton = Input.GetButtonDown(playerName + "Jump");
    }

    //Makes the player turn the other way
    public void Flip(float horizontal)
    {
        //If needed, the player faces the other direction
        if ((horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        isFacingRight = !isFacingRight;
        rb.transform.localScale = new Vector3(rb.transform.localScale.x * -1, rb.transform.localScale.y, rb.transform.localScale.z);
    }

    private void Jump()
    {
        // Player is not grounded when he jump
        if (isGrounded && canJump)
        {
            canJump = false;
            isGrounded = false;
            MyAnimator.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
    }

    private bool IsGrounded(Rigidbody2D MyRigidbody)
    {
        if (MyRigidbody.velocity.y <= 0.2)
        {
            //MyRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            foreach (Transform point in groundPoints)
            {
                //Gets the colliders on the player's feet
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, groundMask);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject && (colliders[i].gameObject.CompareTag("Floor") || ((this.gameObject.layer == 9 && colliders[i].gameObject.layer == 8) || (this.gameObject.layer == 8 && colliders[i].gameObject.layer == 9))))
                    {
                        //If the colliders collide with something else than the player, then the players is grounded
                        canJump = true;
                        MyAnimator.ResetTrigger("Jump");
                        if (MyAnimator.GetBool("Land"))
                        {
                            MyAnimator.SetBool("Land", false);
                            StartCoroutine("LandEffect");
                        }
                        return true;
                    }
                }
            }
        }
        return false;

    }

    private IEnumerator DamagePlayer()
    {
        health--;
        //shake.CamShake();
        canMove = false;
        rb.velocity = new Vector2(0, 0);
        Time.timeScale = 0.5f;
        MyAnimator.SetTrigger("Damage");
        yield return new WaitForSeconds(0.7f);
        MyAnimator.ResetTrigger("Damage");
        Time.timeScale = 1f;
    }

    private bool IsDead()
    {
        return health <= 0;
    }

    private void RespawnPlayer(Vector2 respawnPosition)
    {
        rb.position = respawnPosition;
        canMove = true;
    }

    //Changes the weight of animator layers
    private void HandleLayers()
    {
        //If the player is in the air, AirLayer is the main layer
        if (!isGrounded)
        {
            MyAnimator.SetLayerWeight(1, 1);
        }

        //If the player is on the ground, the ground layer is the main layer
        else
        {
            MyAnimator.SetLayerWeight(1, 0);
        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            Vector2 resPoint = GameObject.Find("RespawnPoint").transform.position;
            StartCoroutine(DamagePlayer());
            if (!IsDead())
            {
                yield return new WaitForSeconds(0.7f);
                RespawnPlayer(resPoint);
            }
            else
            {
                //écran de fin
            }
        }
    }
    private IEnumerator Switch()
    {
        GameObject temporaryPrefab = null;
        if (this.gameObject.layer == 9)
        {
            this.gameObject.layer = 8;
            this.gameObject.GetComponent<Animator>().runtimeAnimatorController = whiteController as RuntimeAnimatorController;
            temporaryPrefab = switchEffectWhitePrefab;
        }
        else
        {
            this.gameObject.layer = 9;
            this.gameObject.GetComponent<Animator>().runtimeAnimatorController = blackController as RuntimeAnimatorController;
            temporaryPrefab = switchEffectBlackPrefab;
        }
        
        GameObject temporaryEffect = (GameObject)Instantiate(temporaryPrefab, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.Euler(0, 0, 0));
        temporaryEffect.transform.SetParent(transform);
        switchOn = false;
        yield return new WaitForSeconds(0.1f);
        Destroy(temporaryEffect);
    }

    private IEnumerator DashEffect()
    {
        GameObject temporaryEffect = null;
        if (isFacingRight)
            temporaryEffect = (GameObject)Instantiate(dashPrefab, new Vector2(transform.position.x - 1.5f, transform.position.y - 0.5f), Quaternion.Euler(0, 0, 0));
        else
            temporaryEffect = (GameObject)Instantiate(dashPrefab, new Vector2(transform.position.x + 1.5f, transform.position.y - 0.5f), Quaternion.Euler(0, 0, 180));
        //temporaryEffect.transform.SetParent(transform);
        yield return new WaitForSeconds(0.1f);
        Destroy(temporaryEffect);
    }


    private IEnumerator LandEffect()
    {
        GameObject temporaryEffect = null;
        temporaryEffect = (GameObject)Instantiate(landPrefab, new Vector2(transform.position.x, transform.position.y - 0.8f), Quaternion.Euler(0, 0, 0));
        temporaryEffect.transform.SetParent(transform);
        yield return new WaitForSeconds(0.2f);
        Destroy(temporaryEffect);
    }

    private IEnumerator JumpEffect(float horizontal)
    {
        GameObject temporaryEffect = null;
        if (horizontal > 0)
            temporaryEffect = (GameObject)Instantiate(jumpPrefab, new Vector2(transform.position.x - 1f, transform.position.y - 0.8f), Quaternion.Euler(0, 0, 0));
        else if (horizontal < 0)
            temporaryEffect = (GameObject)Instantiate(jumpPrefab, new Vector2(transform.position.x + 1f, transform.position.y - 0.8f), Quaternion.Euler(0, 180, 0));
        else if (horizontal == 0)
            temporaryEffect = (GameObject)Instantiate(jumpPrefab, new Vector2(transform.position.x, transform.position.y - 0.8f), Quaternion.Euler(0, 0, 20));

        temporaryEffect.transform.SetParent(transform);
        yield return new WaitForSeconds(0.2f);
        Destroy(temporaryEffect);
    }
}
