using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 26/12/2022
//Object(s) holding this script: All game objects with 'Damage' tag
//Summary: Show enemy's damage

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        //show enemy's damage
        transform.localPosition = new Vector3(0, 1, 0);
        
        //destroy game object after a second
        Destroy(gameObject, 1);
    }
}