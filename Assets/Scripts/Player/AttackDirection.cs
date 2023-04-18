using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 18/04/2023
//Object(s) holding this script: All game objects with 'Hitbox' tags
//Summary: Control the attack direction of staff and bow heroes with joystick

public class AttackDirection : MonoBehaviour
{
    public Joystick joystick;

    // Update is called once per frame
    void Update()
    {
        //bind the control of attack direction to joystick
        Vector3 moveVector = (Vector3.up * joystick.Horizontal + Vector3.left * joystick.Vertical);

        //when player moves the joystick's handle
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {            
            //rotate the attack direction to the handle direction
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);            
        }
    }
}
