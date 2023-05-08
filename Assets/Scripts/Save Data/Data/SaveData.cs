using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float totalCoins;

    //Set default values when the game starts
    public SaveData()
    {
        totalCoins = 0;
    }
}
