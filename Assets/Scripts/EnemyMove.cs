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

    public float currentHealth;
    public float maxHealth;
    public float moveSpeed;

    float knockedbackDelay = 0.2f;
    float pushedDelay = 2;

    bool facingRight = true;

    ReadInput num;

    void Start()
    {
        target = GameObject.Find("Castle");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        direction = (target.transform.position - transform.position).normalized; //go to target
        currentHealth = maxHealth;
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
        //when enemies hit the castle
        if (collision.gameObject.tag == "Castle")
        {
            StartCoroutine(Pushed()); //enemies are pushed back
        }

        //ignore collision with walls around the map
        if (collision.gameObject.tag == "Wall")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }

    IEnumerator Pushed()
    {
        //enemies are pushed back in opposite direction to target
        direction = transform.position - target.transform.position;
        rb.velocity = new Vector2(direction.x * knockedbackDelay, direction.y * knockedbackDelay);

        //enemies go back to target
        yield return new WaitForSeconds(pushedDelay);
        direction = (target.transform.position - transform.position).normalized;
    }

    //when hero deals damage to enemies
    public void TakeDamage(float damage)
    {
        StartCoroutine(Knockedback()); //enemies are knocked back
        anim.SetTrigger("isHurt"); 
        currentHealth = currentHealth - damage; //take damage                                                                
    }
    
    IEnumerator Knockedback()
    {
        //enemies are knocked back in opposite direction to target
        direction = transform.position - target.transform.position;
        rb.velocity = new Vector2(direction.x * knockedbackDelay, direction.y * knockedbackDelay);

        //enemies go back to target
        yield return new WaitForSeconds(knockedbackDelay);
        direction = (target.transform.position - transform.position).normalized;
    }

    void Update()
    {
        anim.SetTrigger("isAttack");

        MoveEnemy(); //enemies are moving

        if (transform.position.y > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0; 
        }

        if (transform.position.y < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3; 
        }
       
        if (currentHealth <= 0)
        {
            num = GameObject.Find("Hero Name").GetComponent<ReadInput>();
            num.enemyKilled++; //increase number of enemies killed
            Destroy(gameObject);
        }

        Vector2 direction = (transform.position - target.transform.position);

        //go to the right
        if (direction.x > 0 && !facingRight)
        {
            Flip(); //face right
        }

        //go to the left
        if (direction.x < 0 && facingRight)
        {
            Flip(); //face left
        }
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;
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