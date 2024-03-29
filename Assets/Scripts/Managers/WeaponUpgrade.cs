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

public class WeaponUpgrade : MonoBehaviour, IDataPersistence
{   
    public Upgrade[] upgrades;
    public HeroStats[] heroes;
    public GameObject[] options;

    bool canUpgrade = true;
    float upgradeAmount = 2;

    LevelStats levelStat;

    public void LoadData(SaveData data)
    {
        LoadSwordData(data);
        LoadStaffData(data);
        LoadBowData(data);
    }

    void LoadSwordData(SaveData data)
    {
        int type = 0;

        //load sword hero data
        heroes[type].damage = data.currentSwordDamage;
        heroes[type].critChance = data.currentSwordCritChance;
        heroes[type].critDamage = data.currentSwordCritDamage;

        heroes[type + 3].damage = data.currentSwordDamage;
        heroes[type + 3].critChance = data.currentSwordCritChance;
        heroes[type + 3].critDamage = data.currentSwordCritDamage;

        //load sword upgrade data
        upgrades[type].lastUpgrade = data.currentSwordDamage;
        upgrades[type + 3].lastUpgrade = data.currentSwordCritChance;
        upgrades[type + 6].lastUpgrade = data.currentSwordCritDamage;

        upgrades[type].nextUpgrade = data.nextSwordDamage;
        upgrades[type + 3].nextUpgrade = data.nextSwordCritChance;
        upgrades[type + 6].nextUpgrade = data.nextSwordCritDamage;

        upgrades[type].cost = data.swordDamageUpgradeCost;
        upgrades[type + 3].cost = data.swordCritChanceUpgradeCost;
        upgrades[type + 6].cost = data.swordCritDamageUpgradeCost;
    }

    void LoadStaffData(SaveData data)
    {
        int type = 0;

        //load staff hero data
        heroes[type + 1].damage = data.currentStaffDamage;
        heroes[type + 1].critChance = data.currentStaffCritChance;
        heroes[type + 1].critDamage = data.currentStaffCritDamage;

        heroes[type + 4].damage = data.currentStaffDamage;
        heroes[type + 4].critChance = data.currentStaffCritChance;
        heroes[type + 4].critDamage = data.currentStaffCritDamage;

        //load staff upgrade data
        upgrades[type + 1].lastUpgrade = data.currentStaffDamage;
        upgrades[type + 4].lastUpgrade = data.currentStaffCritChance;
        upgrades[type + 7].lastUpgrade = data.currentStaffCritDamage;

        upgrades[type + 1].nextUpgrade = data.nextStaffDamage;
        upgrades[type + 4].nextUpgrade = data.nextStaffCritChance;
        upgrades[type + 7].nextUpgrade = data.nextStaffCritDamage;

        upgrades[type + 1].cost = data.staffDamageUpgradeCost;
        upgrades[type + 4].cost = data.staffCritChanceUpgradeCost;
        upgrades[type + 7].cost = data.staffCritDamageUpgradeCost;
    }

    void LoadBowData(SaveData data)
    {
        int type = 0;

        //load bow hero data
        heroes[type + 2].damage = data.currentBowDamage;
        heroes[type + 2].critChance = data.currentBowCritChance;
        heroes[type + 2].critDamage = data.currentBowCritDamage;

        heroes[type + 5].damage = data.currentBowDamage;
        heroes[type + 5].critChance = data.currentBowCritChance;
        heroes[type + 5].critDamage = data.currentBowCritDamage;

        //load bow upgrade data
        upgrades[type + 2].lastUpgrade = data.currentBowDamage;
        upgrades[type + 5].lastUpgrade = data.currentBowCritChance;
        upgrades[type + 8].lastUpgrade = data.currentBowCritDamage;

        upgrades[type + 2].nextUpgrade = data.nextBowDamage;
        upgrades[type + 5].nextUpgrade = data.nextBowCritChance;
        upgrades[type + 8].nextUpgrade = data.nextBowCritDamage;

        upgrades[type + 2].cost = data.bowDamageUpgradeCost;
        upgrades[type + 5].cost = data.bowCritChanceUpgradeCost;
        upgrades[type + 8].cost = data.bowCritDamageUpgradeCost;
    }

    public void SaveData(ref SaveData data)
    {
        SaveSwordData(ref data);
        SaveStaffData(ref data);
        SaveBowData(ref data);
    }

    void SaveSwordData(ref SaveData data)
    {
        int type = 0;

        data.currentSwordDamage = upgrades[type].lastUpgrade;
        data.currentSwordCritChance = upgrades[type + 3].lastUpgrade;
        data.currentSwordCritDamage = upgrades[type + 6].lastUpgrade;

        data.nextSwordDamage = upgrades[type].nextUpgrade;
        data.nextSwordCritChance = upgrades[type + 3].nextUpgrade;
        data.nextSwordCritDamage = upgrades[type + 6].nextUpgrade;

        data.swordDamageUpgradeCost = upgrades[type].cost;
        data.swordCritChanceUpgradeCost = upgrades[type + 3].cost;
        data.swordCritDamageUpgradeCost = upgrades[type + 6].cost;
    }

    void SaveStaffData(ref SaveData data)
    {
        int type = 0;

        data.currentStaffDamage = upgrades[type + 1].lastUpgrade;
        data.currentStaffCritChance = upgrades[type + 4].lastUpgrade;
        data.currentStaffCritDamage = upgrades[type + 7].lastUpgrade;

        data.nextStaffDamage = upgrades[type + 1].nextUpgrade;
        data.nextStaffCritChance = upgrades[type + 4].nextUpgrade;
        data.nextStaffCritDamage = upgrades[type + 7].nextUpgrade;

        data.staffDamageUpgradeCost = upgrades[type + 1].cost;
        data.staffCritChanceUpgradeCost = upgrades[type + 4].cost;
        data.staffCritDamageUpgradeCost = upgrades[type + 7].cost;
    }

    void SaveBowData(ref SaveData data)
    {
        int type = 0;

        data.currentBowDamage = upgrades[type + 2].lastUpgrade;
        data.currentBowCritChance = upgrades[type + 5].lastUpgrade;
        data.currentBowCritDamage = upgrades[type + 8].lastUpgrade;

        data.nextBowDamage = upgrades[type + 2].nextUpgrade;
        data.nextBowCritChance = upgrades[type + 5].nextUpgrade;
        data.nextBowCritDamage = upgrades[type + 8].nextUpgrade;

        data.bowDamageUpgradeCost = upgrades[type + 2].cost;
        data.bowCritChanceUpgradeCost = upgrades[type + 5].cost;
        data.bowCritDamageUpgradeCost = upgrades[type + 8].cost;
    }

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
                heroes[type].damage += upgradeAmount;
                heroes[type + 3].damage += upgradeAmount;

                upgrades[type].lastUpgrade += upgradeAmount;
                upgrades[type].nextUpgrade = upgrades[type].lastUpgrade + upgradeAmount;

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
                heroes[type].critChance += upgradeAmount;
                heroes[type + 3].critChance += upgradeAmount;

                upgrades[type + 3].lastUpgrade += upgradeAmount;
                upgrades[type + 3].nextUpgrade = upgrades[type + 3].lastUpgrade + upgradeAmount;

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
                //update sword hero stats
                heroes[type].critDamage += upgradeAmount;
                heroes[type + 3].critDamage += upgradeAmount;

                upgrades[type + 6].lastUpgrade += upgradeAmount;
                upgrades[type + 6].nextUpgrade = upgrades[type + 6].lastUpgrade + upgradeAmount;

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
