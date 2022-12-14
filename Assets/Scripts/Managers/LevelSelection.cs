using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Created by: Nguyen Anh Hao
//Date created: 14/12/2022
//Object(s) holding this script: WaveSpawner
//Summary: Handle level selection

public class LevelSelection : MonoBehaviour
{
    [Header("Canvases")]
    public GameObject mainMenu;
    public GameObject pauseButton;
    public GameObject quitConfirm;

    [Header("Scripts")]
    public JoystickController joystick;
    public PlayerStats player;

    [Header("GameObjects")]
    public WaveSpawner[] spawners;

    CastleHealth castle;

    List<GameObject> enemies = new List<GameObject>();

    Image winScreen;
    Image loseScreen;

    void Start()
    {
        //get win and lose screen
        winScreen = GameObject.Find("Win").GetComponent<Image>();
        loseScreen = GameObject.Find("Lose").GetComponent<Image>();

        //get castle's health
        castle = GameObject.Find("Castle").GetComponent<CastleHealth>();

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
    }

    //when click Level 1 button on Level selection screen
    public void Level1()
    {
        //close main menu canvas
        mainMenu.SetActive(false);

        //show pause button
        pauseButton.SetActive(true);

        //show joystick on screen
        joystick.isActive = true;

        //start timer
        player.startTimer = true;

        //enable level 1 spawner
        spawners[0].canSpawn = true;
        spawners[0].enabled = true;
        spawners[0].StartLevel();
    }

    //called by WaveSpawner.PlayerWin() when player complete all waves
    //called by WaveSpawner.PlayerLose() when player fail to defend the castle
    public void LevelComplete()
    {
        //show pause button
        pauseButton.SetActive(false);
    }

    //when click OK button in Win or Lose screen
    //when click Yes button in quit confirm screen
    public void OpenMainMenu()
    {
        Time.timeScale = 1;

        //open main menu canvas
        mainMenu.SetActive(true);

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