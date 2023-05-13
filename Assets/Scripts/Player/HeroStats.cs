using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 20/11/2022
//Object(s) holding this script: All game objects with 'Hero' tag
//Summary: Manage hero stats

public class HeroStats : MonoBehaviour
{
    public float damage;
    public float critChance;
    public float critDamage;
    public bool isCritical = false;
    public bool canUseLightning = false;
    public GameObject lightning;
    public bool canShootArrow = false;
    public GameObject arrow;
    public bool canUseSword = false;

    bool canAttack = false;
    float joystickHandlePos = 0.4f;

    Animator anim;
    EnemyBehaviour enemy;
    GameObject player;
    PlayerController handle;
    GameObject hitbox;
    AudioManager audioManager;

    void Start()
    {
        //get animator component
        anim = GetComponent<Animator>();

        handle = GetComponentInParent<PlayerController>();

        //find the hero selection game object in hierarchy
        player = GameObject.Find("Player Character");

        hitbox = GameObject.Find("Male Bow Hitbox");

        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        //follow the hero selection game object
        transform.position = player.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //when enemies are within attack range
        if (collision.tag == "Enemy")
        {
            //character is running
            if (handle.joystick.Horizontal > joystickHandlePos || handle.joystick.Horizontal < -joystickHandlePos ||

                handle.joystick.Vertical > joystickHandlePos || handle.joystick.Vertical < -joystickHandlePos)
            {
                //character cannot attack
                canAttack = false;
            }
            else //character is not running
            {
                //character can attack
                canAttack = true;

                //when character can attack
                if (canAttack)
                {
                    //get component from enemy
                    enemy = collision.GetComponent<EnemyBehaviour>();

                    //play the attacking animation
                    anim.SetBool("canAttack", true);
                }
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

            //disable attack animation
            anim.SetBool("canAttack", false);          
        }
    }

    //called in attack animation when character attacks an enemy
    public void Attack()
    { 
        //when enemy is still alive
        if (enemy.currentHealth > 0)
        {
            if (canUseLightning)
            {
                audioManager.Thunder();
                Instantiate(lightning, enemy.transform.position, Quaternion.identity);
            }
            else if (canShootArrow)
            {
                audioManager.Shoot();
                Instantiate(arrow, enemy.transform.position, hitbox.transform.rotation);               
            }
            else if (canUseSword)
            {
                audioManager.Slash();
            }            
                                    
            //when enemy is within range
            if (canAttack)
            {
                audioManager.Damage();  
                
                //random chance for crit attack
                float randValue = Random.Range(0, 100);

                //is a critical attack
                if (randValue < critChance)
                {
                    //enemy takes critical damage
                    float totalDamage = damage + critDamage;                   
                    enemy.TakeDamage(totalDamage, isCritical = true);
                }
                else //not a critical attack
                {
                    //enemy takes normal damage
                    enemy.TakeDamage(damage, isCritical = false);
                }                
            }
            else //enemy is dead
            {
                //exit the code
                return;
            }
        }        
    }    
}