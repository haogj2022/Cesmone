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

    HeroAttack[] heroAttack;

    public float joystickOffset = 0.7f;

    public bool canMove = false;
    private bool facingRight = true;

    private void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentsInChildren<Animator>();
        joystick.gameObject.SetActive(false);
        heroAttack = GetComponentsInChildren<HeroAttack>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            joystick.gameObject.SetActive(true);

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
            foreach (HeroAttack hero in heroAttack)
            {
                hero.isRunning = true;
            }

            foreach (Animator anim in anim)
            {
                anim.SetBool("isIdling", false);
                anim.SetBool("isRunning", true);
                anim.SetBool("canAttack", false);
            }
            
            rb.velocity = new Vector2(joystick.Horizontal * moveSpeed, joystick.Vertical * moveSpeed);
        }
        else
        {
            foreach (HeroAttack hero in heroAttack)
            {
                hero.isRunning = false;
            }

            foreach (Animator anim in anim)
            {
                anim.SetBool("isIdling", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("canAttack", false);
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

