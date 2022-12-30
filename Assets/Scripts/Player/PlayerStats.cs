using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 14/12/2022
//Object(s) holding this script: Hero Name
//Summary: Show stats after player complete a level

public class PlayerStats : MonoBehaviour
{
    public GameObject[] stats;
    
    public float currentTime = 0;
    public float enemyKilled = 0;
    public float coinCollected = 0;
    public float totalCoins = 0;
    
    public bool startTimer = false;
    
    public TMP_Text timerText;
    public TMP_Text numOfEnemyKilled;
    public TMP_Text numOfCoinsCollected;
    public TMP_Text numOfTotalCoins;

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
            timerText.text = "Clear Time: " + time.ToString(@"mm\:ss\:fff");
        }
        else //castle is destroyed
        {
            //player not complete the level yet
            timerText.text = "Clear Time: N/A";
        }

        //set the enemy killed text
        numOfEnemyKilled.text = "Enemies Killed: " + enemyKilled;

        //set the coin collected text
        numOfCoinsCollected.text = "Coins Collected: " + coinCollected;

        //set the total coin text
        numOfTotalCoins.text = "" + totalCoins;
    }
}
