using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Rb;
    private SpriteRenderer spriteRenderer; //flip x-y
    private float InputDirection;
    public int speed;
    public int jumpPower;
    private Animator anim;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }
    private void FixedUpdate()
    {
        Movement();
        if (GoundCheck.IsGrounded == false)
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Run", false);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }
    public void CheckInput()
    {
        InputDirection = Input.GetAxisRaw("Horizontal");
        if (InputDirection < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (InputDirection > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetButtonDown("Jump") && GoundCheck.IsGrounded)
        {
            Rb.velocity = new Vector2(Rb.velocity.x, jumpPower);
        }
    }
    private void Movement()
    {
        Rb.velocity = new Vector2(speed * InputDirection, Rb.velocity.y);
        if(Rb.velocity.x != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        
    }

}
