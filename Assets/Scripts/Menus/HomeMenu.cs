using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMenu : MonoBehaviour
{
    public GameObject homeScreen;
    public GameObject settingsScreen;
    public GameObject creditScreen;
    public GameObject mainMenu;

    //when click Play button in home menu
    public void PlayGame()
    {
        //open main menu
        homeScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    //when click Settings button in home menu
    public void OpenSettings()
    {
        //open settings screen
        settingsScreen.SetActive(true);
        homeScreen.SetActive(false);
    }

    //when click Credits button in home menu
    public void OpenCredits()
    {
        //open credits screen
        creditScreen.SetActive(true);
        homeScreen.SetActive(false);
    }

    //when click Go Back button in main menu
    public void BackToHomeMenu()
    {
        //go back to home screen
        homeScreen.SetActive(true);
        settingsScreen.SetActive(false);
        creditScreen.SetActive(false);
        mainMenu.SetActive(false);
    }
}
