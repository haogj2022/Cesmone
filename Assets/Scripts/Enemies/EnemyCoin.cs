using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Destroy(gameObject);
        }

        //ignore collision with walls
        if (collision.gameObject.tag == "Wall")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
}
