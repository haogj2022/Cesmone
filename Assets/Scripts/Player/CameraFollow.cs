using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 16/11/2022
//Object(s) holding this script: Main Camera
//Summary: Main Camera follows player

public class CameraFollow : MonoBehaviour
{  
    public CastleHealthText castle;
    public BoxCollider2D mapBounds;
    
    float xMin, xMax, yMin, yMax;
    float camX, camY;
    float camOrthsize;
    float smoothSpeed = 0.02f;
    
    GameObject follower;
    Camera mainCam;
    
    void Start()
    {
        //get castle health script
        castle.GetComponent<CastleHealthText>();

        //calculate the map bounds sizes
        xMin = mapBounds.bounds.min.x - 4;
        xMax = mapBounds.bounds.max.x + 4;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;

        //get the main cameara in hierarchy
        mainCam = GetComponent<Camera>();

        //set how the camera renders perspective
        camOrthsize = mainCam.orthographicSize;
    }

    void Update()
    {
        FollowTarget();
    }

    //called by Update() to follow the target
    void FollowTarget()
    {       
        //camera follows the character
        follower = GameObject.Find("Hero Selection");

        //when castle is destroyed
        if (castle.currentHealth <= 0)
        {
            //camera follows the castle instead
            follower = GameObject.Find("Castle");
        }

        //calculate the position of character on screen
        camY = Mathf.Clamp(follower.transform.position.y, yMin + camOrthsize, yMax - camOrthsize);
        camX = Mathf.Clamp(follower.transform.position.x, xMin + camOrthsize, xMax - camOrthsize);

        //follow the character on screen
        transform.position = Vector3.Lerp(transform.position, new Vector3(camX, camY, transform.position.z), smoothSpeed);
    }
}