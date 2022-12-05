using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 29/11/2022
//Summary: Display enemy's health

public class EnemyHealth : MonoBehaviour
{
    Vector2 localScale;
    EnemyMove enemy;

    void Start()
    {
        localScale = transform.localScale;
        enemy = GetComponentInParent<EnemyMove>();
    }

    void Update()
    {
        localScale.x = enemy.currentHealth / enemy.maxHealth;
        transform.localScale = localScale;
    }
}