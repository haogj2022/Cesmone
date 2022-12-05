using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 29/11/2022
//Summary: Display castle's health bar

public class CastleBar : MonoBehaviour
{
    Vector2 localScale;
    CastleHealth castle;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        castle = GetComponentInParent<CastleHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = castle.currentHealth / castle.maxHealth;
        transform.localScale = localScale;
    }
}