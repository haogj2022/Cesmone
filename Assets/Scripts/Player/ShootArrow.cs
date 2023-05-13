using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 24/04/2023
//Object(s) holding this script: Arrow
//Summary: Enemies take damage when arrow hit them

public class ShootArrow : MonoBehaviour
{
    float arrowDuration = 1;

    void Start()
    {
        StartCoroutine(ArrowHit());
    }

    IEnumerator ArrowHit()
    {
        yield return new WaitForSeconds(arrowDuration);
        Destroy(gameObject);
    }
}
