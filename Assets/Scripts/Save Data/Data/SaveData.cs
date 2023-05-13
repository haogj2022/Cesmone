using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float totalCoins;

    public string playerName;

    [Header("Base Upgrade")]
    public float baseAmount = 10;
    public float upgradeAmount = 2;
    public float startingCost = 10;

    [Header("Sword Upgrade")]
    public float currentSwordDamage;
    public float currentSwordCritChance;
    public float currentSwordCritDamage;

    public float nextSwordDamage;
    public float nextSwordCritChance;
    public float nextSwordCritDamage;

    public float swordDamageUpgradeCost;
    public float swordCritChanceUpgradeCost;
    public float swordCritDamageUpgradeCost;

    [Header("Staff Upgrade")]
    public float currentStaffDamage;
    public float currentStaffCritChance;
    public float currentStaffCritDamage;

    public float nextStaffDamage;
    public float nextStaffCritChance;
    public float nextStaffCritDamage;

    public float staffDamageUpgradeCost;
    public float staffCritChanceUpgradeCost;
    public float staffCritDamageUpgradeCost;

    [Header("Bow Upgrade")]
    public float currentBowDamage;
    public float currentBowCritChance;
    public float currentBowCritDamage;

    public float nextBowDamage;
    public float nextBowCritChance;
    public float nextBowCritDamage;

    public float bowDamageUpgradeCost;
    public float bowCritChanceUpgradeCost;
    public float bowCritDamageUpgradeCost;

    public SerializableDictionary<string, bool> isClear;

    //Set default values when the game starts
    public SaveData()
    {
        totalCoins = 0;

        playerName = "";

        SwordUpgrade();
        StaffUpgrade();
        BowUpgrade();

        isClear = new SerializableDictionary<string, bool>();
    }

    void SwordUpgrade()
    {
        currentSwordDamage = baseAmount;
        currentSwordCritChance = baseAmount;
        currentSwordCritDamage = baseAmount;

        nextSwordDamage = currentSwordDamage + upgradeAmount;
        nextSwordCritChance = currentSwordCritChance + upgradeAmount;
        nextSwordCritDamage = currentSwordCritDamage + upgradeAmount;

        swordDamageUpgradeCost = startingCost;
        swordCritChanceUpgradeCost = startingCost;
        swordCritDamageUpgradeCost = startingCost;
    }

    void StaffUpgrade()
    {
        currentStaffDamage = baseAmount;
        currentStaffCritChance = baseAmount;
        currentStaffCritDamage = baseAmount;

        nextStaffDamage = currentStaffDamage + upgradeAmount;
        nextStaffCritChance = currentStaffCritChance + upgradeAmount;
        nextStaffCritDamage = currentStaffCritDamage + upgradeAmount;

        staffDamageUpgradeCost = startingCost;
        staffCritChanceUpgradeCost = startingCost;
        staffCritDamageUpgradeCost = startingCost;
    }

    void BowUpgrade()
    {
        currentBowDamage = baseAmount;
        currentBowCritChance = baseAmount;
        currentBowCritDamage = baseAmount;

        nextBowDamage = currentBowDamage + upgradeAmount;
        nextBowCritChance = currentBowCritChance + upgradeAmount;
        nextBowCritDamage = currentBowCritDamage + upgradeAmount;

        bowDamageUpgradeCost = startingCost;
        bowCritChanceUpgradeCost = startingCost;
        bowCritDamageUpgradeCost = startingCost;
    }
}
