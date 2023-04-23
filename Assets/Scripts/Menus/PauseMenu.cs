using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 14/12/2022
//Object(s) holding this script: Pause Menu
//Summary: Handle pause events

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject pauseButton;
    public GameObject quitConfirm;
    public GameObject spikeTrapButton;
    
    PlayerController joystick;

    private void Start()
    {
        joystick = GameObject.Find("Hero Selection").GetComponent<PlayerController>();
    }

    //when click Pause button in game
    public void OpenPauseScreen()
    {
        //pause the game
        Time.timeScale = 0;

        //hide joystick
        joystick.isActive = false;

        //open pause screen
        pauseScreen.SetActive(true);

        //hide pause button
        pauseButton.SetActive(false);

        spikeTrapButton.SetActive(false);
    }

    //when click Resume button in pause screen canvas
    public void ClosePauseScreen()
    {
        //pause the game
        Time.timeScale = 1;

        //show joystick
        joystick.isActive = true;

        //close pause screen
        pauseScreen.SetActive(false);

        //show pause button
        pauseButton.SetActive(true);

        spikeTrapButton.SetActive(true);
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
