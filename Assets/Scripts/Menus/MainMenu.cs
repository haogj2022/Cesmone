using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 14/12/2022
//Object(s) holding this script: Main Menu
//Summary: Handle main menu events 

public class MainMenu : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject levelSelect;
    public GameObject upgradeMenu;

    //when click Select Level button in main menu
    public void LoadLevelSelection()
    {
        //open level select screen
        optionMenu.SetActive(false);
        levelSelect.SetActive(true);
    }   

    //when click Upgrade Weapon button in main menu
    public void LoadWeaponsmith()
    {
        //open upgrade menu screen
        optionMenu.SetActive(false);
        upgradeMenu.SetActive(true);
    }
   
    //when click Go Back button in level select screen
    //when click Go Back button in upgrade menu screen
    public void OpenOptionMenu()
    {
        //open option menu
        optionMenu.SetActive(true);
        levelSelect.SetActive(false);
        upgradeMenu.SetActive(false);
    }
}
