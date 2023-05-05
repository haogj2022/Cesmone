using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float speed = 10;
    float arrowDuration = 1;
    bool canFly = true;

    EnemyBehaviour enemy;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(ArrowHit());
    }

    IEnumerator ArrowHit()
    {
        yield return new WaitForSeconds(arrowDuration);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (canFly)
        {
            rb.velocity = new Vector2(transform.position.x * speed, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            canFly = false;
        }
    }
}
