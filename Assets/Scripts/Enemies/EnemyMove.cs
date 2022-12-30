using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 18/11/2022
//Object(s) holding this script: All game objects with 'Enemy' tag
//Summary: Enemies move toward castle building

public class EnemyMove : MonoBehaviour
{
    public GameObject coin;
    public GameObject damageText;
    
    public float currentHealth;
    public float maxHealth;
    public float moveSpeed;
    public float numOfCoins;

    float knockedbackDelay = 0.2f;
    float pushedDelay = 1;
    bool facingRight = true;

    Vector2 direction;
    
    SpriteRenderer self;
    Rigidbody2D rb;
    GameObject target;
    PlayerStats num;
    
    void Start()
    {
        //get sprite renderer component
        self = GetComponent<SpriteRenderer>();

        //find the castle game object in hierarchy
        target = GameObject.Find("Castle");

        //get rigid body component
        rb = GetComponent<Rigidbody2D>();

        //set the direction to the castle
        direction = (target.transform.position - transform.position).normalized;

        //set the new health
        currentHealth = maxHealth;
    }

    private void OnTriggerExit2D(Collider2D collision)
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

        //ignore collision with walls and coins
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Coin")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }    

    //called by HeroAttack.Attack() when hero deals damage to enemy
    public void TakeDamage(float damage)
    {   
        GameObject dmg = Instantiate(damageText, transform.position, Quaternion.identity);
        dmg.transform.GetChild(0).GetComponent<TMP_Text>().text = "" + damage;       
        
        //when enemy is still alive
        if (currentHealth > 0)
        {
            //enemy is knocked back
            StartCoroutine(Knockedback());

            //enemy takes damage
            currentHealth = currentHealth - damage;
        }                                                             
    }

    //called by OnCollisionEnter2D() when enemy hit castle
    IEnumerator Pushed()
    {
        //enemy is pushed in opposite direction to the castle
        direction = transform.position - target.transform.position;

        //wait for a few seconds
        yield return new WaitForSeconds(pushedDelay);

        //enemy goes back to the castle
        direction = (target.transform.position - transform.position).normalized;
    }

    //called by TakeDamage() when enemy takes damage
    IEnumerator Knockedback()
    {   
        //change color of enemy to red
        self.color = Color.red;        
        
        //enemy is knocked back in opposite direction to the castle
        direction = transform.position - target.transform.position;

        //wait for a few seconds
        yield return new WaitForSeconds(knockedbackDelay);
        
        //change color of enemy to white
        self.color = Color.white;
        
        //enemy goes back to the castle
        direction = (target.transform.position - transform.position).normalized;
    }

    void Update()
    {
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
        //when enemy's health reaches zero
        if (currentHealth <= 0)
        {
            EnemyDeath();
        }

        //when castle is not destroyed
        if (target != null)
        {            
            //enemy moves to the castle
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed); 
        }
    }

    //called by MoveEnemy() when enemy is killed by player
    void EnemyDeath() 
    {
        //increase number of enemy killed
        num = GameObject.Find("Win & Lose Screen").GetComponent<PlayerStats>();
        num.enemyKilled++;

        //drop a number of coins
        for (int i = 0; i < numOfCoins; i++)
        {
            //drop a coin
            Instantiate(coin, transform.position, Quaternion.identity);
        }

        //remove the enemy from the game
        Destroy(gameObject);
    }
}