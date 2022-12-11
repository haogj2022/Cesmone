using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 07/12/2022
//Object(s) holding this script: Coin
//Summary: Enemies drop coins upon death

public class EnemyCoin : MonoBehaviour
{
    ReadInput coin;

    void Start()
    {
        coin = GameObject.Find("Hero Name").GetComponent<ReadInput>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coin.coinCollected++;
            coin.totalCoins++;
            Destroy(gameObject);
        }

        //ignore collision with walls
        if (collision.gameObject.tag == "Wall")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
}
