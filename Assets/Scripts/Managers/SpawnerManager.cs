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
    
    public GameObject startScreen;
    public GameObject mainMenu;
    public GameObject pauseButton;
    public GameObject quitConfirm;

    List<GameObject> enemies = new List<GameObject>();
    List<GameObject> coins = new List<GameObject>();
    List<GameObject> damage = new List<GameObject>();

    CastleHealth castle;
    Image winScreen;
    Image loseScreen;
    JoystickController joystick;
    PlayerStats stat;    
    
    void Start()
    {   
        //open start screen
        startScreen.SetActive(true);

        //find joystick game object in hierarchy
        joystick = GameObject.Find("Hero Selection").GetComponent<JoystickController>();

        //find stat game object in hierarchy
        stat = GameObject.Find("Win & Lose Screen").GetComponent<PlayerStats>();

        //get castle's health
        castle = GameObject.Find("Castle").GetComponent<CastleHealth>();
        
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

        //find all damage game objects with tag
        damage.AddRange(GameObject.FindGameObjectsWithTag("Damage"));

        foreach(GameObject dmg in damage)
        {
            Destroy(dmg, 1);
        }
    }

    //when click any level number on Level selection screen
    public void ChooseLevel(int level)
    {
        //close main menu canvas
        mainMenu.SetActive(false);

        //show pause button
        pauseButton.SetActive(true);

        //show joystick on screen
        joystick.isActive = true;

        //start timer
        stat.startTimer = true;

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
    public void OpenMainMenu()
    {
        Time.timeScale = 1;

        //open main menu canvas
        mainMenu.SetActive(true);

        //close start screen
        startScreen.SetActive(false);

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
        stat.currentTime = 0;
        stat.enemiesKilled = 0;
        stat.coinsCollected = 0;
        castle.currentHealth = castle.maxHealth;
        
        //hide all the stats
        foreach (GameObject stat in stat.stats)
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