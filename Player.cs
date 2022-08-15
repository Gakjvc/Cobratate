using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    float invicibilityTimer;
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
        playerIsDead = false;
        //--Movement
        jumpTimeCounter = jumpMaxTime;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //this.GetComponent<Animator>().SetFloat("AnimSpeed")
        if (isInvincible)
        {
            invicibilityTimer -= Time.deltaTime;
            if(invicibilityTimer <=0)
            {
                isInvincible = false;
            }
            FlashSprite();
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
        //--Movement
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
    public void TakeDamage(int damage)
    {
        if (isInvincible)
        {
            return;
        }
        health -= damage;
        isInvincible = true;
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
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        float flashTimer = timeBetweenFlashes;
        flashTimer -= Time.deltaTime;

        if (flashTimer < 0)
        {
            if (sr.enabled)
            {
        Debug.Log("SHouldCALL");
                sr.enabled = false;
            }
            else
            {
                sr.enabled = true;
            }
            flashTimer = timeBetweenFlashes;
        }
    }
}
