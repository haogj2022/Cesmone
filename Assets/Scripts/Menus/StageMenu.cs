using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 22/12/2022
//Object(s) holding this script: Level Selection
//Summary: Handle stage menu events

public class StageMenu : MonoBehaviour
{
    public GameObject[] stages;
    public GameObject[] maps;

    //when player chooses a stage
    public void ChooseStage(int chosenStage)
    {
        //close all stages
        foreach(GameObject stage in stages)
        {
            stage.SetActive(false);
        }

        //open chosen stage
        stages[chosenStage].SetActive(true);        
    }   

    public void ChooseMap(int chosenMap)
    {
        //close all maps
        foreach (GameObject map in maps)
        {
            map.SetActive(false);
        }

        //open chosen map
        maps[chosenMap].SetActive(true);
    }
}
