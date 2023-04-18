using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapAttack : MonoBehaviour
{
    public float damage;

    EnemyMove enemy;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //when enemies are within attack range
        if (collision.tag == "Enemy")
        {
            //get component from enemy
            enemy = collision.GetComponent<EnemyMove>();

            anim.SetBool("canAttack", true);
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //when enemies are within attack range
        if (collision.tag == "Enemy")
        {
            anim.SetBool("canAttack", false);
        }
    }

    public void Attack()
    {
        enemy.TakeDamage(damage, false);
    }
}
