using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 29/11/2022
//Object(s) holding this script: All game objects with 'Enemy' tag
//Summary: Display enemy's health

public class EnemyHealthBar : MonoBehaviour
{
    Vector2 localScale;

    EnemyBehaviour enemy;

    void Start()
    {
        //get component from parent
        enemy = GetComponentInParent<EnemyBehaviour>();

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