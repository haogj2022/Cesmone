using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 14/11/2022
//Summary: Handle input field

///Date modified: 15/11/2022
///Summary: Display text from input field

public class ReadInput : MonoBehaviour
{
    public GameObject characterName; //a reference to Character Name canvas
    public TMP_InputField nameInput; //a reference to input field
    public TMP_Text nameToDisplay; //a reference to name to display
    public TouchAndGo character; //a reference to Hero Selection object   
    public WaveSpawner spawner; //a reference to wave spawner

    private GameObject player; 
    private float offset = 1.2f; 

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

            character.isMoving = true; //enable character movement

            spawner.enabled = true;
        }
    }

    private void Update()
    {
        nameToDisplay.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + offset);
    }
}
