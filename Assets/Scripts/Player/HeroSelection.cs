using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 14/11/2022
//Summary: Handle hero selection inputs

public class HeroSelection : MonoBehaviour
{
    [Header("Canvases")]
    public GameObject startScreen;
    public GameObject genderSelection;
    public GameObject maleWeaponSelection;
    public GameObject femaleWeaponSelection;
    public GameObject characterName;

    [Header("Sprite Renderers")]
    public SpriteRenderer maleSword;
    public SpriteRenderer maleStaff;
    public SpriteRenderer maleBow;

    public SpriteRenderer femaleSword;
    public SpriteRenderer femaleStaff;
    public SpriteRenderer femaleBow;

    [Header("Box Colliders 2D")]
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
        //open start screen
        startScreen.SetActive(true); 
        genderSelection.SetActive(false);
        maleWeaponSelection.SetActive(false);
        femaleWeaponSelection.SetActive(false);
        characterName.SetActive(false);
        
        //enable male sword hero
        maleSword.enabled = true; 
        maleStaff.enabled = false;
        maleBow.enabled = false;

        femaleSword.enabled = false;
        femaleStaff.enabled = false;
        femaleBow.enabled = false;
        
        //enable male sword box
        maleSwordBox.enabled = true; 
        maleStaffBox.enabled = false;
        maleBowBox.enabled = false;

        femaleSwordBox.enabled = false;
        femaleStaffBox.enabled = false;
        femaleBowBox.enabled = false;
    }

    //when click Play button on start screen canvas
    public void LoadGenderSelection()
    {
        //open the Gender Selection canvas
        startScreen.SetActive(false);
        genderSelection.SetActive(true); 
    }

    //when click Home button on Gender Selection canvas
    public void BackToStartScreen()
    {   
        //open start screen canvas
        startScreen.SetActive(true); 
        genderSelection.SetActive(false);
    }

    //when click Male button on Gender Selection canvas
    public void LoadMaleGender()
    {
        //when sword heroes are visible
        if (maleSword.enabled == true || femaleSword.enabled == true)
        {   
            //enable male sword hero
            maleSword.enabled = true; 
            maleStaff.enabled = false;
            maleBow.enabled = false;

            femaleSword.enabled = false;
            femaleStaff.enabled = false;
            femaleBow.enabled = false;
            
            //enable male sword box
            maleSwordBox.enabled = true; 
            maleStaffBox.enabled = false;
            maleBowBox.enabled = false;

            femaleSwordBox.enabled = false;
            femaleStaffBox.enabled = false;
            femaleBowBox.enabled = false;
        }

        //when staff heroes are visible
        if (maleStaff.enabled == true || femaleStaff.enabled == true)
        {   
            //enable male staff hero
            maleSword.enabled = false;
            maleStaff.enabled = true; 
            maleBow.enabled = false;

            femaleSword.enabled = false;
            femaleStaff.enabled = false;
            femaleBow.enabled = false;
            
            //enable male staff box
            maleSwordBox.enabled = false;
            maleStaffBox.enabled = true; 
            maleBowBox.enabled = false;

            femaleSwordBox.enabled = false;
            femaleStaffBox.enabled = false;
            femaleBowBox.enabled = false;
        }

        //when bow heroes are visible
        if (maleBow.enabled == true || femaleBow.enabled == true)
        {   
            //enable male bow hero
            maleSword.enabled = false;
            maleStaff.enabled = false;
            maleBow.enabled = true; 

            femaleSword.enabled = false;
            femaleStaff.enabled = false;
            femaleBow.enabled = false;
            
            //enable male bow box
            maleSwordBox.enabled = false;
            maleStaffBox.enabled = false;
            maleBowBox.enabled = true; 

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
            
            //enable female sword hero
            femaleSword.enabled = true; 
            femaleStaff.enabled = false;
            femaleBow.enabled = false;
            
            maleSwordBox.enabled = false;
            maleStaffBox.enabled = false;
            maleBowBox.enabled = false;
            
            //enable female sword box
            femaleSwordBox.enabled = true; 
            femaleStaffBox.enabled = false;
            femaleBowBox.enabled = false;
        }

        //when staff heroes are visible
        if (maleStaff.enabled == true || femaleStaff.enabled == true)
        {
            maleSword.enabled = false;
            maleStaff.enabled = false;
            maleBow.enabled = false;
            
            //enable female staff hero
            femaleSword.enabled = false;
            femaleStaff.enabled = true; 
            femaleBow.enabled = false;

            maleSwordBox.enabled = false;
            maleStaffBox.enabled = false;
            maleBowBox.enabled = false;
            
            //enable female staff box
            femaleSwordBox.enabled = false;
            femaleStaffBox.enabled = true; 
            femaleBowBox.enabled = false;
        }

        //when bow heroes are visible
        if (maleBow.enabled == true || femaleBow.enabled == true)
        {
            maleSword.enabled = false;
            maleStaff.enabled = false;
            maleBow.enabled = false;
            
            //enable female bow hero
            femaleSword.enabled = false;
            femaleStaff.enabled = false;
            femaleBow.enabled = true; 

            maleSwordBox.enabled = false;
            maleStaffBox.enabled = false;
            maleBowBox.enabled = false;
            
            //enable female bow box
            femaleSwordBox.enabled = false;
            femaleStaffBox.enabled = false;
            femaleBowBox.enabled = true; 
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
            //open Male Weapon Selection canvas
            maleWeaponSelection.SetActive(true); 
        }

        //when female heroes are visible
        if (femaleSword.enabled == true || femaleStaff.enabled == true || femaleBow.enabled == true)
        {   
            //open Female Weapon Selection canvas
            femaleWeaponSelection.SetActive(true); 
        }
    }

    //when click Sword button on Male Weapon Selection canvas
    public void LoadMaleSword()
    {   
        //enable male sword hero     
        maleSword.enabled = true; 
        maleStaff.enabled = false;
        maleBow.enabled = false;
        
        //enable male sword box
        maleSwordBox.enabled = true; 
        maleStaffBox.enabled = false;
        maleBowBox.enabled = false;
    }

    //when click Staff button on Male Weapon Selection canvas
    public void LoadMaleStaff()
    {   
        //enable male staff hero
        maleSword.enabled = false;
        maleStaff.enabled = true; 
        maleBow.enabled = false;
        
        //enable male staff box
        maleSwordBox.enabled = false;
        maleStaffBox.enabled = true; 
        maleBowBox.enabled = false;
    }

    //when click Bow button on Male Weapon Selection canvas
    public void LoadMaleBow()
    {   
        //enable male bow hero
        maleSword.enabled = false;
        maleStaff.enabled = false;
        maleBow.enabled = true; 
        
        //enable male bow box
        maleSwordBox.enabled = false;
        maleStaffBox.enabled = false;
        maleBowBox.enabled = true; 
    }

    //when click Sword button on Female Weapon Selection canvas
    public void LoadFemaleSword()
    {   
        //enable female sword hero
        femaleSword.enabled = true; 
        femaleStaff.enabled = false;
        femaleBow.enabled = false;
        
        //enable female sword box
        femaleSwordBox.enabled = true; 
        femaleStaffBox.enabled = false;
        femaleBowBox.enabled = false;
    }

    //when click Staff button on Female Weapon Selection canvas
    public void LoadFemaleStaff()
    {   
        //enable female staff hero
        femaleSword.enabled = false;
        femaleStaff.enabled = true; 
        femaleBow.enabled = false;
        
        //enable female staff box
        femaleSwordBox.enabled = false;
        femaleStaffBox.enabled = true; 
        femaleBowBox.enabled = false;
    }

    //when click Bow button on Female Weapon Selection canvas
    public void LoadFemaleBow()
    {   
        //enable female bow hero
        femaleSword.enabled = false;
        femaleStaff.enabled = false;
        femaleBow.enabled = true; 
        
        //enable female bow box
        femaleSwordBox.enabled = false;
        femaleStaffBox.enabled = false;
        femaleBowBox.enabled = true; 
    }

    //when click Back button on Male Weapon Selection canvas
    //when click Back button on Female Weapon Selection canvas
    public void BackToGenderSelection()
    {   
        //open Gender Selection canvas
        genderSelection.SetActive(true); 

        //when male heroes are visible
        if (maleSword.enabled == true || maleStaff.enabled == true || maleBow.enabled == true)
        {   
            //close Male Weapon Selection canvas
            maleWeaponSelection.SetActive(false); 
        }

        //when female heroes are visible
        if (femaleSword.enabled == true || femaleStaff.enabled == true || femaleBow.enabled == true)
        {   
            //close Female Weapon Selection canvas
            femaleWeaponSelection.SetActive(false); 
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
            //close Male Weapon Selection canvas
            maleWeaponSelection.SetActive(false); 
        }

        //when female heroes are visible
        if (femaleSword.enabled == true || femaleStaff.enabled == true || femaleBow.enabled == true)
        {   
            //close Female Weapon Selection canvas
            femaleWeaponSelection.SetActive(false); 
        }
    }
}