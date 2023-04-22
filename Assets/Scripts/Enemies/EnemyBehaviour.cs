using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 18/11/2022
//Object(s) holding this script: All game objects with 'Enemy' tag
//Summary: Manage enemy behavior

//state of enemy behaviour
public enum EnemyState
{
    normal,
    scared
}

public class EnemyBehaviour : MonoBehaviour
{    
    public GameObject coin;
    public GameObject damageText;
    
    public float currentHealth;
    public float maxHealth;
    public float moveSpeed;
    public float numOfCoins;

    float hurtTime = 0.1f;
    float runawayTime = 3;
    bool facingRight = true;

    Vector2 direction;
    EnemyState currentState; 
   
    SpriteRenderer self;
    Rigidbody2D rb;
    GameObject castle;
    GameObject player;
    PlayerStats num;
    
    void Start()
    {
        //get sprite renderer component
        self = GetComponent<SpriteRenderer>();

        //find the castle and player game object in hierarchy
        castle = GameObject.Find("Castle");
        player = GameObject.Find("Hero Selection");

        //get rigid body component
        rb = GetComponent<Rigidbody2D>();

        //set the direction to the castle
        direction = (castle.transform.position - transform.position).normalized;

        //set the new health
        currentHealth = maxHealth;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {       
        //when enemy moves out of the map
        if (collision.tag == "Map")
        {
            //enemy goes back to the castle
            direction = (castle.transform.position - transform.position).normalized;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when enemy hit the castle or hit each other
        if (collision.gameObject.tag == "Castle" || collision.gameObject.tag == "Enemy")
        {
            //enemy is scared
            StartCoroutine(RunAwway(runawayTime));
        }

        //when enemy touch wall or coin
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Coin")
        {
            //ignore wall and ignore coin
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }    

    //called by HeroAttack.Attack() when hero deals damage to enemy
    public void TakeDamage(float damage, bool isCrit)
    {      
        //check for enemy state
        switch (currentState)
        {
            //when enemy is normal
            case EnemyState.normal:
                
                //enemy take damage
                FromPlayer(damage, isCrit);
                
                //enemy is scared
                StartCoroutine(RunAwway(runawayTime));

                break; //exit the code

            //when enemy is scared
            case EnemyState.scared:

                //enemy can still take damage
                FromPlayer(damage, isCrit);

                break; //exit the code
        }                                               
    }

    //called by TakeDamage() when enemy is scared
    IEnumerator RunAwway(float time)
    {
        //enemy is scared
        currentState = EnemyState.scared;

        //wait for a few seconds
        yield return new WaitForSeconds(time);

        //enemy back to normal
        currentState = EnemyState.normal;
    }

    //called by TakeDamage() when player attack enemy
    void FromPlayer(float damage, bool isCrit)
    {
        //show damage taken
        GameObject dmg = Instantiate(damageText, transform.position, Quaternion.identity);

        //is critical damage
        if (isCrit)
        {
            //change damage text color to yellow
            dmg.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.yellow;

            //set damage text
            dmg.transform.GetChild(0).GetComponent<TMP_Text>().text = damage + " \n critical";
        }
        else //is not critical damage
        {
            //set damage text
            dmg.transform.GetChild(0).GetComponent<TMP_Text>().text = damage + "";
        }

        //when enemy is still alive
        if (currentHealth > 0)
        {
            //enemy is knocked back
            StartCoroutine(HitBy(player));

            //enemy takes damage
            currentHealth = currentHealth - damage;
        }

        //when enemy's health reaches zero
        if (currentHealth <= 0)
        {
            EnemyDeath();
        }
    }

    //called by TakeDamage() when enemy takes damage
    IEnumerator HitBy(GameObject target)
    {
        //when player hit enemy
        if (target == player)
        {
            //change color of enemy to red
            self.color = Color.red;

            //wait for a few seconds
            yield return new WaitForSeconds(hurtTime);

            //change color of enemy to white
            self.color = Color.white;
        }
    }    

    void Update()
    {
        //enemy is normal
        if (currentState == EnemyState.normal)
        {
            //attack the castle
            EnemyAttack();
        }
        
        //enemy is scared
        if (currentState == EnemyState.scared)
        {
            //enemy runs away from player
            EnemyRunAway();
        }
    }    

    //called by Update() to make enemy attack the castle
    void EnemyAttack()
    {                 
        //calculate distance between enemy and castle
        Vector2 distance = (transform.position - castle.transform.position);
            
        //enemy moves to the castle
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

        FaceDirection(distance);                 
    }

    //called by Update() to make enemy run away
    void EnemyRunAway()
    {
        //calculate distance between player and enemy
        Vector2 distance = (player.transform.position - transform.position);

        //enemy run away from player
        rb.velocity = new Vector2(-direction.x * moveSpeed, -direction.y * moveSpeed);

        FaceDirection(distance);
    }

    //called by EnemyAttack() and EnemyRunAway() to check enemy facing direction
    void FaceDirection(Vector2 distance)
    {
        //enemy moves to the right
        if (distance.x > 0)
        {
            //when enemy is not facing right
            if (!facingRight)
            {
                //make enemy face right
                Flip();
            }
        }

        //enemy moves to the left
        if (distance.x < 0)
        {
            //when enemy is not facing left
            if (facingRight)
            {
                //make enemy face left
                Flip();
            }
        }
    }

    //called by FaceDirection() to make enemy face correct direction
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

    //called by TakeDamage() when enemy get damage from player
    void EnemyDeath() 
    {
        //increase number of enemy killed
        num = GameObject.Find("Win & Lose Screen").GetComponent<PlayerStats>();
        num.enemiesKilled++;

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