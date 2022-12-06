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
    [Header("Canvases")]
    public GameObject characterName; 
    public GameObject mainMenu;

    [Header("UIs")]
    public TMP_InputField nameInput; 
    public TMP_Text nameToDisplay; 
    public TMP_Text timerText; 
    public TMP_Text numOfEnemyKilled; 

    [Header("Scripts")]
    public JoystickController joystick; 
    public WaveSpawner spawner;

    GameObject player; 

    float offset = 1.2f;    
    float currentTime = 0;

    [Header("Stats")]
    public bool startTimer = false;
    public float enemyKilled = 0;

    void Start()
    {
        //get the display name
        nameToDisplay.text = PlayerPrefs.GetString(nameInput.text); 

        //find hero selection game object in hierarchy
        player = GameObject.Find("Hero Selection");

        //disable wave spawner
        spawner.enabled = false;
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

    //when click Confirm button on Character Name canvas
    public void LoadGame()
    {
        //when input display is valid
        if (!string.IsNullOrEmpty(nameInput.text))
        {
            //show character name on screen
            characterName.SetActive(false); 

            //show joystick on screen
            joystick.isActive = true; 

            //enable wave spawner
            spawner.enabled = true; 

            //start timer
            startTimer = true; 
        }
    }

    void Update()
    {
        //displayed name follows the character
        nameToDisplay.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + offset);

        //when timer is active
        if (startTimer)
        {
            //count the time passed every second
            currentTime += Time.deltaTime;            
        }

        //set the time text
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = "Clear Time: " + time.ToString(@"mm\:ss\:fff");

        //set the enemy killed text
        numOfEnemyKilled.text = "Enemy Killed: " + enemyKilled;
    }

    //when click OK button in Win or Lose screen
    public void OpenMainMenu()
    {
        //open main menu canvas
        mainMenu.SetActive(true); 
    }
}