using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 18/04/2023
//Object(s) holding this script: Player Character
//Summary: Place spike trap at player's position

public class PlaceTrap : MonoBehaviour
{
    public GameObject spikeTrap;
    public GameObject flameTrap;

    //called when spike trap button is clicked
    public void SpikeTrap()
    {
        //place spike trap in front of player
        spikeTrap.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
    }

    //called when flame trap button is clicked
    public void FlameTrap()
    {
        //place spike trap in front of player
        flameTrap.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
    }
}
