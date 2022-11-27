using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Vector2 localScale;
    EnemyMove enemy;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        enemy = GetComponentInParent<EnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = enemy.currentHealth / enemy.maxHealth;
        transform.localScale = localScale;
    }
}
