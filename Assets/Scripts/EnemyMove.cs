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

    private float knockbackDelay = 0.5f;
    private bool facingRight = true;

    // Start is called before the first frame update
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

        //when enemies hit the castle building
        if (collision.tag == "Castle" || collision.tag == "Enemy")
        {
            StartCoroutine(Knockback()); //enemies knock back
        }
    }

    IEnumerator Knockback()
    {
        //enemies knock back in opposite direction to target
        direction = transform.position - target.transform.position;
        rb.velocity = new Vector2(direction.x * knockbackDelay, direction.y * knockbackDelay);

        //enemies go back to target
        yield return new WaitForSeconds(knockbackDelay);
        direction = (target.transform.position - transform.position).normalized;
    }

    //when hero deals damage to enemies
    public void TakeDamage(float damage)
    {
        StartCoroutine(Knockback()); //enemies knock back
        anim.SetTrigger("isHurt"); 
        currentHealth = currentHealth - damage; //take damage                                                                
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetTrigger("isAttack");

        MoveEnemy(); //call the move function

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
            Destroy(gameObject);
        }

        Vector2 direction = (transform.position - target.transform.position);

        if (direction.x > 0 && !facingRight)
        {
            Flip();
        }

        if (direction.x < 0 && facingRight)
        {
            Flip();
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
