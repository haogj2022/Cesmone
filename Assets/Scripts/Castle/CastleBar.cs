using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 29/11/2022
//Object(s) holding this script: Castle bar
//Summary: Display castle's health bar

public class CastleBar : MonoBehaviour
{
    Vector2 localScale;

    CastleHealth castle;

    void Start()
    {   
        //get component from parent
        castle = GetComponentInParent<CastleHealth>();

        //set the default scale
        localScale = transform.localScale;
    }

    void Update()
    {
        //calculate the scale by dividing current health and max health
        localScale.x = castle.currentHealth / castle.maxHealth;

        //set the new scale
        transform.localScale = localScale;
    }
}