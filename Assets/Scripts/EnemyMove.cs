using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 18/11/2022
//Summary: Enemies move toward castle building

public class EnemyMove : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    GameObject target;    
    Vector2 direction;

    public float health; 
    public float moveSpeed;

    private float knockbackDelay = 1;
     
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Castle");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        direction = (target.transform.position - transform.position).normalized; //go to target
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        //when enemies move out of the map
        if (collision.tag == "Map")
        {
            direction = (target.transform.position - transform.position).normalized; //go back to target
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when enemies hit the castle building
        if (collision.gameObject.tag == "Castle")
        {
            StartCoroutine(Knockback()); //enemies push back themselves
        }
    }

    IEnumerator Knockback()
    {
        //enemies push back themselves in opposite direction to target
        yield return new WaitForSeconds(knockbackDelay);
        direction = transform.position - target.transform.position;
        rb.velocity = new Vector2(direction.x * knockbackDelay, direction.y * knockbackDelay);

        //enemies go back to target
        yield return new WaitForSeconds(knockbackDelay);
        direction = (target.transform.position - transform.position).normalized;
    }

    //when hero deals damage to enemies
    public void TakeDamage(float damage)
    {
        anim.SetTrigger("isHurt");           
        health = health - damage; //take damage
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetTrigger("isAttack");

        MoveEnemy(); //call the move function

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //move enemies using Rigidbody2D
    void MoveEnemy()
    {
        if (target != null)
        {            
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
    }
}
