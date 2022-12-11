using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 29/11/2022
//Object(s) holding this script: Castle
//Summary: Show castle's health text

public class CastleHealth : MonoBehaviour
{
    Animator anim;
    TMP_Text healthText;

    public float currentHealth;
    public float maxHealth;

    void Start()
    {
        //get animator component
        anim = GetComponent<Animator>();
        
        //get component in children
        healthText = GetComponentInChildren<TMP_Text>();
        
        //set the new health
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when castle collides with enemies
        if (collision.gameObject.tag == "Enemy")
        {
            //when castle is not destroyed
            if(currentHealth > 0)
            {
                //play the hit animation
                anim.SetTrigger("isHit");

                //castle takes damage
                currentHealth = currentHealth - 1;
            }       
        }
    }

    void Update()
    {
        //show the health text
        healthText.text = currentHealth + "/" + maxHealth; 

        //when castle is destroyed
        if (currentHealth <= 0)
        {
            //play the destroyed animation
            anim.SetTrigger("isDestroyed");            
        }
        else
        {
            //play the reset animation
            anim.SetTrigger("isReset");
        }       
    }
}