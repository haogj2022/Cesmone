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

    public float damage;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemy = collision.GetComponent<EnemyMove>();
            StartCoroutine(AttackDelay());
        }
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("isAttack");
    }

    public void Attack()
    { 
        if (enemy.currentHealth > 0)
        {
            enemy.TakeDamage(damage); 
        }      
    }
}
