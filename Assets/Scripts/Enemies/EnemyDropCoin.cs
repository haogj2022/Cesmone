using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 07/12/2022
//Object(s) holding this script: Coin
//Summary: Enemies drop coins upon death

public class EnemyDropCoin : MonoBehaviour
{
    float moveSpeed = 5;

    LevelStats coin;
    GameObject player;
    Rigidbody2D rb;
    Vector2 direction;

    void Start()
    {
        //find the Win & Lose Screen object in hierarchy
        coin = GameObject.Find("Win & Lose Screen").GetComponent<LevelStats>();

        //get rigidbody component
        rb = GetComponent<Rigidbody2D>();

        //find the player
        player = GameObject.Find("Hero Selection");        
    }

    void Update()
    {
        //set the direction to the player
        direction = (player.transform.position - transform.position).normalized;

        //coin moves to player
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //when collide with player
        if (collision.tag == "Player")
        {
            //increase number of coins
            coin.coinsCollected++;
            coin.totalCoins++;

            //remove object from screen
            Destroy(gameObject);
        }        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //when coin hits castle or enemy or wall
        if (collision.gameObject.tag == "Castle" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall")
        {
            //ignore collision between them
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
}
