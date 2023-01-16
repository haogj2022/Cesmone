using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 14/12/2022
//Object(s) holding this script: Win & Lose Screen
//Summary: Show stats after player complete a level

public class PlayerStats : MonoBehaviour
{
    public GameObject[] stats;
    public TMP_Text[] num;

    public float currentTime = 0;
    public float enemiesKilled = 0;
    public float coinsCollected = 0;
    public float totalCoins = 0;
    
    public bool startTimer = false;

    CastleHealth castle;
    
    // Start is called before the first frame update
    void Start()
    {
        //find castle game object in hierarchy
        castle = GameObject.Find("Castle").GetComponent<CastleHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        SetStats();
    }

    //called by Update() to set new stats
    void SetStats()
    {
        //when timer is active
        if (startTimer)
        {
            //count the time passed every second
            currentTime += Time.deltaTime;
        }

        //when castle is not destroyed
        if (castle.currentHealth > 0)
        {
            //set the time text
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            num[0].text = "Clear Time: " + time.ToString(@"hh\:mm\:ss");
        }
        else //castle is destroyed
        {
            //player not complete the level yet
            num[0].text = "Clear Time: N/A";
        }

        //set the enemy killed text
        num[1].text = "Enemies Killed: " + enemiesKilled;

        //set the coin collected text
        num[2].text = "Coins Collected: " + coinsCollected;

        //set the total coin text
        num[3].text = "" + totalCoins;
    }
}
