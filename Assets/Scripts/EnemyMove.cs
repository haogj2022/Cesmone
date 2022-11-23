using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    GameObject target;    
    Vector2 direction;

    public float health;
    public float moveSpeed;

    private float knockbackDelay = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Castle");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        direction = (target.transform.position - transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Castle")
        {
            StartCoroutine(Knockback());
        }

        if (collision.tag == "Map")
        {
            direction = (target.transform.position - transform.position).normalized;
        }
    }

    IEnumerator Knockback()
    {
        yield return new WaitForSeconds(knockbackDelay);
        direction = transform.position - target.transform.position;
        rb.velocity = new Vector2(direction.x * knockbackDelay, direction.y * knockbackDelay);
        yield return new WaitForSeconds(knockbackDelay);
        direction = (target.transform.position - transform.position).normalized;
    }

    public void TakeDamage(float damage)
    {
        anim.SetTrigger("isHurt");
        health = health - damage;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetTrigger("isAttack");

        MoveEnemy();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void MoveEnemy()
    {
        if (target != null)
        {            
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
    }
}
