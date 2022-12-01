using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 20/11/2022
//Summary: Deal damage to enemies

public class HeroAttack : MonoBehaviour
{
    Animator anim;
    EnemyMove enemy;

    GameObject player;

    public float damage;
    public bool isRunning = false;

    bool canAttack = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Hero Selection");
    }

    private void FixedUpdate()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && !isRunning)
        {
            canAttack = true;

            enemy = collision.GetComponent<EnemyMove>();

            anim.SetBool("isIdling", false);
            anim.SetBool("isRunning", false);
            StartCoroutine(AttackDelay());
        }
    }

    IEnumerator AttackDelay()
    {       
        anim.SetBool("canAttack", true);
        yield return new WaitForSeconds(1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            canAttack = false;

            if (isRunning)
            {
                anim.SetBool("isIdling", false);
                anim.SetBool("isRunning", true);
                anim.SetBool("canAttack", false);
            }
            
            if (!isRunning)
            {
                anim.SetBool("isIdling", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("canAttack", false);
            }
        }
    }

    public void Attack()
    { 
        if (enemy.currentHealth > 0 && canAttack)
        {
            enemy.TakeDamage(damage); 
        }      
    }
}
