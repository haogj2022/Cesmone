using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 20/11/2022
//Object(s) holding this script: Male sword, Male staff, Male bow
//                               Female sword, Female staff, Female bow
//Summary: Deal damage to enemies

public class HeroAttack : MonoBehaviour
{
    Animator anim;
    EnemyMove enemy;
    GameObject player;

    public float damage;
    public bool isRunning = false;

    bool canAttack = false;

    void Start()
    {
        //get animator component
        anim = GetComponent<Animator>();

        //find the hero selection game object in hierarchy
        player = GameObject.Find("Hero Selection");
    }

    private void FixedUpdate()
    {
        //follow the hero selection game object
        transform.position = player.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //when enemies are within attack range
        if (collision.tag == "Enemy")
        {
            //when character is not running
            if (!isRunning)
            {
                //character can attack
                canAttack = true;

                //get component from enemy
                enemy = collision.GetComponent<EnemyMove>();

                //play the attacking animation
                anim.SetBool("isIdling", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("canAttack", true);
            }            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //when enemies are out of attack range
        if (collision.tag == "Enemy")
        {
            //character cannot attack
            canAttack = false;

            //when character is running
            if (isRunning)
            {
                //play the running animation
                anim.SetBool("isIdling", false);
                anim.SetBool("isRunning", true);
                anim.SetBool("canAttack", false);
            }            
            else //when character is not running
            {
                //play the idling animation
                anim.SetBool("isIdling", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("canAttack", false);
            }
        }
    }

    //when character attacks an enemy
    public void Attack()
    { 
        //when enemy is still alive
        if (enemy.currentHealth > 0)
        {
            //when enemy is within range
            if (canAttack)
            {
                //enemy takes damage
                enemy.TakeDamage(damage);
            }            
        }      
    }
}