using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 12/01/2023
//Object(s) holding this script: Uprade Menu
//Summary: Manage weapon upgrades

public class WeaponUpgrade : MonoBehaviour
{
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

    public Upgrade[] upgrades;
    public HeroAttack[] heroes;

    bool canUpgrade = true;

    PlayerStats stat;

    void Start()
    {
        stat = GameObject.Find("Win & Lose Screen").GetComponent<PlayerStats>();
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
        if (stat.totalCoins >= upgrades[type].cost)
        {            
            if (canUpgrade)
            {
                stat.totalCoins -= upgrades[type].cost;

                heroes[type].damage += 2;
                heroes[type + 3].damage += 2;

                upgrades[type].lastUpgrade += 2;
                upgrades[type].nextUpgrade = upgrades[type].lastUpgrade + 2;

                canUpgrade = false;
            }

            upgrades[type].cost += 20;

            canUpgrade = true;           
        }
    }

    //called when click Yes button to upgrade a weapon crit chance
    public void UpgradeCritChance(int type)
    {
        if (stat.totalCoins >= upgrades[type + 3].cost)
        {
            if (canUpgrade)
            {
                stat.totalCoins -= upgrades[type + 3].cost;

                heroes[type].critChance += 2;
                heroes[type + 3].critChance += 2;

                upgrades[type + 3].lastUpgrade += 2;
                upgrades[type + 3].nextUpgrade = upgrades[type + 3].lastUpgrade + 2;

                canUpgrade = false;
            }

            upgrades[type + 3].cost += 20;

            canUpgrade = true;
        }
    }

    //called when click Yes button to upgrade a weapon crit damage
    public void UpgradeCritDamage(int type)
    {
        if (stat.totalCoins >= upgrades[type + 6].cost)
        {
            if (canUpgrade)
            {
                stat.totalCoins -= upgrades[type + 6].cost;

                heroes[type].critDamage += 2;
                heroes[type + 3].critDamage += 2;

                upgrades[type + 6].lastUpgrade += 2;
                upgrades[type + 6].nextUpgrade = upgrades[type + 6].lastUpgrade + 2;

                canUpgrade = false;
            }

            upgrades[type + 6].cost += 20;

            canUpgrade = true;
        }
    }

    //called by WeaponDamage() to handle sword damage
    void SwordDamage()
    {
        upgrades[0].currentStat.text = "+" + upgrades[0].lastUpgrade;
        upgrades[0].upgrade.text = "Upgrade " + upgrades[0].name + " for " + upgrades[0].cost + " coins?";
        upgrades[0].newStat.text = "+" + upgrades[0].lastUpgrade + " -> +" + upgrades[0].nextUpgrade;
    }

    //called by WeaponDamage() to handle staff damage
    void StaffDamage()
    {
        upgrades[1].currentStat.text = "+" + upgrades[1].lastUpgrade;
        upgrades[1].upgrade.text = "Upgrade " + upgrades[1].name + " for " + upgrades[1].cost + " coins?";
        upgrades[1].newStat.text = "+" + upgrades[1].lastUpgrade + " -> +" + upgrades[1].nextUpgrade;
    }

    //called by WeaponDamage() to handle bow damage
    void BowDamage()
    {
        upgrades[2].currentStat.text = "+" + upgrades[2].lastUpgrade;
        upgrades[2].upgrade.text = "Upgrade " + upgrades[2].name + " for " + upgrades[2].cost + " coins?";
        upgrades[2].newStat.text = "+" + upgrades[2].lastUpgrade + " -> +" + upgrades[2].nextUpgrade;
    }

    //called by WeaponCritChance() to handle sword crit chance
    void SwordCritChance()
    {
        upgrades[3].currentStat.text = "+" + upgrades[3].lastUpgrade + "%";
        upgrades[3].upgrade.text = "Upgrade " + upgrades[3].name + " for " + upgrades[3].cost + " coins?";
        upgrades[3].newStat.text = "+" + upgrades[3].lastUpgrade + "% -> +" + upgrades[3].nextUpgrade + "%";
    }

    //called by WeaponCritChance() to handle staff crit chance
    void StaffCritChance()
    {
        upgrades[4].currentStat.text = "+" + upgrades[4].lastUpgrade + "%";
        upgrades[4].upgrade.text = "Upgrade " + upgrades[4].name + " for " + upgrades[4].cost + " coins?";
        upgrades[4].newStat.text = "+" + upgrades[4].lastUpgrade + "% -> +" + upgrades[4].nextUpgrade + "%";
    }

    //called by WeaponCritChance() to handle bow crit chance
    void BowCritChance()
    {
        upgrades[5].currentStat.text = "+" + upgrades[5].lastUpgrade + "%";
        upgrades[5].upgrade.text = "Upgrade " + upgrades[5].name + " for " + upgrades[5].cost + " coins?";
        upgrades[5].newStat.text = "+" + upgrades[5].lastUpgrade + "% -> +" + upgrades[5].nextUpgrade + "%";
    }

    //called by WeaponCritDamage() to handle sword crit damage
    void SwordCritDamage()
    {
        upgrades[6].currentStat.text = "+" + upgrades[6].lastUpgrade;
        upgrades[6].upgrade.text = "Upgrade " + upgrades[6].name + " for " + upgrades[6].cost + " coins?";
        upgrades[6].newStat.text = "+" + upgrades[6].lastUpgrade + " -> +" + upgrades[6].nextUpgrade;
    }

    //called by WeaponCritDamage() to handle staff crit damage
    void StaffCritDamage()
    {
        upgrades[7].currentStat.text = "+" + upgrades[7].lastUpgrade;
        upgrades[7].upgrade.text = "Upgrade " + upgrades[7].name + " for " + upgrades[7].cost + " coins?";
        upgrades[7].newStat.text = "+" + upgrades[7].lastUpgrade + " -> +" + upgrades[7].nextUpgrade;
    }

    //called by WeaponCritDamage() to handle bow crit damage
    void BowCritDamage()
    {
        upgrades[8].currentStat.text = "+" + upgrades[8].lastUpgrade;
        upgrades[8].upgrade.text = "Upgrade " + upgrades[8].name + " for " + upgrades[8].cost + " coins?";
        upgrades[8].newStat.text = "+" + upgrades[8].lastUpgrade + " -> +" + upgrades[8].nextUpgrade;
    }
}
