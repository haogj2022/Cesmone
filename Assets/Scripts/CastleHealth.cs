using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHealth : MonoBehaviour
{
    Animator anim;

    public float currentHealth;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && currentHealth > 0)
        {
            anim.SetTrigger("isHit");
            currentHealth = currentHealth - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            anim.SetTrigger("isDestroyed");
        }
    }
}
