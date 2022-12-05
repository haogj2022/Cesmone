using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 14/11/2022
//Summary: Handle input field

public class ReadInput : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject characterName; //Character Name canvas
    public GameObject mainMenu;

    [Header("UIs")]
    public TMP_InputField nameInput; //input field for character name
    public TMP_Text nameToDisplay; //name to show on screen
    public TMP_Text timerText; //text to show current time
    public TMP_Text numOfEnemyKilled; //text 

    [Header("Scripts")]
    public JoystickController joystick; //joystick controller object
    public WaveSpawner spawner; //wave spawner object

    GameObject player; 
    float offset = 1.2f;
    
    float currentTime = 0;

    public bool startTimer = false;
    public float enemyKilled = 0;

    void Start()
    {
        nameToDisplay.text = PlayerPrefs.GetString(nameInput.text); //get name input
        player = GameObject.Find("Hero Selection");
        spawner.enabled = false;
    }

    //when enter name in input field
    public void ReadStringInput()
    {
        nameToDisplay.text = nameInput.text; //display name
        PlayerPrefs.SetString(nameInput.text, nameToDisplay.text); //set name to display
        PlayerPrefs.Save(); //save name                
    }

    //when click Confirm button on Character Name canvas
    public void LoadGame()
    {
        //when input display is valid
        if (!string.IsNullOrEmpty(nameInput.text))
        {
            characterName.SetActive(false); //close Character Name canvas

            joystick.isActive = true; //enable character movement

            spawner.enabled = true;

            startTimer = true;
        }
    }

    void Update()
    {
        nameToDisplay.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + offset);

        if (startTimer)
        {
            currentTime += Time.deltaTime;            
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = "Clear Time: " + time.ToString(@"mm\:ss\:fff");

        numOfEnemyKilled.text = "Enemy Killed: " + enemyKilled;
    }

    //when click OK button in Win or Lose screen
    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
    }
}