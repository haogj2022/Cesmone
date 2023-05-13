using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 14/12/2022
//Object(s) holding this script: Home Menu
//Summary: Handle home menu events 

public class HomeMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject settingsMenu;
    public GameObject creditsMenu;

    public GameObject playerMenu;
    public GameObject optionMenu;

    //when click Play button in home menu
    public void PlayGame()
    {
        //open option menu
        startMenu.SetActive(false);
        playerMenu.SetActive(true);
        optionMenu.SetActive(true);
    }

    //when click Settings button in home menu
    public void OpenSettings()
    {
        //open settings screen
        settingsMenu.SetActive(true);
        startMenu.SetActive(false);
    }

    //when click Credits button in home menu
    public void OpenCredits()
    {
        //open credits screen
        creditsMenu.SetActive(true);
        startMenu.SetActive(false);
    }

    //when click Go Back button in home menu
    //when click Go Back button in game menu
    public void OpenStartMenu()
    {
        //open start menu
        startMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);

        playerMenu.SetActive(false);
        optionMenu.SetActive(false);
    }
}
