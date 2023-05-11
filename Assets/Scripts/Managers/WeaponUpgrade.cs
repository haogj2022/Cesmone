using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 12/01/2023
//Object(s) holding this script: Uprade Menu
//Summary: Manage weapon upgrades

//make the class editable in Inspector
[System.Serializable]
public class Upgrade
{
    public string name;
        
    public TMP_Text currentStat;
    public TMP_Text upgrade;
    public TMP_Text newStat;
        
    public float lastUpgrade;
    public float nextUpgrade;
    public float cost;
}

public class WeaponUpgrade : MonoBehaviour
{   
    public Upgrade[] upgrades;
    public HeroStats[] heroes;
    public GameObject[] options;

    bool canUpgrade = true;

    LevelStats levelStat;

    void Start()
    {
        levelStat = GameObject.Find("Win & Lose Screen").GetComponent<LevelStats>();
    }

    void Update()
    {
        ManageUpgrade();
    }

    //called by Update() to manage the upgrades
    void ManageUpgrade()
    {
        WeaponDamage();
        WeaponCritChance();
        WeaponCritDamage();
    }

    //called by ManageUpgrade() to manage weapon damage
    void WeaponDamage()
    {
        SwordDamage();
        StaffDamage();
        BowDamage();
    }

    //called by ManageUpgrade() to manage weapon crit chance
    void WeaponCritChance()
    {
        SwordCritChance();
        StaffCritChance();
        BowCritChance();
    }

    //called by ManageUpgrade() to manage weapon crit damage
    void WeaponCritDamage()
    {
        SwordCritDamage();
        StaffCritDamage();
        BowCritDamage();
    }    

    //called when click Yes button to upgrade a weapon damage
    public void UpgradeDamage(int type)
    {
        //player can afford the upgrade
        if (levelStat.totalCoins >= upgrades[type].cost)
        {
            //upgrade is enabled
            if (canUpgrade)
            {
                //remove coins from player's bank
                levelStat.totalCoins -= upgrades[type].cost;

                //update damage information
                upgrades[type].lastUpgrade += 2;
                upgrades[type].nextUpgrade = upgrades[type].lastUpgrade + 2;

                heroes[type].damage = upgrades[type].lastUpgrade;
                heroes[type + 3].damage = upgrades[type].lastUpgrade;

                //disable upgrade
                canUpgrade = false;
            }

            //increase cost for the next upgrade
            upgrades[type].cost += 10;

            //enable upgrade
            canUpgrade = true;           
        }
    }

    //called when click Yes button to upgrade a weapon crit chance
    public void UpgradeCritChance(int type)
    {
        //player can afford the upgrade
        if (levelStat.totalCoins >= upgrades[type + 3].cost)
        {
            //upgrade is enabled
            if (canUpgrade)
            {
                //remove coins from player's bank
                levelStat.totalCoins -= upgrades[type + 3].cost;

                //update crit chance information
                upgrades[type + 3].lastUpgrade += 2;
                upgrades[type + 3].nextUpgrade = upgrades[type + 3].lastUpgrade + 2;

                heroes[type].critChance = upgrades[type + 3].lastUpgrade;
                heroes[type + 3].critChance = upgrades[type + 3].lastUpgrade;

                //disable upgrade
                canUpgrade = false;
            }

            //increase cost for the next upgrade
            upgrades[type + 3].cost += 10;

            //enable upgrade
            canUpgrade = true;

            //hero crit chance is maxed
            if (heroes[type].critChance >= 100)
            {
                //show the OK button so player can only return
                options[type].SetActive(false);
                options[type + 3].SetActive(false);
                options[type + 6].SetActive(true);

                //update crit chance information
                upgrades[type + 3].nextUpgrade = upgrades[type + 3].lastUpgrade;
            }
        }
    }

    //called when click Yes button to upgrade a weapon crit damage
    public void UpgradeCritDamage(int type)
    {
        //player can afford the upgrade
        if (levelStat.totalCoins >= upgrades[type + 6].cost)
        {
            //upgrade is enabled
            if (canUpgrade)
            {
                //remove coins from player's bank
                levelStat.totalCoins -= upgrades[type + 6].cost;

                //update crit damage information
                upgrades[type + 6].lastUpgrade += 2;
                upgrades[type + 6].nextUpgrade = upgrades[type + 6].lastUpgrade + 2;

                heroes[type].critDamage = upgrades[type + 6].lastUpgrade;
                heroes[type + 3].critDamage = upgrades[type + 6].lastUpgrade;

                //disable upgrade
                canUpgrade = false;
            }

            //increase cost for the next upgrade
            upgrades[type + 6].cost += 10;

            //enable upgrade
            canUpgrade = true;
        }
    }

    //called by WeaponDamage() to handle sword damage
    void SwordDamage()
    {
        //show current stat
        upgrades[0].currentStat.text = "+" + upgrades[0].lastUpgrade;

        //ask whether to upgrade the weapon
        upgrades[0].upgrade.text = "Upgrade " + upgrades[0].name + " for " + upgrades[0].cost + " coins?";

        //show next upgrade
        upgrades[0].newStat.text = "+" + upgrades[0].lastUpgrade + " -> +" + upgrades[0].nextUpgrade;
    }

    //called by WeaponDamage() to handle staff damage
    void StaffDamage()
    {
        //show current stat
        upgrades[1].currentStat.text = "+" + upgrades[1].lastUpgrade;

        //ask whether to upgrade the weapon
        upgrades[1].upgrade.text = "Upgrade " + upgrades[1].name + " for " + upgrades[1].cost + " coins?";

        //show next upgrade
        upgrades[1].newStat.text = "+" + upgrades[1].lastUpgrade + " -> +" + upgrades[1].nextUpgrade;
    }

    //called by WeaponDamage() to handle bow damage
    void BowDamage()
    {
        //show current stat
        upgrades[2].currentStat.text = "+" + upgrades[2].lastUpgrade;

        //ask whether to upgrade the weapon
        upgrades[2].upgrade.text = "Upgrade " + upgrades[2].name + " for " + upgrades[2].cost + " coins?";

        //show next upgrade
        upgrades[2].newStat.text = "+" + upgrades[2].lastUpgrade + " -> +" + upgrades[2].nextUpgrade;
    }

    //called by WeaponCritChance() to handle sword crit chance
    void SwordCritChance()
    {
        //crit chance is maxed
        if (heroes[0].critChance >= 100)
        {
            //show max crit chance
            upgrades[3].currentStat.text = "+100% MAX";

            //tell player that crit chance is maxed
            upgrades[3].upgrade.text = upgrades[3].name + " is maxed";
        }
        else //crit chance is not maxed
        {
            //show current stat
            upgrades[3].currentStat.text = "+" + upgrades[3].lastUpgrade + "%";
            
            //ask whether to upgrade the weapon
            upgrades[3].upgrade.text = "Upgrade " + upgrades[3].name + " for " + upgrades[3].cost + " coins?";
        }

        //show next upgrade
        upgrades[3].newStat.text = "+" + upgrades[3].lastUpgrade + "% -> +" + upgrades[3].nextUpgrade + "%";
    }

    //called by WeaponCritChance() to handle staff crit chance
    void StaffCritChance()
    {
        //crit chance is maxed
        if (heroes[1].critChance >= 100)
        {
            //show max crit chance
            upgrades[4].currentStat.text = "+100% MAX";

            //tell player that crit chance is maxed
            upgrades[4].upgrade.text = upgrades[4].name + " is maxed";
        }
        else //crit chance is not maxed
        {
            //show current stat
            upgrades[4].currentStat.text = "+" + upgrades[4].lastUpgrade + "%";
            
            //ask whether to upgrade the weapon
            upgrades[4].upgrade.text = "Upgrade " + upgrades[4].name + " for " + upgrades[4].cost + " coins?";
        }

        //show next upgrade
        upgrades[4].newStat.text = "+" + upgrades[4].lastUpgrade + "% -> +" + upgrades[4].nextUpgrade + "%";
    }

    //called by WeaponCritChance() to handle bow crit chance
    void BowCritChance()
    {
        //crit chance is maxed
        if (heroes[2].critChance >= 100)
        {
            //show max crit chance
            upgrades[5].currentStat.text = "+100% MAX";

            //tell player that crit chance is maxed
            upgrades[5].upgrade.text = upgrades[5].name + " is maxed";
        }
        else //crit chance is not maxed
        {
            //show current stat
            upgrades[5].currentStat.text = "+" + upgrades[5].lastUpgrade + "%";

            //ask whether to upgrade the weapon
            upgrades[5].upgrade.text = "Upgrade " + upgrades[5].name + " for " + upgrades[5].cost + " coins?";
        }

        //show next upgrade
        upgrades[5].newStat.text = "+" + upgrades[5].lastUpgrade + "% -> +" + upgrades[5].nextUpgrade + "%";
    }

    //called by WeaponCritDamage() to handle sword crit damage
    void SwordCritDamage()
    {
        //show current stat
        upgrades[6].currentStat.text = "+" + upgrades[6].lastUpgrade;

        //ask whether to uprade the weapon
        upgrades[6].upgrade.text = "Upgrade " + upgrades[6].name + " for " + upgrades[6].cost + " coins?";

        //show next upgrade
        upgrades[6].newStat.text = "+" + upgrades[6].lastUpgrade + " -> +" + upgrades[6].nextUpgrade;
    }

    //called by WeaponCritDamage() to handle staff crit damage
    void StaffCritDamage()
    {
        //show current stat
        upgrades[7].currentStat.text = "+" + upgrades[7].lastUpgrade;

        //ask whether to upgrade the weapon
        upgrades[7].upgrade.text = "Upgrade " + upgrades[7].name + " for " + upgrades[7].cost + " coins?";

        //show next upgrade
        upgrades[7].newStat.text = "+" + upgrades[7].lastUpgrade + " -> +" + upgrades[7].nextUpgrade;
    }

    //called by WeaponCritDamage() to handle bow crit damage
    void BowCritDamage()
    {
        //show current stat
        upgrades[8].currentStat.text = "+" + upgrades[8].lastUpgrade;

        //ask whether to upgrade the weapon
        upgrades[8].upgrade.text = "Upgrade " + upgrades[8].name + " for " + upgrades[8].cost + " coins?";

        //show next upgrade
        upgrades[8].newStat.text = "+" + upgrades[8].lastUpgrade + " -> +" + upgrades[8].nextUpgrade;
    }
}
