using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 18/04/2023
//Object(s) holding this script: Hero Selection
//Summary: Place spike trap at player's position

public class PlaceSpikeTrap : MonoBehaviour
{
    public GameObject spikeTrap;

    //called when place spike trap button is clicked
    public void PlaceTrap()
    {
        //place spike trap in front of player
        spikeTrap.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
    }
}
