using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 14/12/2022
//Object(s) holding this script: Pause Menu
//Summary: Handle pause menu events

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject pauseButton;
    public GameObject quitConfirm;
    public GameObject[] trapButton;
    
    PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player Character").GetComponent<PlayerController>();
    }

    //when click Pause button in game
    public void OpenPauseScreen()
    {
        //pause the game
        Time.timeScale = 0;

        //disable player controller
        playerController.isActive = false;

        //open pause screen
        pauseScreen.SetActive(true);

        //hide pause button
        pauseButton.SetActive(false);

        foreach(GameObject button in trapButton)
        {
            button.SetActive(false);
        }
    }

    //when click Resume button in pause screen canvas
    public void ClosePauseScreen()
    {
        //pause the game
        Time.timeScale = 1;

        //enable player controller
        playerController.isActive = true;

        //close pause screen
        pauseScreen.SetActive(false);

        //show pause button
        pauseButton.SetActive(true);

        foreach (GameObject button in trapButton)
        {
            button.SetActive(true);
        }
    }

    //when click Quit button in pause screen canvas
    public void OpenQuitConfirm()
    {
        //close pause screen
        pauseScreen.SetActive(false);

        //open quit confirm screen
        quitConfirm.SetActive(true);
    }

    //when click No button in quit confirm canvas
    public void CloseQuitConfirm()
    {
        //open pause screen
        pauseScreen.SetActive(true);

        //close quit confirm screen
        quitConfirm.SetActive(false);
    }
}
