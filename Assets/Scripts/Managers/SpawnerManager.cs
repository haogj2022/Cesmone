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
    public GameObject startScreen;
    public GameObject mainMenu;
    public GameObject pauseButton;
    public GameObject quitConfirm;

    public JoystickController joystick;
    public PlayerStats player;    
    public WaveSpawner[] spawners;

    CastleHealth castle;
    Image winScreen;
    Image loseScreen;
    
    List<GameObject> enemies = new List<GameObject>();
    List<GameObject> damage = new List<GameObject>();

    void Start()
    {   
        //open start screen
        startScreen.SetActive(true);
        
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
        player.startTimer = true;

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

        //close quit confirm canvas
        quitConfirm.SetActive(false);

        //close win and lose screens
        winScreen.enabled = false;
        loseScreen.enabled = false;

        //reset stats
        player.currentTime = 0;
        player.enemyKilled = 0;
        player.coinCollected = 0;
        castle.currentHealth = castle.maxHealth;

        //destroy alive enemies so we can start a new level
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
       
        //disable all wave spawners
        foreach (WaveSpawner spawner in spawners)
        {
            spawner.canSpawn = false;
            spawner.enabled = false;
        }

        //hide all the stats
        foreach (GameObject stat in player.stats)
        {
            stat.SetActive(false);
        }        
    }
}