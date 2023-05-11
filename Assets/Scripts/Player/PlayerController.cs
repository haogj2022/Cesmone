using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 29/11/2022
//Object(s) holding this script: Hero Selection
//Summary: Move character with joystick

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public SpriteRenderer[] heroes;

    public float moveSpeed;       
    public bool isActive = false; 
    
    float joystickHandlePos = 0.4f;
    
    Rigidbody2D rb;   
    Animator[] anim;
    
    void Start()
    {      
        //get rigid body component
        rb = GetComponent<Rigidbody2D>();

        //get all the components from children
        anim = GetComponentsInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when player collides with enemy
        if (collision.gameObject.tag == "Enemy")
        {
            //ignore collision between them
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }

    void Update()
    {
        MoveHandle();        
    }

    //called by Update() when player move joystick's handle
    void MoveHandle()
    {
        //when joystick is enabled
        if (isActive)
        {
            //show the joystick on screen
            joystick.gameObject.SetActive(true);

            //enable movement
            PlayerCanMove();

            //when character moves to the right
            if (joystick.Horizontal > 0)
            {
                //character faces right
                FlipRight();
            }

            //when character moves to the left
            if (joystick.Horizontal < 0)
            {
                //character faces left
                FlipLeft();
            }
        }
        else //when joystick is not enable
        {
            //character stop moving
            StopMoving();

            //hide the joystick on screen
            joystick.gameObject.SetActive(false);
        }
    }

    //called by MoveHandle() to move character around
    void PlayerCanMove()
    {
        //when player drags the joystick's handle
        if (joystick.Horizontal > joystickHandlePos || joystick.Horizontal < -joystickHandlePos || 

            joystick.Vertical > joystickHandlePos || joystick.Vertical < -joystickHandlePos)
        {
            //play the running animations
            foreach (Animator anim in anim)
            {
                anim.SetBool("isIdling", false);
                anim.SetBool("isRunning", true);
            }
            
            //move the character to drag direction
            rb.velocity = new Vector2(joystick.Horizontal * moveSpeed, joystick.Vertical * moveSpeed);
        }
        else //when player does not drag the handle
        {
            //character stop moving
            StopMoving();
        }
    }

    //called by MoveHandle() and PlayerCanMove()
    //to make character stop moving
    void StopMoving()
    {
        //play the idling animations
        foreach (Animator anim in anim)
        {
            anim.SetBool("isIdling", true);
            anim.SetBool("isRunning", false);
        }

        //character stop moving
        rb.velocity = Vector2.zero;
    }

    //called by MoveHandle() to make character face left
    void FlipLeft()
    {
        foreach(SpriteRenderer hero in heroes)
        {
            hero.flipX = true;
        }
    }

    //called by MoveHandle() to make character face right
    void FlipRight()
    {
        foreach (SpriteRenderer hero in heroes)
        {
            hero.flipX = false;
        }
    }
}