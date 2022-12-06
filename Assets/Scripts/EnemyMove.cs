using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 18/11/2022
//Object(s) holding this script: Blue Slime, Purple Slime, Red Slime
//Summary: Enemies move toward castle building

public class EnemyMove : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    GameObject target;  
    ReadInput num;

    Vector2 direction;

    public float currentHealth;
    public float maxHealth;
    public float moveSpeed;

    float knockedbackDelay = 0.2f;
    float pushedDelay = 2;
    bool facingRight = true;
   
    void Start()
    {
        //find the castle game object in hierarchy
        target = GameObject.Find("Castle");

        //get rigid body component
        rb = GetComponent<Rigidbody2D>();

        //get animator component
        anim = GetComponent<Animator>();

        //set the direction to the castle
        direction = (target.transform.position - transform.position).normalized;

        //set the new health
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        //when enemy moves out of the map
        if (collision.tag == "Map")
        {
            //enemy goes back to the castle
            direction = (target.transform.position - transform.position).normalized;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when enemy hits the castle
        if (collision.gameObject.tag == "Castle")
        {
            //enemy is pushed back
            StartCoroutine(Pushed());
        }

        //ignore collision with walls around the map
        if (collision.gameObject.tag == "Wall")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }

    //called by OnCollisionEnter2D() when enemy hit the castle
    IEnumerator Pushed()
    {
        //enemy is pushed back in opposite direction to the castle
        direction = transform.position - target.transform.position;
        rb.velocity = new Vector2(direction.x * knockedbackDelay, direction.y * knockedbackDelay);

        //wait for a few seconds
        yield return new WaitForSeconds(pushedDelay);
        
        //enemy goes back to the castle
        direction = (target.transform.position - transform.position).normalized;
    }

    //when hero deals damage to enemy
    public void TakeDamage(float damage)
    {   
        //play the hurt animation
        anim.SetTrigger("isHurt");
        
        //enemy is knocked back
        StartCoroutine(Knockedback());

        //enemy takes damage
        currentHealth = currentHealth - damage;                                                               
    }

    //called by TakeDamage() when enemy takes damage
    IEnumerator Knockedback()
    {
        //enemy is knocked back in opposite direction to the castle
        direction = transform.position - target.transform.position;
        rb.velocity = new Vector2(direction.x * knockedbackDelay, direction.y * knockedbackDelay);

        //wait for a few seconds
        yield return new WaitForSeconds(knockedbackDelay);
        
        //enemy goes back to the castle
        direction = (target.transform.position - transform.position).normalized;
    }

    void Update()
    {
        //play attack animation
        anim.SetTrigger("isAttack");

        //move enemy to the castle
        MoveEnemy(); 

        //calculate the distance between enemy and castle
        Vector2 distance = (transform.position - target.transform.position);

        //when enemy moves to the right
        if (distance.x > 0 && !facingRight)
        {
            //enemy faces right
            Flip(); 
        }

        //when enemy moves to the left
        if (distance.x < 0 && facingRight)
        {
            //enemy faces left
            Flip(); 
        }
    }

    //called by Update() to face enemy in correct direction
    void Flip()
    {
        //declare a new Vector3 for a new scale
        Vector3 currentScale = transform.localScale;

        //flip the enemy
        currentScale.x *= -1;

        //set the new scale
        transform.localScale = currentScale;

        //change the facing direction
        facingRight = !facingRight;
    }

    //called by Update() to move enemy to the castle
    void MoveEnemy()
    {
        //when enemy is spawned on top of the map
        if (transform.position.y > 0)
        {
            //set the sprite renderer's sorting layer to behind character
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }

        //when enemy is spawned at bottom of the map
        if (transform.position.y < 0)
        {
            //set the sprite renderer's sorting layer to in front of character
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }

        //when enemy's health reaches zero
        if (currentHealth <= 0)
        {
            //increase number of enemy killed
            num = GameObject.Find("Hero Name").GetComponent<ReadInput>();
            num.enemyKilled++;

            //remove the enemy from the game
            Destroy(gameObject);
        }

        //when castle is not destroyed
        if (target != null)
        {            
            //enemy moves to the castle
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed); 
        }
        else //when castle is destroyed
        {
            //enemy stop moving
            rb.velocity = Vector2.zero;
        }
    }
}