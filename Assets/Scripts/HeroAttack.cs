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
        if (collision.tag == "Enemy")
        {
            enemy = collision.GetComponent<EnemyMove>();
            anim.SetBool("canAttack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            anim.SetBool("canAttack", false);
        }
    }

    public void Attack()
    { 
        if (enemy.currentHealth > 0)
        {
            enemy.TakeDamage(damage); 
        }      
    }
}
