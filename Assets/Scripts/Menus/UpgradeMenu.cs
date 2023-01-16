using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 22/12/2022
//Object(s) holding this script: Upgrade Menu
//Summary: Handle upgrade menu events 

public class UpgradeMenu : MonoBehaviour
{
    public GameObject weaponDamage;
    public GameObject weaponCritChance;
    public GameObject weaponCritDamage;

    public GameObject[] damage;
    public GameObject[] critChance;
    public GameObject[] critDamage;

    //when click Upgrade Sword button in Weapon Damage menu
    public void UpgradeSwordDamage()
    {
        damage[0].SetActive(true);
    }

    //when click Upgrade Staff button in Weapon Damage menu
    public void UpgradeStaffDamage()
    {
        damage[1].SetActive(true);
    }

    //when click Upgrade Bow button in Weapon Damage menu
    public void UpgradeBowDamage()
    {
        damage[2].SetActive(true);
    }

    //when click No button in Weapon Damage menu
    public void CancelDamageUpgrade()
    {
        foreach (GameObject weapon in damage)
        {
            weapon.SetActive(false);
        }
    }

    //when click Upgrade Sword button in Weapon Crit Chance menu
    public void UpgradeSwordCritChance()
    {
        critChance[0].SetActive(true);
    }

    //when click Upgrade Staff button in Weapon Crit Chance menu
    public void UpgradeStaffCritChance()
    {
        critChance[1].SetActive(true);
    }

    //when click Upgrade Bow button in Weapon Crit Chance menu
    public void UpgradeBowCritChance()
    {
        critChance[2].SetActive(true);
    }

    //when click No button in Weapon Crit Chance menu
    public void CancelCritChanceUpgrade()
    {
        foreach (GameObject weapon in critChance)
        {
            weapon.SetActive(false);
        }
    }

    //when click Upgrade Sword button in Weapon Crit Damage menu
    public void UpgradeSwordCritDamage()
    {
        critDamage[0].SetActive(true);
    }

    //when click Upgrade Staff button in Weapon Crit Damage menu
    public void UpgradeStaffCritDamage()
    {
        critDamage[1].SetActive(true);
    }

    //when click Upgrade Bow button in Weapon Crit Damage menu
    public void UpgradeBowCritDamage()
    {
        critDamage[2].SetActive(true);
    }

    //when click No button in Weapon Crit Damage menu
    public void CancelCritDamageUpgrade()
    {
        foreach (GameObject weapon in critDamage)
        {
            weapon.SetActive(false);
        }
    }

    //when click Next button in Weapon Damage menu
    //when click Previous button in Weapon Crit Damage menu
    public void LoadWeaponCritChance()
    {
        weaponDamage.SetActive(false);
        weaponCritChance.SetActive(true);
        weaponCritDamage.SetActive(false);
    }

    //when click Previous button in Weapon Crit Chance menu
    public void LoadWeaponDamage()
    {
        weaponDamage.SetActive(true);
        weaponCritChance.SetActive(false);
    }

    //when click Next button in Weapon Crit Chance menu
    public void LoadWeaponCritDamage()
    {
        weaponCritChance.SetActive(false);
        weaponCritDamage.SetActive(true);
    }
}
