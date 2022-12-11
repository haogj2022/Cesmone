using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 14/11/2022
//Object(s) holding this script: Hero Name
//Summary: Handle input field

public class ReadInput : MonoBehaviour
{
    [Header("Canvases")]
    public GameObject characterName; 
    public GameObject mainMenu;

    [Header("TMP_InputFields")]
    public TMP_InputField nameInput;

    [Header("TMP_Texts")] 
    public TMP_Text nameToDisplay;
    public TMP_Text nameInMainMenu;
    public TMP_Text timerText; 

    public TMP_Text numOfEnemyKilled;
    public TMP_Text numOfCoinsCollected;
    public TMP_Text numOfTotalCoins;

    [Header("Scripts")]
    public JoystickController joystick;
    public WaveSpawner[] spawners;

    GameObject player;
    CastleHealth castle;
    Image winScreen;
    Image loseScreen;

    List<GameObject> enemies = new List<GameObject>();

    float offset = 1.2f;    
    float currentTime = 0;
    
    public GameObject[] stats;

    public bool startTimer = false;
    public float enemyKilled = 0;
    public float coinCollected = 0;
    public float totalCoins = 0;

    void Start()
    {
        //get the display name
        nameToDisplay.text = PlayerPrefs.GetString(nameInput.text); 

        //find hero selection game object in hierarchy
        player = GameObject.Find("Hero Selection");

        //find castle game object in hierarchy
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

    //when enter name in input field
    public void ReadStringInput()
    {
        //display the input name on screen
        nameToDisplay.text = nameInput.text;
        
        //set the displayed name
        PlayerPrefs.SetString(nameInput.text, nameToDisplay.text); 

        //save the name
        PlayerPrefs.Save();           
    }

    //when click Level 1 button on Level selection screen
    public void Level1()
    {       
        //close main menu canvas
        mainMenu.SetActive(false);

        //show character name on screen
        characterName.SetActive(false);

        //show joystick on screen
        joystick.isActive = true;

        //start timer
        startTimer = true;

        //enable level 1 spawner
        spawners[0].enabled = true;
        spawners[0].StartLevel1();
    }

    void Update()
    {
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        
        //displayed name follows the character
        nameToDisplay.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + offset);

        nameInMainMenu.text = nameToDisplay.text;

        //when timer is active
        if (startTimer)
        {
            //count the time passed every second
            currentTime += Time.deltaTime;            
        }

        if (castle.currentHealth > 0)
        {
            //set the time text
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            timerText.text = "Clear Time: " + time.ToString(@"mm\:ss\:fff");
        }
        else
        {
            timerText.text = "Clear Time: N/A";
        }
        
        //set the enemy killed text
        numOfEnemyKilled.text = "Enemies Killed: " + enemyKilled;

        //set the coin collected text
        numOfCoinsCollected.text = "Coins Collected: " + coinCollected;
        
        //set the total coin text
        numOfTotalCoins.text = "" + totalCoins;
    }

    //when click OK button in Win or Lose screen
    //when click Confirm button in Character Name screen
    public void OpenMainMenu()
    {
        //when player enter a valid name
        if (!string.IsNullOrEmpty(nameInput.text))
        {
            //open main menu canvas
            mainMenu.SetActive(true);

            //close win and lose screens
            winScreen.enabled = false;
            loseScreen.enabled = false;
            
            //reset stats
            currentTime = 0;
            enemyKilled = 0;
            coinCollected = 0;
            castle.currentHealth = castle.maxHealth;

            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }

            //disable all wave spawners
            foreach (WaveSpawner spawner in spawners)
            {
                spawner.enabled = false;
            }

            foreach (GameObject stat in stats)
            {
                stat.SetActive(false);
            }
        }
    }
}