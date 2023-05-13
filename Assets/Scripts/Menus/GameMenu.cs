using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 14/12/2022
//Object(s) holding this script: Game Menu
//Summary: Handle game menu events 

public class GameMenu : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject stageMenu;

    public GameObject weaponDamageMenu;
    public GameObject weaponCritChanceMenu;
    public GameObject weaponCritDamageMenu;

    //when click Select Level button in game menu
    public void LoadLevelSelection()
    {
        //open level select screen
        optionMenu.SetActive(false);
        stageMenu.SetActive(true);
    }   

    //when click Upgrade Weapon button in game menu
    public void LoadWeaponsmith()
    {
        //open upgrade menu screen
        optionMenu.SetActive(false);
        weaponDamageMenu.SetActive(true);
    }
   
    //when click Go Back button in stage menu
    //when click Go Back button in upgrade menu
    public void OpenOptionMenu()
    {
        //open option menu
        optionMenu.SetActive(true);
        stageMenu.SetActive(false);

        weaponDamageMenu.SetActive(false);
        weaponCritChanceMenu.SetActive(false);
        weaponCritDamageMenu.SetActive(false);
    }
}
