using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 26/12/2022
//Object(s) holding this script: All game objects with 'Damage' tag
//Summary: Show enemy's damage

public class EnemyDamage : MonoBehaviour
{
    void Start()
    {          
        //destroy game object after a second
        Destroy(gameObject, 1);
    }
}