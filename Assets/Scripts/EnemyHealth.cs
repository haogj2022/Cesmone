using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 29/11/2022
//Object(s) holding this script: Health bar(Blue Slime),
//                               Health bar(Purple Slime),
//                               Health bar(Red Slime)
//Summary: Display enemy's health

public class EnemyHealth : MonoBehaviour
{
    Vector2 localScale;

    EnemyMove enemy;

    void Start()
    {
        //get component from parent
        enemy = GetComponentInParent<EnemyMove>();

        //set the default scale
        localScale = transform.localScale;        
    }

    void Update()
    {
        //calculate the scale by dividing current health and max health
        localScale.x = enemy.currentHealth / enemy.maxHealth; 

        //set the new scale
        transform.localScale = localScale;
    }
}