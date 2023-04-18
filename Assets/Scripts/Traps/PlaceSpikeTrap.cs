using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSpikeTrap : MonoBehaviour
{
    public GameObject spikeTrap;

    public void PlaceTrap()
    {
        spikeTrap.transform.position = transform.position;
    }
}
