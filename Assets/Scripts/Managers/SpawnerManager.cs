using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Created by: Nguyen Anh Hao
//Date created: 14/12/2022
//Object(s) holding this script: Spawner Manager
//Summary: Manage wave spawners

public class SpawnerManager : MonoBehaviour
{
    public WaveSpawner[] spawners;

    public GameObject stageMenu;
    public GameObject playerMenu;
    public GameObject pauseButton;
    public GameObject quitConfirm;
    public GameObject[] trapButton;

    List<GameObject> enemies = new List<GameObject>();
    List<GameObject> coins = new List<GameObject>();

    CastleHealthText castle;
    Image winScreen;
    Image loseScreen;
    PlayerController playerController;
    LevelStats levelStat;       

    void Start()
    {   
        playerController = GameObject.Find("Player Character").GetComponent<PlayerController>();

        //find stat game object in hierarchy
        levelStat = GameObject.Find("Win & Lose Screen").GetComponent<LevelStats>();

        //get castle's health
        castle = GameObject.Find("Castle").GetComponent<CastleHealthText>();
        
        //get win and lose screen
        winScreen = GameObject.Find("Win").GetComponent<Image>();
        loseScreen = GameObject.Find("Lose").GetComponent<Image>();

        //disable all wave spawners
        foreach (WaveSpawner spawner in spawners)
        {
            spawner.enabled = false;
        }
    }

    void Update()
    {
        //find all enemies with tag
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));

        //find all coins with tag
        coins.AddRange(GameObject.FindGameObjectsWithTag("Coin"));
    }

    //when click any level number on Level selection screen
    public void ChooseLevel(int level)
    {
        //close stage menu
        stageMenu.SetActive(false);

        //hide player menu
        playerMenu.SetActive(false);

        //show pause button
        pauseButton.SetActive(true);

        foreach (GameObject button in trapButton)
        {
            button.SetActive(true);
        }

        //enable player controller       
        playerController.isActive = true;
                
        //start timer
        levelStat.startTimer = true;

        //enable chosen level's spawner
        spawners[level].canSpawn = true;
        spawners[level].enabled = true;
        spawners[level].StartLevel();
    }
    
    //called by WaveSpawner.PlayerWin() when player complete all waves
    //called by WaveSpawner.PlayerLose() when player fail to defend the castle
    public void LevelComplete()
    {
        //show pause button
        pauseButton.SetActive(false);
    }

    //called when open main menu screen
    public void QuitToStageMenu()
    {
        Time.timeScale = 1;

        //open stage menu
        stageMenu.SetActive(true);

        //show player menu
        playerMenu.SetActive(true);

        //close quit confirm screen
        quitConfirm.SetActive(false);

        //close win and lose screens
        winScreen.enabled = false;
        loseScreen.enabled = false;

        //clean up the game
        CleanUp();        
    }

    //called by OpenMainMenu() to clean up the game
    void CleanUp()
    {
        //reset stats
        levelStat.currentTime = 0;
        levelStat.enemiesKilled = 0;
        levelStat.coinsCollected = 0;
        castle.currentHealth = castle.maxHealth;
        
        //hide all the stats
        foreach (GameObject stat in levelStat.stats)
        {
            stat.SetActive(false);
        }
        
        //disable all wave spawners
        foreach (WaveSpawner spawner in spawners)
        {
            spawner.canSpawn = false;
            spawner.enabled = false;
        } 
        
        //destroy all alive enemies
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        //destroy all remaining coins
        foreach (GameObject coin in coins)
        {
            Destroy(coin);
        }
    }
}