using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 07/12/2022
//Object(s) holding this script: Coin
//Summary: Enemies drop coins upon death

public class EnemyCoin : MonoBehaviour
{
    PlayerStats coin;

    void Start()
    {
        //find the Win & Lose Screen object in hierarchy
        coin = GameObject.Find("Win & Lose Screen").GetComponent<PlayerStats>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //when collide with player
        if (collision.gameObject.tag == "Player")
        {
            //increase number of coins
            coin.coinsCollected++;
            coin.totalCoins++;

            //remove object from screen
            Destroy(gameObject);
        }
    }
}
