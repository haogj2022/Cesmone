using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 14/11/2022
//Summary: Handle hero selection inputs

public class HeroSelection : MonoBehaviour
{
    //references to canvases
    [Header("Canvases")]
    public GameObject startScreen;
    public GameObject genderSelection;
    public GameObject maleWeaponSelection;
    public GameObject femaleWeaponSelection;
    public GameObject characterName;

    //references to heroes
    [Header("Sprite Renderers")]
    public SpriteRenderer maleSword;
    public SpriteRenderer maleStaff;
    public SpriteRenderer maleBow;

    public SpriteRenderer femaleSword;
    public SpriteRenderer femaleStaff;
    public SpriteRenderer femaleBow;

    //references to heroes
    [Header("Box Colliders")]
    public BoxCollider2D maleSwordBox;
    public BoxCollider2D maleStaffBox;
    public BoxCollider2D maleBowBox;

    public BoxCollider2D femaleSwordBox;
    public BoxCollider2D femaleStaffBox;
    public BoxCollider2D femaleBowBox;
   
    void Start()
    {
        Setup();       
    }

    //when the game starts
    void Setup()
    {
        startScreen.SetActive(true); //open start screen
        genderSelection.SetActive(false);
        maleWeaponSelection.SetActive(false);
        femaleWeaponSelection.SetActive(false);
        characterName.SetActive(false);

        maleSword.enabled = true; //enable male sword hero
        maleStaff.enabled = false;
        maleBow.enabled = false;

        femaleSword.enabled = false;
        femaleStaff.enabled = false;
        femaleBow.enabled = false;

        maleSwordBox.enabled = true; //enable male sword box
        maleStaffBox.enabled = false;
        maleBowBox.enabled = false;

        femaleSwordBox.enabled = false;
        femaleStaffBox.enabled = false;
        femaleBowBox.enabled = false;
    }

    //when click Play button on start screen canvas
    public void LoadGenderSelection()
    {
        startScreen.SetActive(false);
        genderSelection.SetActive(true); //load the Gender Selection canvas
    }

    //when click Home button on Gender Selection canvas
    public void BackToStartScreen()
    {
        startScreen.SetActive(true); //open start screen
        genderSelection.SetActive(false);
    }

    //when click Male button on Gender Selection canvas
    public void LoadMaleGender()
    {
        //when sword heroes are visible
        if (maleSword.enabled == true || femaleSword.enabled == true)
        {
            maleSword.enabled = true; //enable male sword hero
            maleStaff.enabled = false;
            maleBow.enabled = false;

            femaleSword.enabled = false;
            femaleStaff.enabled = false;
            femaleBow.enabled = false;

            maleSwordBox.enabled = true; //enable male sword box
            maleStaffBox.enabled = false;
            maleBowBox.enabled = false;

            femaleSwordBox.enabled = false;
            femaleStaffBox.enabled = false;
            femaleBowBox.enabled = false;
        }

        //when staff heroes are visible
        if (maleStaff.enabled == true || femaleStaff.enabled == true)
        {
            maleSword.enabled = false;
            maleStaff.enabled = true; //enable male staff hero
            maleBow.enabled = false;

            femaleSword.enabled = false;
            femaleStaff.enabled = false;
            femaleBow.enabled = false;

            maleSwordBox.enabled = false;
            maleStaffBox.enabled = true; //enable male staff box
            maleBowBox.enabled = false;

            femaleSwordBox.enabled = false;
            femaleStaffBox.enabled = false;
            femaleBowBox.enabled = false;
        }

        //when bow heroes are visible
        if (maleBow.enabled == true || femaleBow.enabled == true)
        {
            maleSword.enabled = false;
            maleStaff.enabled = false;
            maleBow.enabled = true; //enable male bow hero

            femaleSword.enabled = false;
            femaleStaff.enabled = false;
            femaleBow.enabled = false;

            maleSwordBox.enabled = false;
            maleStaffBox.enabled = false;
            maleBowBox.enabled = true; //enable male bow box

            femaleSwordBox.enabled = false;
            femaleStaffBox.enabled = false;
            femaleBowBox.enabled = false;
        }
    }

    //when click Female button on Gender Selection canvas
    public void LoadFemaleGender()
    {
        //when sword heroes are visible
        if (maleSword.enabled == true || femaleSword.enabled == true)
        {
            maleSword.enabled = false;
            maleStaff.enabled = false;
            maleBow.enabled = false;

            femaleSword.enabled = true; //enable female sword hero
            femaleStaff.enabled = false;
            femaleBow.enabled = false;

            maleSwordBox.enabled = false;
            maleStaffBox.enabled = false;
            maleBowBox.enabled = false;

            femaleSwordBox.enabled = true; //enable female sword box
            femaleStaffBox.enabled = false;
            femaleBowBox.enabled = false;
        }

        //when staff heroes are visible
        if (maleStaff.enabled == true || femaleStaff.enabled == true)
        {
            maleSword.enabled = false;
            maleStaff.enabled = false;
            maleBow.enabled = false;

            femaleSword.enabled = false;
            femaleStaff.enabled = true; //enable female staff hero
            femaleBow.enabled = false;

            maleSwordBox.enabled = false;
            maleStaffBox.enabled = false;
            maleBowBox.enabled = false;

            femaleSwordBox.enabled = false;
            femaleStaffBox.enabled = true; //enable female staff box
            femaleBowBox.enabled = false;
        }

        //when bow heroes are visible
        if (maleBow.enabled == true || femaleBow.enabled == true)
        {
            maleSword.enabled = false;
            maleStaff.enabled = false;
            maleBow.enabled = false;

            femaleSword.enabled = false;
            femaleStaff.enabled = false;
            femaleBow.enabled = true; //enable female bow hero

            maleSwordBox.enabled = false;
            maleStaffBox.enabled = false;
            maleBowBox.enabled = false;

            femaleSwordBox.enabled = false;
            femaleStaffBox.enabled = false;
            femaleBowBox.enabled = true; //enable female bow box
        }
    }

    //when click Next button on Gender Selection canvas
    //when click Back button on Character Name canvas
    public void LoadHeroWeapon()
    {
        genderSelection.SetActive(false);
        characterName.SetActive(false);
        
        //when male heroes are visible
        if (maleSword.enabled == true || maleStaff.enabled == true || maleBow.enabled == true)
        {
            maleWeaponSelection.SetActive(true); //load Male Weapon Selection canvas
        }

        //when female heroes are visible
        if (femaleSword.enabled == true || femaleStaff.enabled == true || femaleBow.enabled == true)
        {
            femaleWeaponSelection.SetActive(true); //load Female Weapon Selection canvas
        }
    }

    //when click Sword button on Male Weapon Selection canvas
    public void LoadMaleSword()
    {        
        maleSword.enabled = true; //enable male sword hero
        maleStaff.enabled = false;
        maleBow.enabled = false;

        maleSwordBox.enabled = true; //enable male sword box
        maleStaffBox.enabled = false;
        maleBowBox.enabled = false;
    }

    //when click Staff button on Male Weapon Selection canvas
    public void LoadMaleStaff()
    {
        maleSword.enabled = false;
        maleStaff.enabled = true; //enable male staff hero
        maleBow.enabled = false;

        maleSwordBox.enabled = false;
        maleStaffBox.enabled = true; //enable male staff box
        maleBowBox.enabled = false;
    }

    //when click Bow button on Male Weapon Selection canvas
    public void LoadMaleBow()
    {
        maleSword.enabled = false;
        maleStaff.enabled = false;
        maleBow.enabled = true; //enable male bow hero

        maleSwordBox.enabled = false;
        maleStaffBox.enabled = false;
        maleBowBox.enabled = true; //enable male bow box
    }

    //when click Sword button on Female Weapon Selection canvas
    public void LoadFemaleSword()
    {
        femaleSword.enabled = true; //enable female sword hero
        femaleStaff.enabled = false;
        femaleBow.enabled = false;

        femaleSwordBox.enabled = true; //enable female sword box
        femaleStaffBox.enabled = false;
        femaleBowBox.enabled = false;
    }

    //when click Staff button on Female Weapon Selection canvas
    public void LoadFemaleStaff()
    {
        femaleSword.enabled = false;
        femaleStaff.enabled = true; //enable female staff hero
        femaleBow.enabled = false;

        femaleSwordBox.enabled = false;
        femaleStaffBox.enabled = true; //enable female staff box
        femaleBowBox.enabled = false;
    }

    //when click Bow button on Female Weapon Selection canvas
    public void LoadFemaleBow()
    {
        femaleSword.enabled = false;
        femaleStaff.enabled = false;
        femaleBow.enabled = true; //enable female bow hero

        femaleSwordBox.enabled = false;
        femaleStaffBox.enabled = false;
        femaleBowBox.enabled = true; //enable female bow box
    }

    //when click Back button on Male Weapon Selection canvas
    //when click Back button on Female Weapon Selection canvas
    public void BackToGenderSelection()
    {
        genderSelection.SetActive(true); //load Gender Selection canvas

        //when male heroes are visible
        if (maleSword.enabled == true || maleStaff.enabled == true || maleBow.enabled == true)
        {
            maleWeaponSelection.SetActive(false); //close Male Weapon Selection canvas
        }

        //when female heroes are visible
        if (femaleSword.enabled == true || femaleStaff.enabled == true || femaleBow.enabled == true)
        {
            femaleWeaponSelection.SetActive(false); //close Female Weapon Selection canvas
        }
    }  

    //when click Next button on Male Weapon Selection canvas
    //when click Next button on Female Weapon Selection canvas
    public void LoadCharacterName()
    {
        characterName.SetActive(true);

        //when male heroes are visible
        if (maleSword.enabled == true || maleStaff.enabled == true || maleBow.enabled == true)
        {
            maleWeaponSelection.SetActive(false); //close Male Weapon Selection canvas
        }

        //when female heroes are visible
        if (femaleSword.enabled == true || femaleStaff.enabled == true || femaleBow.enabled == true)
        {
            femaleWeaponSelection.SetActive(false); //close Female Weapon Selection canvas
        }
    }
}