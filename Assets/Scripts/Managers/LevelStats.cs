using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 14/12/2022
//Object(s) holding this script: Win & Lose Screen
//Summary: Show stats after player complete a level

public class LevelStats : MonoBehaviour, IDataPersistence
{
    public GameObject[] stats;
    public TMP_Text[] texts;

    public float currentTime = 0;
    public float enemiesKilled = 0;
    public float coinsCollected = 0;
    public float totalCoins = 0;
    
    public bool startTimer = false;

    CastleHealthText castle;
    
    public void LoadData(SaveData data)
    {
        totalCoins = data.totalCoins;
    }

    public void SaveData(ref SaveData data)
    {
        data.totalCoins = totalCoins;
    }

    // Start is called before the first frame update
    void Start()
    {
        //find castle game object in hierarchy
        castle = GameObject.Find("Castle").GetComponent<CastleHealthText>();
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
            texts[0].text = "Clear Time: " + time.ToString(@"hh\:mm\:ss");
        }
        else //castle is destroyed
        {
            //player not complete the level yet
            texts[0].text = "Clear Time: N/A";
        }

        //set the enemy killed text
        texts[1].text = "Enemies Killed: " + enemiesKilled;

        //set the coin collected text
        texts[2].text = "Coins Collected: " + coinsCollected;

        //set the total coin text
        texts[3].text = "" + totalCoins;
    }
}
