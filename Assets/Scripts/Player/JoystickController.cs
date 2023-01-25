using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 29/11/2022
//Object(s) holding this script: Hero Selection
//Summary: Move character with joystick

public class JoystickController : MonoBehaviour
{
    public Joystick joystick;

    public float moveSpeed = 5;
    public float handleOffset = 0.7f;   
    public bool isActive = false; 
    
    bool facingRight = true;
    
    Rigidbody2D rb;   
    Animator[] anim;
    
    void Start()
    {      
        //get rigid body component
        rb = GetComponent<Rigidbody2D>();

        //get all the components from children
        anim = GetComponentsInChildren<Animator>();

        //set joystick offset
        handleOffset = 0.7f;
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
            UpDownLeftRight();

            //when character moves to the right
            if (joystick.Horizontal > 0 && !facingRight)
            {
                //character faces right
                Flip();
            }

            //when character moves to the left
            if (joystick.Horizontal < 0 && facingRight)
            {
                //character faces left
                Flip();
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
    void UpDownLeftRight()
    {
        //when player fully drags the joystick's handle
        if (joystick.Horizontal > handleOffset || joystick.Horizontal < -handleOffset || 

            joystick.Vertical > handleOffset || joystick.Vertical < -handleOffset)
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
        else //when player does not fully drag the joystick's handle
        {
            //character stop moving
            StopMoving();
        }
    }

    //called by MoveHandle() and UpDownLeftRight() 
    //to stop character from moving
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

    //called by MoveHandle() to face character in correct direction
    void Flip()
    {
        //declare a new Vector3 for a new scale
        Vector3 currentScale = transform.localScale;

        //flip the character
        currentScale.x *= -1;

        //set the new scale
        transform.localScale = currentScale;

        //change the facing direction
        facingRight = !facingRight; 
    }
}