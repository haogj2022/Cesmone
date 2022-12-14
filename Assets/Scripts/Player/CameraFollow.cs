using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 16/11/2022
//Object(s) holding this script: Main Camera
//Summary: Main Camera follows player

public class CameraFollow : MonoBehaviour
{
    GameObject follower;
    Camera mainCam;
    
    [Header("Scripts")]
    public CastleHealth castle;

    float xMin, xMax, yMin, yMax;
    float camX, camY;
    float camOrthsize;
    float smoothSpeed = 0.02f;
    float wallOffset = 1.5f;

    [Header("Walls")]
    public CompositeCollider2D mapBounds;
    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    void Start()
    {
        //get castle health script
        castle.GetComponent<CastleHealth>();

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

        //checks for walls around the map
        CheckWalls();

        //when castle is destroyed
        if (castle.currentHealth <= 0)
        {
            //ignore collisions with all the walls around the map
            Physics2D.IgnoreCollision(follower.GetComponent<BoxCollider2D>(), topWall);
            Physics2D.IgnoreCollision(follower.GetComponent<BoxCollider2D>(), bottomWall);
            Physics2D.IgnoreCollision(follower.GetComponent<BoxCollider2D>(), leftWall);
            Physics2D.IgnoreCollision(follower.GetComponent<BoxCollider2D>(), rightWall);

            //camera follows the castle instead
            follower = GameObject.Find("Castle");
        }

        //calculate the position of character on screen
        camY = Mathf.Clamp(follower.transform.position.y, yMin + camOrthsize, yMax - camOrthsize);
        camX = Mathf.Clamp(follower.transform.position.x, xMin + camOrthsize, xMax - camOrthsize);

        //follow the character on screen
        transform.position = Vector3.Lerp(transform.position, new Vector3(camX, camY, transform.position.z), smoothSpeed);
    }

    //called by FollowTarget() to setup walls around the map
    void CheckWalls()
    {
        //setup the top wall on screen
        topWall.offset = new Vector2(0, mainCam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y);

        //setup the bottom wall on screen
        bottomWall.offset = new Vector2(0, mainCam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y);

        //setup the left wall on screen
        leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + wallOffset, 0);

        //setup the right wall on screen
        rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - wallOffset, 0);
    }
}