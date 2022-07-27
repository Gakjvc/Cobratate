using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public int health = 3;
    public bool playerIsDead;
    //--Movement
    public float jumpForce = 3f;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public float jumpMaxTime= 1f;
    bool grounded;
    bool stoppedJumping;
    Rigidbody2D rb;
    float jumpTimeCounter;
    //--Movement
    private void Start()
    {
        playerIsDead = false;
        //--Movement
        jumpTimeCounter = jumpMaxTime;
        rb = GetComponent<Rigidbody2D>();
        //--Movement
    }
    void Update()
    {
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
       // Debug.Log("Grounded: " + grounded);
        Debug.Log("Stopped jumping: " + stoppedJumping);
       // Debug.Log("ButtonUp: " + Input.GetButtonUp("Jump"));
        //--Movement
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
        //--Movement
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            PlayerDie();
        }
    }
    void PlayerDie()
    {
        playerIsDead = true;
    }
}
