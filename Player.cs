using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player: MonoBehaviour
{
    public int damage =1;
    public int score;
    //--Health
    public int health = 3;
    public bool playerIsDead;
    public float timeInvincible;
    public float timeBetweenFlashes;
    bool isInvincible;
    bool firstCall;
    float flashTimer;
    float invicibilityTimer;
    SpriteRenderer sr;
    //--Movement
    public float jumpForce = 3f;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public float jumpMaxTime= 1f;
    bool grounded;
    bool stoppedJumping;
    Rigidbody2D rb;
    float jumpTimeCounter;
    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        playerIsDead = false;
        //--Movement
        jumpTimeCounter = jumpMaxTime;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isInvincible)
        {
            FlashSprite();
            invicibilityTimer -= Time.deltaTime;
            if(invicibilityTimer <=0)
            {
                isInvincible = false;
                sr.enabled = true;
            }
        }
        //--Movement
        grounded = Physics2D.OverlapCircle(this.transform.position, groundCheckRadius, whatIsGround);
        if (Input.GetButtonUp("Jump") && !stoppedJumping)
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
        if (grounded)
        {
            jumpTimeCounter = jumpMaxTime;
            stoppedJumping = false;
        }
    }
    private void FixedUpdate()
    {
        ManageInput();
    }
    public void TakeDamage(int damage)
    {
        if (isInvincible)
        {
            return;
        }
        health -= damage;
        isInvincible = true;
        firstCall = true;
        invicibilityTimer = timeInvincible;
        if (health <= 0)
        {
            PlayerDie();
        }
    }
    void PlayerDie()
    {
        playerIsDead = true;
    }
    void FlashSprite()
    {
        if (firstCall)
        {
            flashTimer = timeBetweenFlashes;
            firstCall = false;
        }
        flashTimer -= Time.deltaTime;

        if (flashTimer < 0)
        {
            if (sr.enabled)
            {
                sr.enabled = false;
            }
            else
            {
                sr.enabled = true;
            }
            flashTimer = timeBetweenFlashes;
        }
    }
    void ManageInput()
    {
        //Stoping Input from bleeding over the UI
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetButtonDown("Jump") && grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                stoppedJumping = false;
            }
            if ((Input.GetButton("Jump")) && !stoppedJumping)
            {
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
            }
        }
    }
}
