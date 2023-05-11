using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
