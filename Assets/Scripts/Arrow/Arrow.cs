using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
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
