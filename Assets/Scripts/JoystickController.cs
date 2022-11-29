using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 29/11/2022
//Summary: Move character with joystick

public class JoystickController : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D rb;

    public Joystick joystick;

    Animator[] anim;

    Camera cam;

    float joystickOffset = 0.7f;

    public bool canMove = false;
    private bool facingRight = true;

    private void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentsInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            UpDownLeftRight();        
            
            if (joystick.Horizontal > 0 && !facingRight)
            {
                Flip();
            }

            if (joystick.Horizontal < 0 && facingRight)
            {
                Flip();
            }
        }
    }

    void UpDownLeftRight()
    {
        if (joystick.Horizontal > joystickOffset || joystick.Horizontal < -joystickOffset || 

            joystick.Vertical > joystickOffset || joystick.Vertical < -joystickOffset)
        {
            foreach (Animator anim in anim)
            {
                anim.SetTrigger("isRunning");
            }
            
            rb.velocity = new Vector2(joystick.Horizontal * moveSpeed, joystick.Vertical * moveSpeed);
        }
        else
        {
            foreach (Animator anim in anim)
            {
                anim.SetTrigger("isIdling");
            }

            rb.velocity = Vector2.zero;
        }
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}

