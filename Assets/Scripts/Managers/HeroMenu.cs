using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 14/11/2022
//Object(s) holding this script: Hero Menu
//Summary: Handle hero selection

public class HeroMenu : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject playerMenu;

    public GameObject heroGender;
    public GameObject maleHeroWeapon;
    public GameObject femaleHeroWeapon;
    public GameObject heroName;

    public SpriteRenderer[] heroes;
    public BoxCollider2D[] hitboxes;
    public SpriteRenderer[] damageAreas;

    //when click Edit Hero button in main menu
    public void LoadGenderSelection()
    {
        //open the Hero Gender menu
        optionMenu.SetActive(false);
        playerMenu.SetActive(false);
        heroGender.SetActive(true); 
    }

    //when click Back button in Hero Gender menu
    public void BackToMainMenu()
    {
        //back to option menu
        optionMenu.SetActive(true);
        playerMenu.SetActive(true);
        heroGender.SetActive(false);
    }

    //when click Male button in Hero Gender menu
    public void LoadMaleGender()
    {
        //when sword heroes are visible
        if (heroes[0].enabled == true || heroes[3].enabled == true)
        {   
            //enable male sword hero
            heroes[0].enabled = true; 
            heroes[1].enabled = false;
            heroes[2].enabled = false;

            heroes[3].enabled = false;
            heroes[4].enabled = false;
            heroes[5].enabled = false;
            
            //enable male sword hit box
            hitboxes[0].enabled = true; 
            hitboxes[1].enabled = false;
            hitboxes[2].enabled = false;

            hitboxes[3].enabled = false;
            hitboxes[4].enabled = false;
            hitboxes[5].enabled = false;            
        }

        //when staff heroes are visible
        if (heroes[1].enabled == true || heroes[4].enabled == true)
        {
            //enable male staff hero
            heroes[0].enabled = false;
            heroes[1].enabled = true;
            heroes[2].enabled = false;

            heroes[3].enabled = false;
            heroes[4].enabled = false;
            heroes[5].enabled = false;

            //enable male staff hit box
            hitboxes[0].enabled = false;
            hitboxes[1].enabled = true;
            hitboxes[2].enabled = false;

            hitboxes[3].enabled = false;
            hitboxes[4].enabled = false;
            hitboxes[5].enabled = false;

            //enable male staff damage area
            damageAreas[0].enabled = true;
            damageAreas[1].enabled = false;

            damageAreas[2].enabled = false;
            damageAreas[3].enabled = false;
        }

        //when bow heroes are visible
        if (heroes[2].enabled == true || heroes[5].enabled == true)
        {
            //enable male bow hero
            heroes[0].enabled = false;
            heroes[1].enabled = false;
            heroes[2].enabled = true;

            heroes[3].enabled = false;
            heroes[4].enabled = false;
            heroes[5].enabled = false;

            //enable male bow hit box
            hitboxes[0].enabled = false;
            hitboxes[1].enabled = false;
            hitboxes[2].enabled = true;

            hitboxes[3].enabled = false;
            hitboxes[4].enabled = false;
            hitboxes[5].enabled = false;

            //enable male bow damage area
            damageAreas[0].enabled = false;
            damageAreas[1].enabled = true;

            damageAreas[2].enabled = false;
            damageAreas[3].enabled = false;
        }
    }

    //when click Female button in Hero Gender menu
    public void LoadFemaleGender()
    {
        //when sword heroes are visible
        if (heroes[0].enabled == true || heroes[3].enabled == true)
        {
            //enable female sword hero
            heroes[0].enabled = false;
            heroes[1].enabled = false;
            heroes[2].enabled = false;

            heroes[3].enabled = true;
            heroes[4].enabled = false;
            heroes[5].enabled = false;

            //enable female sword hit box
            hitboxes[0].enabled = false;
            hitboxes[1].enabled = false;
            hitboxes[2].enabled = false;

            hitboxes[3].enabled = true;
            hitboxes[4].enabled = false;
            hitboxes[5].enabled = false;
        }

        //when staff heroes are visible
        if (heroes[1].enabled == true || heroes[4].enabled == true)
        {
            //enable female staff hero
            heroes[0].enabled = false;
            heroes[1].enabled = false;
            heroes[2].enabled = false;

            heroes[3].enabled = false;
            heroes[4].enabled = true;
            heroes[5].enabled = false;

            //enable female staff hit box
            hitboxes[0].enabled = false;
            hitboxes[1].enabled = false;
            hitboxes[2].enabled = false;

            hitboxes[3].enabled = false;
            hitboxes[4].enabled = true;
            hitboxes[5].enabled = false;

            //enable female staff damage area
            damageAreas[0].enabled = false;
            damageAreas[1].enabled = false;

            damageAreas[2].enabled = true;
            damageAreas[3].enabled = false;
        }

        //when bow heroes are visible
        if (heroes[2].enabled == true || heroes[5].enabled == true)
        {
            //enable male sword hero
            heroes[0].enabled = false;
            heroes[1].enabled = false;
            heroes[2].enabled = false;

            heroes[3].enabled = false;
            heroes[4].enabled = false;
            heroes[5].enabled = true;

            //enable male sword hit box
            hitboxes[0].enabled = false;
            hitboxes[1].enabled = false;
            hitboxes[2].enabled = false;

            hitboxes[3].enabled = false;
            hitboxes[4].enabled = false;
            hitboxes[5].enabled = true;

            //enable female bow damage area
            damageAreas[0].enabled = false;
            damageAreas[1].enabled = false;

            damageAreas[2].enabled = false;
            damageAreas[3].enabled = true;
        }
    }

    //when click Next button in Hero Gender menu
    //when click Back button in Hero Name menu
    public void LoadWeaponSelection()
    {
        heroGender.SetActive(false);
        heroName.SetActive(false);
        
        //when male heroes are visible
        if (heroes[0].enabled == true || heroes[1].enabled == true || heroes[2].enabled == true)
        {   
            //open Male Hero Weapon menu
            maleHeroWeapon.SetActive(true); 
        }

        //when female heroes are visible
        if (heroes[3].enabled == true || heroes[4].enabled == true || heroes[5].enabled == true)
        {   
            //open Female Hero Weapon menu
            femaleHeroWeapon.SetActive(true); 
        }
    }

    //when click Sword button in Male Hero Weapon menu
    public void LoadMaleSword()
    {   
        //enable male sword hero     
        heroes[0].enabled = true; 
        heroes[1].enabled = false;
        heroes[2].enabled = false;
        
        //enable male sword hit box
        hitboxes[0].enabled = true; 
        hitboxes[1].enabled = false;
        hitboxes[2].enabled = false;

        damageAreas[0].enabled = false;
        damageAreas[1].enabled = false;
    }

    //when click Staff button in Male Hero Weapon menu
    public void LoadMaleStaff()
    {   
        //enable male staff hero
        heroes[0].enabled = false;
        heroes[1].enabled = true; 
        heroes[2].enabled = false;
        
        //enable male staff hit box
        hitboxes[0].enabled = false;
        hitboxes[1].enabled = true; 
        hitboxes[2].enabled = false;

        //enable male staff damage area
        damageAreas[0].enabled = true;
        damageAreas[1].enabled = false;
    }

    //when click Bow button in Male Hero Weapon menu
    public void LoadMaleBow()
    {   
        //enable male bow hero
        heroes[0].enabled = false;
        heroes[1].enabled = false;
        heroes[2].enabled = true; 
        
        //enable male bow box
        hitboxes[0].enabled = false;
        hitboxes[1].enabled = false;
        hitboxes[2].enabled = true;

        //enable male bow damage area
        damageAreas[0].enabled = false;
        damageAreas[1].enabled = true;
    }

    //when click Sword button in Female Hero Weapon menu
    public void LoadFemaleSword()
    {   
        //enable female sword hero
        heroes[3].enabled = true; 
        heroes[4].enabled = false;
        heroes[5].enabled = false;
        
        //enable female sword box
        hitboxes[3].enabled = true; 
        hitboxes[4].enabled = false;
        hitboxes[5].enabled = false;

        damageAreas[2].enabled = false;
        damageAreas[3].enabled = false;
    }

    //when click Staff button in Female Hero Weapon menu
    public void LoadFemaleStaff()
    {   
        //enable female staff hero
        heroes[3].enabled = false;
        heroes[4].enabled = true; 
        heroes[5].enabled = false;
        
        //enable female staff box
        hitboxes[3].enabled = false;
        hitboxes[4].enabled = true; 
        hitboxes[5].enabled = false;

        //enable female staff damage area
        damageAreas[2].enabled = true;
        damageAreas[3].enabled = false;
    }

    //when click Bow button in Female Hero Weapon menu
    public void LoadFemaleBow()
    {   
        //enable female bow hero
        heroes[3].enabled = false;
        heroes[4].enabled = false;
        heroes[5].enabled = true; 
        
        //enable female bow box
        hitboxes[3].enabled = false;
        hitboxes[4].enabled = false;
        hitboxes[5].enabled = true;

        //enable female bow damage area
        damageAreas[2].enabled = false;
        damageAreas[3].enabled = true;
    }

    //when click Back button in Male Hero Weapon menu
    //when click Back button in Female Hero Weapon menu
    public void BackToGenderSelection()
    {   
        //open Hero Gender menu
        heroGender.SetActive(true); 

        //when male heroes are visible
        if (heroes[0].enabled == true || heroes[1].enabled == true || heroes[2].enabled == true)
        {   
            //close Male Hero Weapon menu
            maleHeroWeapon.SetActive(false); 
        }

        //when female heroes are visible
        if (heroes[3].enabled == true || heroes[4].enabled == true || heroes[5].enabled == true)
        {   
            //close Female Hero Weapon menu
            femaleHeroWeapon.SetActive(false); 
        }
    }  

    //when click Next button in Male Hero Weapon menu
    //when click Next button in Female Hero Weapon menu
    public void LoadCharacterName()
    {
        heroName.SetActive(true);

        //when male heroes are visible
        if (heroes[0].enabled == true || heroes[1].enabled == true || heroes[2].enabled == true)
        {   
            //close Male Hero Weapon menu
            maleHeroWeapon.SetActive(false); 
        }

        //when female heroes are visible
        if (heroes[3].enabled == true || heroes[4].enabled == true || heroes[5].enabled == true)
        {   
            //close Female Hero Weapon menu
            femaleHeroWeapon.SetActive(false); 
        }
    }
}