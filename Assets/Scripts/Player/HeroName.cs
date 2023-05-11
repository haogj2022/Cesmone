using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 14/11/2022
//Object(s) holding this script: Hero Name
//Summary: Hero name follows the character

public class HeroName : MonoBehaviour
{
    public TMP_InputField nameInput;

    public TMP_Text nameToDisplay;
    public TMP_Text nameInMainMenu;
    
    public GameObject characterName; 
    public GameObject mainMenu;
    
    GameObject player;

    float offset = 1.2f;    
 
    void Start()
    {
        //get the display name
        nameToDisplay.text = PlayerPrefs.GetString(nameInput.text); 

        //find hero selection game object in hierarchy
        player = GameObject.Find("Hero Selection");             
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

    void Update()
    {     
        //displayed name follows the character
        nameToDisplay.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + offset);

        //show name in main menu
        nameInMainMenu.text = nameToDisplay.text;        
    }

    //when click Confirm button in Character Name screen
    public void ValidName()
    {
        //when player enter a valid name
        if (!string.IsNullOrEmpty(nameInput.text))
        {
            //open main menu canvas
            mainMenu.SetActive(true);

            //close character name canvas
            characterName.SetActive(false);
        }
    }
}