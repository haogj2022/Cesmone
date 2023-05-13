using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 24/04/2023
//Object(s) holding this script: Lightning
//Summary: Enemies take damage when lightning hit them

public class LightningSpell : MonoBehaviour
{
    float lightningDuration = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LightningStrike());
    }

    IEnumerator LightningStrike()
    {
        yield return new WaitForSeconds(lightningDuration);
        Destroy(gameObject);
    }
}
