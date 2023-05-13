using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 07/12/2022
//Object(s) holding this script: Spike trap
//Summary: Enemies take damage when they step on spike trap

public class SpikeTrapBehavior : MonoBehaviour
{
    public float damage;

    bool canAttack = false;

    EnemyBehaviour enemy;
    Animator anim;
    AudioManager audioManager;

    void Start()
    {
        anim = GetComponent<Animator>();

        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //when enemies are within attack range
        if (collision.tag == "Enemy")
        {
            canAttack = true;
          
            if (canAttack)
            {   
                //get component from enemy
                enemy = collision.GetComponent<EnemyBehaviour>(); 
                
                //damage the enemy
                anim.SetBool("canAttack", true);
            }
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //when enemies are not within attack range
        if (collision.tag == "Enemy")
        {
            canAttack = false;

            //spike trap cannot attack
            anim.SetBool("canAttack", false);
        }
    }

    //called in spike trap animation when enemy takes damage
    public void Attack()
    {        
        //when enemy is still alive
        if (enemy.currentHealth > 0)
        {
            audioManager.Slash();
            
            if (canAttack)
            {
                audioManager.Damage();

                //enemy takes damage
                enemy.TakeDamage(damage, false);
            }
            else //enemy is dead
            {
                canAttack = false;

                return; //exit the code
            }
        }            
    }
}
